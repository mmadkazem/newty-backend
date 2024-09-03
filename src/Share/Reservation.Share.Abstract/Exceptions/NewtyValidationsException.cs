using FluentValidation.Results;

namespace Reservation.Share.Abstract.Exceptions;

public class NewtyValidationsException : Exception
{
    public NewtyValidationsException()
        : base("یک یا چند نقص اعتبار سنجی رخ داده است.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public NewtyValidationsException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }
}
