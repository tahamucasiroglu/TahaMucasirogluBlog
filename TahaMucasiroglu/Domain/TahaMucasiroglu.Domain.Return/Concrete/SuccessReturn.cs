using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.Return.Base;

namespace TahaMucasiroglu.Domain.Return.Concrete
{
    public record SuccessReturn : Base.Return
    {
        public SuccessReturn(string? message, Exception? exception) : base(true, message, exception) { }
        public SuccessReturn(Exception? exception) : base(true, null, exception) { }
        public SuccessReturn(string? message) : base(true, message, null) { }
        public SuccessReturn() : base(true, null, null) { }

    }

    public record SuccessReturn<T> : Return<T>
    {
        public SuccessReturn(T? data, string? message, Exception? exception) : base(true, data, message, exception) { }
        public SuccessReturn(string? message, Exception? exception) : base(true, default, message, exception) { }
        public SuccessReturn(T? data, Exception? exception) : base(true, data, null, exception) { }
        public SuccessReturn(T? data, string? message) : base(true, data, message, null) { }
        public SuccessReturn(T? data) : base(true, data, null, null) { }
        public SuccessReturn(Exception? exception) : base(true, default, null, exception) { }
        public SuccessReturn(string? message) : base(true, default, message, null) { }
        public SuccessReturn() : base(true, default, null, null) { }
    }
}
