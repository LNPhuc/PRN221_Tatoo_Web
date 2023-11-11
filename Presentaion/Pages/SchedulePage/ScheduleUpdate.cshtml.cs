using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace Presentaion.Pages.SchedulePage
{
    public class ScheduleUpdateModel : PageModel
    {
        private readonly ISchedulingService _schedulingService;

        public ScheduleUpdateModel(ISchedulingService schedulingService)
        {
            _schedulingService = schedulingService;
        }
        [BindProperty]
        public Scheduling schedule { get; set; } = default!;
        public IActionResult OnGet(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToPage("./ScheduleView");
            }
            else
            {
                Scheduling getschedule = _schedulingService.GetById(id);
                if (getschedule != null)
                {
                    schedule = getschedule;
                }
                return Page();
            }
        }
        public IActionResult OnPost(Guid id)
        {
            if (schedule == null)
            {
                return Page();
            }
            else
            {
                string startTime = Request.Form["StartTime"].ToString();
                string endTime = Request.Form["EndTime"].ToString();
                if (schedule.Date < DateTime.Now || string.IsNullOrEmpty(schedule.Date.ToString()))
                {
                    if (schedule.Date < DateTime.Now)
                        ModelState.AddModelError(string.Empty, $"Date is invalid! Please Select the Date After {DateTime.Now} ");
                    else if (string.IsNullOrEmpty(schedule.Date.ToString()))
                        ModelState.AddModelError(string.Empty, $"Date is Empty! Please Select the Date");
                    return Page();
                }
                else if (string.IsNullOrEmpty(startTime))
                {
                    ModelState.AddModelError(string.Empty, $"StartTime is Empty! Please Select the Time");
                    return Page();
                }
                else if (string.IsNullOrEmpty(endTime))
                {
                    ModelState.AddModelError(string.Empty, $"EndTime is Empty! Please Select the Time");
                    return Page();
                } else
                {                
                    Scheduling curSchedule = _schedulingService.GetById(id);
                    //curSchedule.Id = id;
                    curSchedule.Date = schedule.Date;                    
                    curSchedule.StartTime = TimeSpan.ParseExact(startTime, @"hh\:mm", CultureInfo.InvariantCulture);                    
                    curSchedule.EndTime = TimeSpan.ParseExact(endTime, @"hh\:mm", CultureInfo.InvariantCulture);
                    curSchedule.Status = "ONPROCESS";                
                    _schedulingService.Update(curSchedule);
                    _schedulingService.SaveChanges();
                }
            }
            return RedirectToPage("./ScheduleView");

        }
    }
}
