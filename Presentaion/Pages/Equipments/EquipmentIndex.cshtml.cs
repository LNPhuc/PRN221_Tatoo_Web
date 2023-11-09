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
		[BindProperty(SupportsGet = true)] public int PageIndex { get; set; } = 1;
		public int TotalPages { get; set; }
		public int PageSize { get; set; } = 10;
        [BindProperty] public string? NewId { get; set; }
        public IList<Equipment> Equipment { get;set; }

        public IActionResult OnGet()
        {
			var stu = _equipmentservice.Search(SearchQuery, PageIndex - 1, PageSize);
			TotalPages = stu.TotalPagesCount;
			Equipment = stu.Items.ToList();
			return Page();
        }
    }
}
