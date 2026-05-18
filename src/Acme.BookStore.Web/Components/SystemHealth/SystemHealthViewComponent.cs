using Acme.BookStore.Web.Components.SystemHealth;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

[Widget(RefreshUrl = "/Widgets/SystemHealth", AutoInitialize = true)]
public class SystemHealthViewComponent : ViewComponent
{
    private readonly SystemHealthAppService _service;

    public SystemHealthViewComponent(SystemHealthAppService service)
    {
        _service = service;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _service.GetAsync();
        return View("~/Components/SystemHealth/Default.cshtml", model);
    }
}