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

    public Studio studio { get; set; } = default!;
    [BindProperty] public DateTime bookingDate { get; set; } = default!;
    
    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        studio = _studioService.GetById(id);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var userName = HttpContext.Session.GetString("AccountID");
        if (userName == null)
        {
            return RedirectToPage("LoginPage");
        }
        Guid id = Guid.Parse(userName);
        _bookingService.CreateBooking(id, bookingDate, studio.Id);
        return Page();
    }
}