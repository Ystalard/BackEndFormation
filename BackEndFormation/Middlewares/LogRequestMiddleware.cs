namespace BackEndFormation.Middlewares
{
    public class LogRequestMiddleware
    {
        #region Fields
        private readonly RequestDelegate _next;
        private readonly ILogger<LogRequestMiddleware> _logger;
        #endregion

        #region Constructors
        public LogRequestMiddleware(RequestDelegate next, ILogger<LogRequestMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        #endregion

        #region Methods
        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation(context.Request.Path);
            await _next(context);
        }
        #endregion
    }
}
