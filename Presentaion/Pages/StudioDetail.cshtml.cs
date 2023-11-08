using Azure;
using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages;

public class StudioDetail : PageModel
{
    private readonly IStudioService _studioService;
    private readonly IBookingService _bookingService;

    public StudioDetail(IStudioService studioService, IBookingService bookingService)
    {
        _studioService = studioService;
        _bookingService = bookingService;
    }

    public Studio studio { get; set; }
    [BindProperty] public DateTime bookingDate { get; set; } = default!;
    
    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        studio = _studioService.GetById(id);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid id)
    {
        try
        {
            var userName = HttpContext.Session.GetString("AccountID");
            if (userName == null)
            {
                return RedirectToPage("LoginPage");
            }
            else if(bookingDate <= DateTime.Now)
            {
                throw new Exception("Ngày không hợp lệ. Vui lòng nhập lại!");
            }
            else
            {
                Guid userid = Guid.Parse(userName);
                await _bookingService.CreateBooking(userid, bookingDate, id);
            }          
        }
        catch (Exception ex)
        {
            ViewData["notification"] = ex.Message.ToString();
        }
        return Page();
    }
}