namespace Reservation.Application.Businesses.Messages;


public sealed class BusinessSuccessMessage
{
    public const string CategoryAdded = "دسته بندی با موفقیت به کسب و کار شما اختصاص داده شد";
    public const string UserVIPAdded = " کاربر با موفقیت به کاربران ویژه شما اضافه شد";
    public const string SendedSms = "پیامک شما به کاربران ویژه ارسال خواهد شد";
    public const string Updated = "اطلاعات شما با موفقیت بروزرسانی شد";
    public const string WaitingValidate = "درخواست شما با موفقیت برای کارشناسان ما ارسال شد لطفا شکیبا باشید";
    public const string Validated = "کسب و کار با موفقیت تایید شد";
}