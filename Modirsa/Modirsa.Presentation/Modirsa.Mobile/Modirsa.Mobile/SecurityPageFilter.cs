using _0_Framework.Application;
using _0_Framework.Infrstructure;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace Modirsa.Mobile
{
    public class SecurityPageFilter : IPageFilter
    {
        private readonly IAuthHelper _authHelper;

        public SecurityPageFilter(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var handlerPermission = (NeedsPermissionAttribute) context.HandlerMethod.MethodInfo.GetCustomAttribute(typeof(NeedsPermissionAttribute));
            if (handlerPermission == null)
            {
                return;
            }
            var aa = _authHelper.GetPermissions();
            if (_authHelper.GetPermissions().All(x=>x != handlerPermission.Permission))
            {
                context.HttpContext.Response.Redirect("/Account");
            }
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }
    }
}
