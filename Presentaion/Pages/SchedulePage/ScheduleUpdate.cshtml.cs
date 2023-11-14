using System.Globalization;
using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentaion.Pages.SchedulePage;

public class ScheduleUpdateModel : PageModel
{
    private readonly IArtistService _artistService;
    private readonly IBookingService _bookingService;
    private readonly ISchedulingService _schedulingService;

    public ScheduleUpdateModel(ISchedulingService schedulingService, IArtistService artistService,
        IBookingService bookingService)
    {
        _artistService = artistService;
        _schedulingService = schedulingService;
        _bookingService = bookingService;
    }

    [BindProperty] public Scheduling schedule { get; set; } = default!;
    public List<Artist> Artists { get; set; }
    public Guid ArtistId { get; set; }

    public IActionResult OnGet(Guid id)
    {
        if (id == Guid.Empty) return RedirectToPage("./ScheduleView");
        var getschedule = _schedulingService.GetById(id);
        if (getschedule != null) schedule = getschedule;
        var studio = _bookingService.StudioId((Guid)getschedule.BookingId);
        Artists = _artistService.GetArtistByStudioId(studio);
        ViewData["ArtistName"] = new SelectList(Artists, "Id", "Name");
        return Page();
    }

    public IActionResult OnPost(Guid id)
    {
        schedule = _schedulingService.GetById(id);
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

        schedule.Date = schedule.Date;
        schedule.StartTime = TimeSpan.ParseExact(startTime, @"hh\:mm", CultureInfo.InvariantCulture);
        schedule.EndTime = TimeSpan.ParseExact(endTime, @"hh\:mm", CultureInfo.InvariantCulture);
        if (schedule.StartTime >= schedule.EndTime)
        {
            ModelState.AddModelError(string.Empty, "Please Sclect End Time Again !");
            return Page();
        }

        schedule.Status = "ONPROCESS";
        if (schedule.Booking.ArtistId == null)
            schedule.Booking.ArtistId = Guid.Parse(Request.Form["ArtistId"].ToString());
        _schedulingService.Update(schedule);
        _schedulingService.SaveChanges();
        return RedirectToPage("./ScheduleView");
    }
}