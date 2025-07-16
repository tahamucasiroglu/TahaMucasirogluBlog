using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Models.Abstract;

namespace TahaMucasirogluBlog.Domain.Models.Base
{
    public abstract class Model : IModel
    {
        public Guid Id { get; set; }
    }
}
