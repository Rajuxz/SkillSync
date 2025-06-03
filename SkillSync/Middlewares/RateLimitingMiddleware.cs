using Microsoft.Extensions.Caching.Memory;

namespace SkillSync.Middlewares
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;
        private int _requestLimit = 50;
        private readonly TimeSpan _time = TimeSpan.FromMinutes(10);

        public RateLimitingMiddleware(RequestDelegate next, IMemoryCache cache)
        {
            _next = next;
            _cache = cache;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();
            if (string.IsNullOrWhiteSpace(ipAddress))
            {
                await _next(context);
                return;
            }

            var cacheKey = $"RateLimit_{ipAddress}";
            var entry = _cache.GetOrCreate(cacheKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = _time;
                return new RateLimitEntry { Count = 0, RequestTime = DateTime.UtcNow };
            });

            entry.Count++;
            if (entry.Count > _requestLimit)
            {
                context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                context.Response.Headers["Retry-After"] = (_time.TotalSeconds).ToString();
                await context.Response.WriteAsync("Rate limit exceeded. Try again later.");
                return;
            }
            _cache.Set(cacheKey, entry, _time);
            await _next(context);
        }

        private class RateLimitEntry
        {
            public int Count { get; set; }
            public DateTime RequestTime { get; set; }
        }
    }
}
