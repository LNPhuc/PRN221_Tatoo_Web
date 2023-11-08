using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Profile
{
	public class IndexModel : PageModel
	{
		private readonly ICustomerService _customerService;
		private readonly IAccountService _accountService;
		private readonly ISchedulingService _schedulingService;
		public IndexModel(ICustomerService customerService, IAccountService accountService, ISchedulingService schedulingService)
		{
			_customerService = customerService;
			_accountService = accountService;
			_schedulingService = schedulingService;
		}
		
		public Account Account { get; set; } 
		public Customer Customer { get; set; } = default!;
		public List<Scheduling> Scheduling { get; set; }
		public void OnGet()
		{
			var accId = HttpContext.Session.GetString("AccountID");
			Guid id = new Guid(accId);
			Customer = _customerService.GetCusById(id); 
		}
	}
}