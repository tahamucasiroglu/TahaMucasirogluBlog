using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahaMucasirogluBlog.Application.Validation.Extensions
{
    static public class DecimalValidateExtension
    {
        static public IRuleBuilderOptions<T, decimal> IsInRange<T>(this IRuleBuilder<T, decimal> validation, string propertyName = "", int minLength = 0, int maxLength = 0, string message = "", bool required = true)
           => validation.Required(propertyName: propertyName, required: required).Must(e => e >= minLength && e <= maxLength).WithMessage(message == "" ? $"{propertyName} değeri [{minLength} - {maxLength}] aralığında değil" : $"{propertyName}  {message}");
        static public IRuleBuilderOptions<T, decimal> BiggerThan<T>(this IRuleBuilder<T, decimal> validation, string propertyName = "", int minLength = 0, string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).GreaterThanOrEqualTo(minLength).WithMessage(message == "" ? $"{propertyName} değerinin {minLength} değerinden büyük veya eşit olmalı." : $"{propertyName}  {message}");

        static public IRuleBuilderOptions<T, decimal> LessThan<T>(this IRuleBuilder<T, decimal> validation, string propertyName = "", int maxLength = 0, string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).LessThanOrEqualTo(maxLength).WithMessage(message == "" ? $"{propertyName} değerinin {maxLength} değerinden küçük veya eşit olmalı." : $"{propertyName}  {message}");


        static public IRuleBuilderOptions<T, decimal?> BiggerThan<T>(this IRuleBuilder<T, decimal?> validation, string propertyName = "", int minLength = 0, string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).GreaterThanOrEqualTo(minLength).WithMessage(message == "" ? $"{propertyName} değerinin {minLength} değerinden büyük veya eşit olmalı." : $"{propertyName}  {message}");

        static public IRuleBuilderOptions<T, decimal?> LessThan<T>(this IRuleBuilder<T, decimal?> validation, string propertyName = "", int maxLength = 0, string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).LessThanOrEqualTo(maxLength).WithMessage(message == "" ? $"{propertyName} değerinin {maxLength} değerinden küçük veya eşit olmalı." : $"{propertyName}  {message}");
    }
}
