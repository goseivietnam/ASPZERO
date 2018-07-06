using Microsoft.AspNetCore.Antiforgery;
using MyFisrtProjectASPNETZERO.Controllers;

namespace MyFisrtProjectASPNETZERO.Web.Host.Controllers
{
    public class AntiForgeryController : MyFisrtProjectASPNETZEROControllerBase
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
