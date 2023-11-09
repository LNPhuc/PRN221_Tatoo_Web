using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages
{
    public class HomePageModel : PageModel
    {
        private readonly IAccountService _accountService;

        public HomePageModel(IAccountService accountService)
        {
            _accountService = accountService;    
        }
        public Account Account { get; set; } = default!;
		public IActionResult OnGetLogout()
		{
			HttpContext.Session.Remove("AccountID");
			HttpContext.Session.Remove("AccountName");
			HttpContext.Session.Remove("AccountRole");
			// Handle the GET request, if needed
			return RedirectToPage("./Index");
		}
	}
}
