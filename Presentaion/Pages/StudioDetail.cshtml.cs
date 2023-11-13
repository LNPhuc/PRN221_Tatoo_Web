using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages;

public class StudioDetail : PageModel
{
    private readonly IArtworkService _artworkService;
    private readonly IBookingService _bookingService;
    private readonly IImageService _imageService;
    private readonly IStudioService _studioService;

    public StudioDetail(IStudioService studioService, IBookingService bookingService, IArtworkService artworkService,
        IImageService imageService)
    {
        _studioService = studioService;
        _bookingService = bookingService;
        _artworkService = artworkService;
        _imageService = imageService;
    }

    public Studio studio { get; set; }
    public List<DataAccess.DataAccess.ArtWork> ArtWorks { get; set; } = default!;
    public string img { get; set; } = default!;
    [BindProperty] public string Date { get; set; } = default!;

    public IActionResult OnGet(Guid id)
    {
        studio = _studioService.GetById(id);
        img = _imageService.Get(studio.Id);
        ArtWorks = new List<DataAccess.DataAccess.ArtWork>();
        if (studio.Artists != null)
            foreach (var a in studio.Artists)
            {
                var w = _artworkService.List(a.Id);
                foreach (var image in w) ArtWorks.Add(image);
            }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid id)
    {
        try
        {
            var userName = HttpContext.Session.GetString("AccountID");
            DateTime.TryParse(Date, out var dateValue);
            var bookingDate = dateValue;
            if (userName == null) return RedirectToPage("LoginPage");

            if (bookingDate <= DateTime.Now)
            {
                throw new Exception("Ngày không hợp lệ. Vui lòng nhập lại!");
            }

            var userid = Guid.Parse(userName);
            await _bookingService.CreateBooking(userid, bookingDate, id);
            return RedirectToPage("HomePage");
        }
        catch (Exception ex)
        {
            ViewData["notification"] = ex.Message;
        }

        return OnGet(id);
    }
}