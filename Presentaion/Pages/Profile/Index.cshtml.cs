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
		private readonly IBookingService _bookingService;
		public IndexModel(ICustomerService customerService, IAccountService accountService, IBookingService bookingService)
		{
			_customerService = customerService;
			_accountService = accountService;
			_bookingService = bookingService;
		}
		
		public Account Account { get; set; } 
		public Customer Customer { get; set; } = default!;
		public List<Scheduling> Scheduling { get; set; }
		public void OnGet()
		{
            var accId = HttpContext.Session.GetString("AccountID");
            Guid id = new Guid(accId);
            Customer = _customerService.GetCusByAccountId(id);
            Scheduling = new List<Scheduling>();
            foreach (var v in _bookingService.GetAllByCusId(Customer.Id))
            {
	            foreach (var s in v.Schedulings)
	            {
		            Scheduling.Add(s);
	            }
            }
		}
	}
}