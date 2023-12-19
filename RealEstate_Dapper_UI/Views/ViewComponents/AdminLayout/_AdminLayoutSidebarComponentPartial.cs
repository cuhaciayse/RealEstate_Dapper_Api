using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Views.ViewComponents.AdminLayout
{
    public class _AdminLayoutSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
