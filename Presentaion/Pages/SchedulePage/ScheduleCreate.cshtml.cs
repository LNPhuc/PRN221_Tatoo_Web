using System.Globalization;
using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.SchedulePage;

public class ScheduleCreateModel : PageModel
{
    private readonly ISchedulingService _schedulingService;


    public ScheduleCreateModel(ISchedulingService schedulingService)
    {
        _schedulingService = schedulingService;
    }

    [BindProperty] public Scheduling schedule { get; set; } = default!;
    [BindProperty] public string Date { get; set; } = default!;

    [BindProperty] public Guid bookingID { get; set; }

    public IActionResult OnGet(Guid id)
    {
        if (id == Guid.Empty) return RedirectToPage("./ScheduleView");
        bookingID = id;
        return Page();
    }

    public IActionResult OnPost(Guid bookingid)
    {
        if (schedule == null) return Page();

        var startTime = Request.Form["StartTime"].ToString();
        var endTime = Request.Form["EndTime"].ToString();
        DateTime.TryParse(Date, out var dateValue);
        if (dateValue < DateTime.Now)
        {
            if (dateValue < DateTime.Now)
                ModelState.AddModelError(string.Empty,
                    $"Date is invalid! Please Select the Date After {DateTime.Now} ");
            else if (string.IsNullOrEmpty(dateValue.ToString()))
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

        var id = Guid.NewGuid();
        schedule.Id = id;
        schedule.Date = dateValue;
        schedule.BookingId = bookingid;
        schedule.StartTime = TimeSpan.ParseExact(startTime, @"hh\:mm", CultureInfo.InvariantCulture);
        schedule.EndTime = TimeSpan.ParseExact(endTime, @"hh\:mm", CultureInfo.InvariantCulture);
        schedule.Status = "ONPROCESS";
        _schedulingService.Create(schedule);
        _schedulingService.SaveChanges();
        return RedirectToPage("./ScheduleView");
    }
}