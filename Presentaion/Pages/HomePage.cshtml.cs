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
        public void OnGet()
        {
            /*var accId = HttpContext.Session.GetString("AccountID");
            Guid id = new Guid(accId);
            Account = _accountService.GetById(id);*/
        }
    }
}
