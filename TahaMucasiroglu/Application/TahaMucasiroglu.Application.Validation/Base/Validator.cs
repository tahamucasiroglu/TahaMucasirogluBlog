using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Abstract;

namespace TahaMucasiroglu.Application.Validation.Base
{
    public class Validator<T> : AbstractValidator<T>
        where T : class, IDTO
    {
        public Validator() { }


        internal bool BeValidPathOrUrl(string path)
        {
            if (Uri.TryCreate(path, UriKind.Absolute, out var uri))
            {
                return uri.Scheme is "http" or "https" && path.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase);
            }
            // Local dosya yolu olarak kontrol
            return (path.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase)
                    && (path.Contains("\\") || path.Contains("/")));
        }
    }
}
