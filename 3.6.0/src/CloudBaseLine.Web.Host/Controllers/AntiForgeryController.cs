using Microsoft.AspNetCore.Antiforgery;
using CloudBaseLine.Controllers;

namespace CloudBaseLine.Web.Host.Controllers
{
    public class AntiForgeryController : CloudBaseLineControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
