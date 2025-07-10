using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Return.Abstract;
using TahaMucasirogluBlog.Domain.Return.Concrete;

namespace TahaMucasirogluBlog.Domain.Return.Constant
{
    /// <summary>
    /// Hata olmayan filtrenin sonucunda veri bulunamazsa bu hata döner
    /// </summary>
    public sealed record NullDataSuccess<T> : SuccessReturn<T>
    {
        public NullDataSuccess(
            string message = "Data Boş",
            Exception? exception = null)
            : base(message, exception ?? new ArgumentNullException(message)) { }
    }




    /// <summary>
    /// Veri dönmesi gerekirken veri gelmezse bu hata döner
    /// </summary>
    public sealed record NullDataError<T> : ErrorReturn<T>
    {
        public NullDataError(
            string message = "Data Boş",
            Exception? exception = null)
            : base(message, exception ?? new ArgumentNullException(message)) { }

        public NullDataError(IReturn ret)
            : base(ret.Message, ret.Exception ?? new ArgumentNullException(ret.Message)) { }
    }
}
