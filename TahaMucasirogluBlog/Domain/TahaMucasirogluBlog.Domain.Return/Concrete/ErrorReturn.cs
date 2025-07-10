using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Return.Base;

namespace TahaMucasirogluBlog.Domain.Return.Concrete
{
    public record ErrorReturn : Base.Return
    {
        public ErrorReturn(string? message, Exception? exception) : base(false, message, exception) { }
        public ErrorReturn(Exception? exception) : base(false, null, exception) { }
        public ErrorReturn(string? message) : base(false, message, null) { }
        public ErrorReturn() : base(false, null, null) { }
    }

    public record ErrorReturn<T> : Return<T>
    {
        public ErrorReturn(T? data, string? message, Exception? exception) : base(false, data, message, exception) { }
        public ErrorReturn(string? message, Exception? exception) : base(false, default, message, exception) { }
        public ErrorReturn(T? data, Exception? exception) : base(false, data, null, exception) { }
        public ErrorReturn(T? data, string? message) : base(false, data, message, null) { }
        public ErrorReturn(T? data) : base(false, data, null, null) { }
        public ErrorReturn(Exception? exception) : base(false, default, null, exception) { }
        public ErrorReturn(string? message) : base(false, default, message, null) { }
        public ErrorReturn() : base(false, default, null, null) { }
    }
}
