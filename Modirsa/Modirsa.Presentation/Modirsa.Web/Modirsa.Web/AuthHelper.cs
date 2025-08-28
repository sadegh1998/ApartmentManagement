namespace Modirsa.Web
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated()
        {
            // Simple implementation - can be enhanced later
            return _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        }

        public List<int> GetPermissions()
        {
            // Simple implementation - can be enhanced later
            // For now, return empty list - implement actual permission logic later
            return new List<int>();
        }
    }
}


