namespace Reservation.Test.Application.ReserveTimes;


public sealed class CreateReserveTimeReceiptCommandTest
{
    async Task Act(CreateReserveTimeReceiptCommandRequest request)
        => await _handler.Handle(request, CancellationToken.None);

    [Fact]
    public async void HandelAsync_Throw_UserNotFoundException_When_There_Is_No_Business_Found_With_This_Information()
    {
        // ARRANGE
        var request = new CreateReserveTimeReceiptCommandRequest(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, []);
        _uow.Businesses.FindAsync(Arg.Any<Guid>()).Returns(default(Business));

        // ACT
        var exception = await Record.ExceptionAsync(async () => await Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<BusinessNotFoundException>();
    }

    [Fact]
    public async void HandelAsync_Throw_BusinessClosedException_When_The_Business_Is_Closed()
    {
        // ARRANGE
        var request = new CreateReserveTimeReceiptCommandRequest(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, []);
        _uow.Businesses.FindAsync(Arg.Any<Guid>()).Returns(new Business() { IsClose = true });

        // ACT
        var exception = await Record.ExceptionAsync(async () => await Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<BusinessClosedException>();
    }

    [Fact]
    public async void HandelAsync_Throw_ThisTimeIsNotInTheWorkingTimeException_When_This_Time_Is_Not_In_The_Working_Time_Frame_Of_The_Business_Start_Hours_Of_Work()
    {
        // ARRANGE
        var now = DateTime.Now;
        var request = new CreateReserveTimeReceiptCommandRequest(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now.AddMinutes(-30), []);
        _uow.Businesses.FindAsync(Arg.Any<Guid>()).Returns(new Business() { StartHoursOfWor = new TimeSpan(now.Hour, now.Minute, now.Second) });

        // ACT
        var exception = await Record.ExceptionAsync(async () => await Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ThisTimeIsNotInTheWorkingTimeException>();
    }

    [Fact]
    public async void HandelAsync_Throw_BusinessHolidayException_When_This_Time_Is_Not_In_The_Working_Time_Frame_Of_The_Business_Start_Hours_Of_Work()
    {
        // ARRANGE
        var now = DateTime.Now;
        var request = new CreateReserveTimeReceiptCommandRequest(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now.AddMinutes(30), []);
        _uow.Businesses.FindAsync(Arg.Any<Guid>()).Returns(new Business() { EndHoursOfWor = new TimeSpan(now.Hour, now.Minute, now.Second) });

        // ACT
        var exception = await Record.ExceptionAsync(async () => await Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ThisTimeIsNotInTheWorkingTimeException>();
    }

    [Fact]
    public async void HandelAsync_Throw_ThisTimeIsNotInTheWorkingTimeException_When_This_Time_Is_On_A_Business_Holiday()
    {
        // ARRANGE
        var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
        var business = new Business()
        {
            StartHoursOfWor = new TimeSpan(7 , 0 , 0),
            EndHoursOfWor = new TimeSpan(22, 0, 0),
            Holidays = [DateTime.Now.DayOfWeek]
        };
        var request = new CreateReserveTimeReceiptCommandRequest(Guid.NewGuid(), Guid.NewGuid(), date, []);
        _uow.Businesses.FindAsync(Arg.Any<Guid>()).Returns(business);

        // ACT
        var exception = await Record.ExceptionAsync(async () => await Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<BusinessHolidayException>();
    }
    #region ARRANGE
    private readonly IUnitOfWork _uow;
    private readonly IRequestHandler<CreateReserveTimeReceiptCommandRequest> _handler;
    public CreateReserveTimeReceiptCommandTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _handler = new CreateReserveTimeReceiptCommandHandler(_uow);
    }
    #endregion
}