using System.ComponentModel.DataAnnotations;

namespace FavoriteFilmsMVC.Models
{
    public class ValidReleaseYearAttribute : ValidationAttribute
    {
        private readonly int _minYear;

        public ValidReleaseYearAttribute(int minYear = 1895)
        {
            _minYear = minYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int year)
            {
                int currentYear = DateTime.Now.Year;

                if (year < _minYear || year > currentYear)
                {
                    return new ValidationResult(ErrorMessage ?? $"Год выпуска должен быть в диапазоне от {_minYear} до {currentYear}.");
                }
            }

            return ValidationResult.Success;
        }
    }
}