namespace Reservation.Application.ReserveTimes.Messages;

public sealed class ReserveTimeSuccessMessage
{
    public const string Created = "درخواست شما با موفقیت ثبت گردید و برای کسب و کار موردنظر ارسال گردید";
    public const string UpdatedConfirmState = "درخواست با موفقیت تایید گردید";
    public const string UpdatedCancelState = "درخواست با موفقیت لغو گردید";
    public const string Description = " برای پرداخت وقت از کسب و کار";
}
