using FluentValidation.Results;

namespace Application.Exceptions
{
    public class ValidationExceptions : ApplicationException
    {
        public ValidationExceptions() : base("خطایی در انجام عملیات رخ داده است")
        {
            Errors = new Dictionary<string, string[]>();
        }
        public ValidationExceptions(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
        public IDictionary<string, string[]> Errors { get; }
    }
}
