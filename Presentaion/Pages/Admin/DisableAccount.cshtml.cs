using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Admin;

public class DisableAccountModel : PageModel
{
    private readonly IAccountService _accountService;

    public DisableAccountModel(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [BindProperty] public Account Account { get; set; } = default!;

    public IActionResult OnGet(Guid id)
    {
        var acc = _accountService.GetById(id);

        if (acc == null)
            return NotFound();
        Account = acc;
        return Page();
    }

    public IActionResult OnPost()
    {
        _accountService.DisableAccount(Account.Id);

        return RedirectToPage("./Admin");
    }
}