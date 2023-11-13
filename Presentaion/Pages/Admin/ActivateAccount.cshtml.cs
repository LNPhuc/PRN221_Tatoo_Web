using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Admin
{
    public class ActivateAccountModel : PageModel
    {
        private readonly IAccountService _accountService;
        public ActivateAccountModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;
        public IActionResult OnGet(Guid id)
        {

            var acc = _accountService.GetById(id);

            if (acc == null)
            {
                return NotFound();
            }
            else
            {
                Account = acc;
            }
            return Page();
        }
        public IActionResult OnPost()
        {

            _accountService.ActivateAccount(Account.Id);

            return RedirectToPage("./Admin");
        }
       
    }
}
