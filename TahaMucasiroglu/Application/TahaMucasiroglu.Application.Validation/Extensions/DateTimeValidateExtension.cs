using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.Extensions;

namespace TahaMucasiroglu.Application.Validation.Extensions
{
    static public class DateTimeValidateExtension
    {
        static public IRuleBuilderOptions<T, DateTime> IsDateTimePast<T>(this IRuleBuilder<T, DateTime> validation, string propertyName = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must(e => e.IsLessThan(DateTime.Now)).WithMessage(message == "" ? $"{propertyName} tarih değerinin geçmiş zaman olması gerekmektedir." : $"{propertyName}  {message}");

        static public IRuleBuilderOptions<T, DateTime> IsDateTimeFuture<T>(this IRuleBuilder<T, DateTime> validation, string propertyName = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must(e => e.IsBiggerThan(DateTime.Now)).WithMessage(message == "" ? $"{propertyName} tarih değerinin gelecek zaman olması gerekmektedir." : $"{propertyName}  {message}");
        static public IRuleBuilderOptions<T, DateTime?> IsDateTimePast<T>(this IRuleBuilder<T, DateTime?> validation, string propertyName = "", string message = "", bool required = true)
                    => validation.Required(propertyName: propertyName, required: required).Must(e => e.IsLessThan(DateTime.Now)).WithMessage(message == "" ? $"{propertyName} tarih değerinin geçmiş zaman olması gerekmektedir." : $"{propertyName}  {message}");

        static public IRuleBuilderOptions<T, DateTime?> IsDateTimeFuture<T>(this IRuleBuilder<T, DateTime?> validation, string propertyName = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must(e => e.IsBiggerThan(DateTime.Now)).WithMessage(message == "" ? $"{propertyName} tarih değerinin gelecek zaman olması gerekmektedir." : $"{propertyName}  {message}");

        public static IRuleBuilderOptions<T, DateTime?> BiggerThan<T>(this IRuleBuilder<T, DateTime?> validation, Func<T, DateTime?> otherDate, string propertyName = "", string propertyName2 = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must((dto, currentValue) => currentValue.HasValue && otherDate(dto).HasValue && currentValue > otherDate(dto)).WithMessage(message == "" ? $" {propertyName} Tarihi {propertyName2} tarihinden geride olamaz." : $"{propertyName} {propertyName2} {message}");

        public static IRuleBuilderOptions<T, DateTime> BiggerThan<T>(this IRuleBuilder<T, DateTime> validation, Func<T, DateTime?> otherDate, string propertyName = "", string propertyName2 = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must((dto, currentValue) => otherDate(dto).HasValue && currentValue > otherDate(dto)).WithMessage(message == "" ? $" {propertyName} Tarihi {propertyName2} tarihinden geride olamaz." : $"{propertyName} {propertyName2} {message}");

        public static IRuleBuilderOptions<T, DateTime?> LessThan<T>(this IRuleBuilder<T, DateTime?> validation, Func<T, DateTime?> otherDate, string propertyName = "", string propertyName2 = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must((dto, currentValue) => currentValue.HasValue && otherDate(dto).HasValue && currentValue < otherDate(dto)).WithMessage(message == "" ? $" {propertyName} Tarihi {propertyName2} tarihinden ileride olamaz." : $"{propertyName} {propertyName2} {message}");

        public static IRuleBuilderOptions<T, DateTime> LessThan<T>(this IRuleBuilder<T, DateTime> validation, Func<T, DateTime?> otherDate, string propertyName = "", string propertyName2 = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must((dto, currentValue) => otherDate(dto).HasValue && currentValue < otherDate(dto)).WithMessage(message == "" ? $" {propertyName} Tarihi {propertyName2} tarihinden ileride olamaz." : $"{propertyName} {propertyName2} {message}");



        public static IRuleBuilderOptions<T, DateTime?> BiggerThan<T>(this IRuleBuilder<T, DateTime?> validation, DateTime otherDate, string propertyName = "", string propertyName2 = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must((dto, currentValue) => currentValue.HasValue && currentValue > otherDate).WithMessage(message == "" ? $" {propertyName} Tarihi {propertyName2} tarihinden geride olamaz." : $"{propertyName} {propertyName2} {message}");

        public static IRuleBuilderOptions<T, DateTime> BiggerThan<T>(this IRuleBuilder<T, DateTime> validation, DateTime otherDate, string propertyName = "", string propertyName2 = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must((dto, currentValue) => currentValue > otherDate).WithMessage(message == "" ? $" {propertyName} Tarihi {propertyName2} tarihinden geride olamaz." : $"{propertyName} {propertyName2} {message}");

        public static IRuleBuilderOptions<T, DateTime?> LessThan<T>(this IRuleBuilder<T, DateTime?> validation, DateTime otherDate, string propertyName = "", string propertyName2 = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must((dto, currentValue) => currentValue.HasValue && currentValue < otherDate).WithMessage(message == "" ? $" {propertyName} Tarihi {propertyName2} tarihinden ileride olamaz." : $"{propertyName} {propertyName2} {message}");

        public static IRuleBuilderOptions<T, DateTime> LessThan<T>(this IRuleBuilder<T, DateTime> validation, DateTime otherDate, string propertyName = "", string propertyName2 = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must((dto, currentValue) => currentValue < otherDate).WithMessage(message == "" ? $" {propertyName} Tarihi {propertyName2} tarihinden ileride olamaz." : $"{propertyName} {propertyName2} {message}");

    }
}
