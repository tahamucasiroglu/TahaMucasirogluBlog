using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.Extensions;
using TahaMucasiroglu.Domain.Return.Constant;

namespace TahaMucasiroglu.Presentation.API.Middlewares
{
    public class NotFoundMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<NotFoundMiddleware> _logger;

        public NotFoundMiddleware(RequestDelegate next, ILogger<NotFoundMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Request'i başa sarabilmek için enable buffering!
            context.Request.EnableBuffering();

            await _next(context);

            if (context.Response.StatusCode == 404)
            {
                // Tam URL
                var url = context.Request.Path + context.Request.QueryString;

                // Varsayılan olarak body okunmuş olabilir. Baştan oku!
                context.Request.Body.Position = 0;

                string requestBody = string.Empty;

                if (context.Request.ContentLength > 0 &&
                    context.Request.ContentType != null &&
                    context.Request.ContentType.Contains("application/json"))
                {
                    using (var reader = new StreamReader(context.Request.Body, encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true))
                    {
                        requestBody = await reader.ReadToEndAsync();
                        context.Request.Body.Position = 0; // Geri sar
                    }
                }

                _logger.LogWarning("404 NOT FOUND: URL: {Url}, Body: {Body}", url, requestBody);

                // Cevabı da özelleştir
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(new Api404Error().ToJson());
            }
        }
    }
}
