using BusinessLogic.DTOS.Studio;
using BusinessLogic.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages;

public class ShowStudioModel : PageModel
{
    private readonly IStudioService _studioService;

    public ShowStudioModel(IStudioService studioService)
    {
        _studioService = studioService;
    }

    public IList<StudioItem> Studio { get; set; } = default!;
    [BindProperty(SupportsGet = true)] public string SearchQuery { get; set; }

    public IActionResult OnGetAsync()
    {
        Studio = _studioService.GetAllItem(SearchQuery);
        return Page();
    }
}