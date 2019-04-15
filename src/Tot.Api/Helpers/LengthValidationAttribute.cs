using System.ComponentModel.DataAnnotations;
using static System.String;
namespace Tot.Api.Helpers
{
    public sealed class LengthValidationAttribute : ValidationAttribute
    {
        private readonly int _maxLength;
        private readonly int _minLength;

        public LengthValidationAttribute(int minLength, int maxLength, string name)
        {
            _minLength = minLength;
            _maxLength = maxLength;

            ErrorMessage = string.Format($"O campo “{0}” deve conter  no minimo {1} e no máximo {2} caracteres.", name, minLength, maxLength);
        }

        public override bool IsValid(object value)
        {
            var val = value as string;

            return !(!IsNullOrEmpty(val) && (val.Length < _minLength || val.Length > _maxLength));
        }
    }
}
