using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace VideoGamesCompaniesAPI.Middleware
{
    public class RequestTimeSpanMiddleware : IMiddleware
    {
        private readonly Stopwatch _stopWatch;
        private readonly ILogger<RequestTimeSpanMiddleware> _logger;

        public RequestTimeSpanMiddleware(ILogger<RequestTimeSpanMiddleware> logger)
        {
            _stopWatch = new Stopwatch();
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopWatch.Start();
            await next.Invoke(context);
            _stopWatch.Stop();

            TimeSpan ts = _stopWatch.Elapsed;
            if (ts.TotalSeconds > 4)
            {
                var message = $"Request [{context.Request.Method}] at {context.Request.Path} took {ts.TotalSeconds} s";
                _logger.LogInformation(message);
            }
        }
    }
}
