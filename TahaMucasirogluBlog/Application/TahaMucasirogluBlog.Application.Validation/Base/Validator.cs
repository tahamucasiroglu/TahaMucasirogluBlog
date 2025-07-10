using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Abstract;

namespace TahaMucasirogluBlog.Application.Validation.Base
{
    public class Validator<T> : AbstractValidator<T>
        where T : class, IDTO
    {
        public Validator() { }
    }
}
