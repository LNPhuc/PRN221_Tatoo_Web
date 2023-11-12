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
    private readonly IArtworkService _artworkService;

    public StudioDetail(IStudioService studioService, IBookingService bookingService, IArtworkService artworkService)
    {
        _studioService = studioService;
        _bookingService = bookingService;
        _artworkService = artworkService;
    }

    public Studio studio { get; set; }
    public List<DataAccess.DataAccess.ArtWork> ArtWorks { get; set; }   = default!;
    [BindProperty] public String Date { get; set; } = default!;
    
    public IActionResult OnGet(Guid id)
    {
        studio = _studioService.GetById(id);
        if (studio.Artists != null)
        {
            foreach (var a in studio.Artists)
            {
                var w = _artworkService.List(a.Id);
                foreach (var image in w)
                {
                    ArtWorks.Add(image);
                }
            }  
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid id)
    {
        try
        {
            var userName = HttpContext.Session.GetString("AccountID");
            DateTime.TryParse(Date, out DateTime dateValue);
            DateTime bookingDate = dateValue;
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
                return RedirectToPage("HomePage");
            }          
        }
        catch (Exception ex)
        {
            ViewData["notification"] = ex.Message.ToString();
        }
        return OnGet(id);
    }
}