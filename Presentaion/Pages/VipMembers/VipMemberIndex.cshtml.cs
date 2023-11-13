using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.VipMembers;

public class VipMemberIndexModel : PageModel
{
    private readonly IStudioService _studioService;
    private readonly IVipmemberService _vipmemberService;

    public VipMemberIndexModel(IVipmemberService vipmemberService, IStudioService studioService)
    {
        _vipmemberService = vipmemberService;
        _studioService = studioService;
    }

    [BindProperty(SupportsGet = true)] public string SearchQuery { get; set; }

    public List<VipMember> VipMember { get; set; }
    [BindProperty(SupportsGet = true)] public int PageIndex { get; set; } = 1;
    public int TotalPages { get; set; }
    public int PageSize { get; set; } = 10;
    [BindProperty] public string? NewId { get; set; }

    public IActionResult OnGet()
    {
        var accId = HttpContext.Session.GetString("AccountID");
        var id = Guid.Parse(accId);
        var studio = _studioService.GetStudioByAccountId(id);
        try
        {
            var list = _vipmemberService.ToPagination(SearchQuery, PageIndex - 1, PageSize, studio.Id);
            TotalPages = list.TotalPagesCount;
            VipMember = list.Items.ToList();
            return Page();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}