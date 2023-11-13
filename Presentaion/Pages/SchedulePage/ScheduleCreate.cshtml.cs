using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SQLitePCL;
using System.Globalization;

namespace Presentaion.Pages.SchedulePage
{
    public class ScheduleCreateModel : PageModel
    {
        private readonly ISchedulingService _schedulingService;

        public ScheduleCreateModel(ISchedulingService schedulingService)
        {
            _schedulingService = schedulingService;
        }
        [BindProperty]
        public Scheduling schedule { get; set; } = default!;

        public List<SelectListItem> ArtistOptions { get; set; }
        [BindProperty]
        public Guid bookingID { get; set; }
        public IActionResult OnGet(Guid id, Guid studioId)
        {
            if (id == Guid.Empty || studioId == Guid.Empty)
            {
                return RedirectToPage("./ScheduleView");
            }
            else
            {
                bookingID = id;
                var artishList = _schedulingService.GetAllArtishByStudio(studioId).ToList();
                List<SelectListItem> selectList = new List<SelectListItem>();
                foreach (var artist in artishList) 
                {
                    SelectListItem selectListItem = new SelectListItem{Value = artist.Id.ToString(), Text = artist.Name};
                    selectList.Add(selectListItem);
                }
                ArtistOptions = selectList;
                return Page();
            }
        }
        public IActionResult OnPost(Guid bookingid)
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
                }
                else
                {
                    Guid id = Guid.NewGuid();
                    var getBooking = _schedulingService.GetBookingByID((Guid)schedule.BookingId);
                    getBooking.ArtistId = Guid.Parse(artishId);
                    _schedulingService.UpdateBooking(getBooking);
                    schedule.Id = id;
                    schedule.BookingId = bookingid;                    
                    schedule.StartTime = TimeSpan.ParseExact(startTime, @"hh\:mm", CultureInfo.InvariantCulture);                    
                    schedule.EndTime = TimeSpan.ParseExact(endTime, @"hh\:mm", CultureInfo.InvariantCulture);
                    schedule.Status = "ONPROCESS";
                    _schedulingService.Create(schedule);
                    _schedulingService.SaveChanges();
                }
            }
            return RedirectToPage("./ScheduleView");
        }
    }
}
