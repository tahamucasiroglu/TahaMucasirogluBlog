using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahaMucasiroglu.Application.Validation.Extensions
{
    static public class ValidateExtension
    {
        static public IRuleBuilder<T, TProperty> Required<T, TProperty>(this IRuleBuilder<T, TProperty> validation, string propertyName = "", string emptyMessage = "", string nullMessage = "", bool required = true)
            => required ? validation.NotEmpty().WithMessage(emptyMessage == "" ? $"{propertyName} değeri boş olamaz" : $"{propertyName}  {emptyMessage}").NotNull().WithMessage(nullMessage == "" ? $"{propertyName} değeri null olamaz" : $"{propertyName}  {nullMessage}") : validation;
    }
}
