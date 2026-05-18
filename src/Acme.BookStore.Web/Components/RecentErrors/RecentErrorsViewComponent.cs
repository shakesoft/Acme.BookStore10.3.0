using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

[Widget(RefreshUrl = "/Widgets/RecentErrors", AutoInitialize = true)]
public class RecentErrorsViewComponent : ViewComponent
{
    private readonly RecentErrorsAppService _service;

    public RecentErrorsViewComponent(RecentErrorsAppService service)
    {
        _service = service;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _service.GetAsync();

        return View("~/Components/RecentErrors/Default.cshtml", model);
    }
}