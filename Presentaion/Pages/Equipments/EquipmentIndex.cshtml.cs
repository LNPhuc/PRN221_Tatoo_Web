using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.DataAccess;
using BusinessLogic.IService;
using BusinessLogic.Service;

namespace Presentaion.Pages.Equipments
{
    public class EquipmentIndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }
        private readonly IEquipmentService _equipmentservice;
        private readonly IStudioService _studioService;

        public EquipmentIndexModel(IEquipmentService equipmentservice, IStudioService studioService)
        {
            _equipmentservice = equipmentservice;
            _studioService = studioService;
        }

        [BindProperty] public string? NewId { get; set; }
        public List<Equipment> Equipment { get;set; }

        public IActionResult OnGet()
        {
            var accid = HttpContext.Session.GetString("AccountID");
            Guid id = Guid.Parse(accid);
            var stu = _studioService.GetStudioByAccountId(id);
            Equipment = _equipmentservice.Search(SearchQuery,stu.Id);
			return Page();
        }
    }
}
