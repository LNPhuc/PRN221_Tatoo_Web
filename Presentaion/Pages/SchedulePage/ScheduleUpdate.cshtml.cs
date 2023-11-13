using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public List<SelectListItem> ArtistOptions { get; set; }
        public IActionResult OnGet(Guid id, Guid studioId)
        {
            if (id == Guid.Empty || studioId == Guid.Empty)
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
                var artishList = _schedulingService.GetAllArtishByStudio(studioId).ToList();
                List<SelectListItem> selectList = new List<SelectListItem>();
                foreach (var artist in artishList)
                {
                    SelectListItem selectListItem = new SelectListItem { Value = artist.Id.ToString(), Text = artist.Name };
                    selectList.Add(selectListItem);
                }
                ArtistOptions = selectList;
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
                string artishId = Request.Form["artishId"].ToString();
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
                    var getBooking = _schedulingService.GetBookingByID((Guid)curSchedule.BookingId);
                    getBooking.ArtistId = Guid.Parse(artishId);
                    _schedulingService.UpdateBooking(getBooking);
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
