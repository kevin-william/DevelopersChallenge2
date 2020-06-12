using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace OFX_CONCILIACAO_API.Filters
{
    public class ExceptionMiddleware
    {

        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next ??
                throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(GetMessageForLogging(ex));
            }
        }

        public static string GetMessageForLogging(Exception ex)
        {
            var msg = $"OFX Reader Error: {ex.Message}";
            return msg;
        }

    }
}
