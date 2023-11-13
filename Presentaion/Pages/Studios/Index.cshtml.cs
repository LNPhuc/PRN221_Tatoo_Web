using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Studios;

public class IndexModel : PageModel
{
    private readonly IStudioService _studioService;

    public IndexModel(IStudioService studioService)
    {
        _studioService = studioService;
    }

    [BindProperty(SupportsGet = true)] public string SearchQuery { get; set; }

    [BindProperty(SupportsGet = true)] public int PageIndex { get; set; } = 1;
    public int TotalPages { get; set; }
    public int PageSize { get; set; } = 10;
    [BindProperty] public string? NewId { get; set; }

    public List<Studio> Studio { get; set; } = default!;

    public IActionResult OnGet()
    {
        var stu = _studioService.Search(SearchQuery, PageIndex - 1, PageSize);
        TotalPages = stu.TotalPagesCount;
        Studio = stu.Items.ToList();
        return Page();
    }
}