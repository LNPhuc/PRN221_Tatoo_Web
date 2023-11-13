using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Equipments;

public class EquipmentIndexModel : PageModel
{
    private readonly IEquipmentService _equipmentservice;
    private readonly IStudioService _studioService;

    public EquipmentIndexModel(IEquipmentService equipmentservice, IStudioService studioService)
    {
        _equipmentservice = equipmentservice;
        _studioService = studioService;
    }

    [BindProperty(SupportsGet = true)] public string SearchQuery { get; set; }

    [BindProperty] public string? NewId { get; set; }
    public List<Equipment> Equipment { get; set; }

    public IActionResult OnGet()
    {
        var accid = HttpContext.Session.GetString("AccountID");
        var id = Guid.Parse(accid);
        var stu = _studioService.GetStudioByAccountId(id);
        Equipment = _equipmentservice.Search(SearchQuery, stu.Id);
        return Page();
    }
}