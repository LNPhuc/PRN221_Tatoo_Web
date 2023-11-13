using BusinessLogic.IService;
using DataAccess;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Presentaion.Pages.Profile;

public class ScheduleModel : PageModel
{
    private readonly ISchedulingService _schedulingService;

    public ScheduleModel(ISchedulingService schedulingService)
    {
        _schedulingService = schedulingService;
    }

    public IList<Scheduling> Schedulings { get; set; } = default!;

    public async Task OnGetAsync(Guid id)
    {
        Schedulings = new List<Scheduling>();
        Schedulings = _schedulingService.GetByBooking(id);
    }
}