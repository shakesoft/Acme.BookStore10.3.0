using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

[Widget(RefreshUrl = "/Widgets/LiveLogs", AutoInitialize = true)]
public class LiveLogsViewComponent : ViewComponent
{
    private readonly LiveLogsAppService _service;

    public LiveLogsViewComponent(LiveLogsAppService service)
    {
        _service = service;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _service.GetLatestAsync();

        return View("~/Components/LiveLogs/Default.cshtml", model);
    }
}