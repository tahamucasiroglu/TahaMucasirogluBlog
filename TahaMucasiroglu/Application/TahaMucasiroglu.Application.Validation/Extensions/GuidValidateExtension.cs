using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahaMucasiroglu.Application.Validation.Extensions
{
    static public class GuidValidateExtension
    {

        static public IRuleBuilderOptions<T, Guid?> IsGuid<T>(this IRuleBuilder<T, Guid?> validation, string propertyName = "", string message = "")
            => validation.Must(e => e != null && e.ToString()?.Length == 32).WithMessage(message == "" ? $"{propertyName} değeri Guid tipinde değil" : $"{propertyName}  {message}");


        static public IRuleBuilderOptions<T, Guid> IsGuid<T>(this IRuleBuilder<T, Guid> validation, string propertyName = "", string message = "")
            => validation.Must(e => e.ToString().Length == 32).WithMessage(message == "" ? $"{propertyName} değeri Guid tipinde değil" : $"{propertyName}  {message}");
    }
}
