using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Extensions;

namespace TahaMucasirogluBlog.Application.Validation.Extensions
{
    static public class StringValidateExtension
    {
        static public IRuleBuilderOptions<T, string?> IsInRange<T>(this IRuleBuilder<T, string?> validation, string propertyName = "", int minLength = 0, int maxLength = 0, string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must(e => e != null && e.Length >= minLength && e.Length <= maxLength).WithMessage(message == "" ? $"{propertyName} uzunluğu [{minLength} - {maxLength}] aralığında değil" : $"{propertyName}  {message}");

        static public IRuleBuilderOptions<T, string?> OnlyLetter<T>(this IRuleBuilder<T, string?> validation, string propertyName = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must(e => e.IsOnlyLetter(!required)).WithMessage(message == "" ? $"{propertyName} değerinin içinde sadece harf olabilir." : $"{propertyName}  {message}");

        static public IRuleBuilderOptions<T, string?> OnlyDigit<T>(this IRuleBuilder<T, string?> validation, string propertyName = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must(e => e.IsOnlyDigits(!required)).WithMessage(message == "" ? $"{propertyName} değerinin içinde sadece rakam olabilir." : $"{propertyName}  {message}");

        static public IRuleBuilderOptions<T, string?> OnlyPunctuation<T>(this IRuleBuilder<T, string?> validation, string propertyName = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must(e => e.IsOnlyPunctuation(!required)).WithMessage(message == "" ? $"{propertyName} değerinin içinde sadece noktalama işareti olabilir." : $"{propertyName}  {message}");

        static public IRuleBuilderOptions<T, string?> OnlyLetterOrDigit<T>(this IRuleBuilder<T, string?> validation, string propertyName = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must(e => e.IsLetterOrDigit(!required)).WithMessage(message == "" ? $"{propertyName} değerinin içinde sadece harf ve rakam olabilir." : $"{propertyName}  {message}");
        static public IRuleBuilderOptions<T, string?> OnlyLetterOrPunctuation<T>(this IRuleBuilder<T, string?> validation, string propertyName = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must(e => e.IsLetterOrPunctuation(!required)).WithMessage(message == "" ? $"{propertyName} değerinin içinde sadece harf ve noktalama işareti olabilir." : $"{propertyName}  {message}");

        static public IRuleBuilderOptions<T, string?> OnlyLetterOrDigitOrPunctuation<T>(this IRuleBuilder<T, string?> validation, string propertyName = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must(e => e.IsLetterOrDigitOrPunctuation(!required)).WithMessage(message == "" ? $"{propertyName} değerinin içinde sadece harf, rakam ve noktalama işareti olabilir." : $"{propertyName}  {message}");

        static public IRuleBuilderOptions<T, string?> IsValidUtf8<T>(this IRuleBuilder<T, string?> validation, string propertyName = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must(e => e.IsValidUtf8(!required)).WithMessage(message == "" ? $"{propertyName} değerinin içinde utf-8 standartlarında olmayan karakterler var." : $"{propertyName}  {message}");

        static public IRuleBuilderOptions<T, string?> IsValidSha512<T>(this IRuleBuilder<T, string?> validation, string propertyName = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must(e => e.IsSha512Hash(!required)).WithMessage(message == "" ? $"{propertyName} değerinin şifreli olarak gelmeli fakat gelmedi. İstenilen şifreleme sha512" : $"{propertyName}  {message}");
        static public IRuleBuilderOptions<T, string?> IsPhoneNumber<T>(this IRuleBuilder<T, string?> validation, string propertyName = "", string message = "", bool required = true)
            => validation.Required(propertyName: propertyName, required: required).Must(e => e.IsPhoneNumber()).WithMessage(message == "" ? $"{propertyName} değeri telefon numarası olmalı." : $"{propertyName}  {message}");

        static public IRuleBuilderOptions<T, string?> IsEmail<T>(this IRuleBuilder<T, string?> validation, string propertyName = "", string message = "", bool required = true)
           => validation.Required(propertyName: propertyName, required: required).EmailAddress().WithMessage(message == "" ? $"{propertyName} değeri email adresi olmalı." : $"{propertyName}  {message}");

        static public IRuleBuilderOptions<T, string?> IsTaxNumber<T>(this IRuleBuilder<T, string?> validation, string propertyName = "", string message = "", bool required = true)
           => validation.Required(propertyName: propertyName, required: required).Must(e => e.IsValidTaxNumber()).WithMessage(message == "" ? $"{propertyName} değeri vargi no olmalı." : $"{propertyName}  {message}");

        static public IRuleBuilderOptions<T, string?> IsIdentityNumber<T>(this IRuleBuilder<T, string?> validation, string propertyName = "", string message = "", bool required = true)
           => validation.Required(propertyName: propertyName, required: required).Must(e => e.IsIdentityNumber()).WithMessage(message == "" ? $"{propertyName} değeri tc no olmalı." : $"{propertyName}  {message}");





    }
}
