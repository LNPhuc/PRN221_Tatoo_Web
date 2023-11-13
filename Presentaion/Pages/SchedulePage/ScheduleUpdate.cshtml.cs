using System.Globalization;
using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.SchedulePage;

public class ScheduleUpdateModel : PageModel
{
    private readonly ISchedulingService _schedulingService;

    public ScheduleUpdateModel(ISchedulingService schedulingService)
    {
        _schedulingService = schedulingService;
    }

    [BindProperty] public Scheduling schedule { get; set; } = default!;

    public IActionResult OnGet(Guid id)
    {
        if (id == Guid.Empty) return RedirectToPage("./ScheduleView");

        var getschedule = _schedulingService.GetById(id);
        if (getschedule != null) schedule = getschedule;
        return Page();
    }

    public IActionResult OnPost(Guid id)
    {
        if (schedule == null) return Page();

        var startTime = Request.Form["StartTime"].ToString();
        var endTime = Request.Form["EndTime"].ToString();
        if (schedule.Date < DateTime.Now || string.IsNullOrEmpty(schedule.Date.ToString()))
        {
            if (schedule.Date < DateTime.Now)
                ModelState.AddModelError(string.Empty,
                    $"Date is invalid! Please Select the Date After {DateTime.Now} ");
            else if (string.IsNullOrEmpty(schedule.Date.ToString()))
                ModelState.AddModelError(string.Empty, "Date is Empty! Please Select the Date");
            return Page();
        }

        if (string.IsNullOrEmpty(startTime))
        {
            ModelState.AddModelError(string.Empty, "StartTime is Empty! Please Select the Time");
            return Page();
        }

        if (string.IsNullOrEmpty(endTime))
        {
            ModelState.AddModelError(string.Empty, "EndTime is Empty! Please Select the Time");
            return Page();
        }

        var curSchedule = _schedulingService.GetById(id);
        //curSchedule.Id = id;
        curSchedule.Date = schedule.Date;
        curSchedule.StartTime = TimeSpan.ParseExact(startTime, @"hh\:mm", CultureInfo.InvariantCulture);
        curSchedule.EndTime = TimeSpan.ParseExact(endTime, @"hh\:mm", CultureInfo.InvariantCulture);
        curSchedule.Status = "ONPROCESS";
        _schedulingService.Update(curSchedule);
        _schedulingService.SaveChanges();
        return RedirectToPage("./ScheduleView");
    }
}