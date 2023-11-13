using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages;

public class AdminModel : PageModel
{
    private readonly IAccountService _accountService;

    public AdminModel(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public List<Account> Accounts { get; set; } = default!;

    [BindProperty] public Account Account { get; set; }

    public IActionResult OnGet()
    {
        var acc = _accountService.GetAll();
        Accounts = acc.ToList();
        return Page();
    }

    public IActionResult OnPost()
    {
        try
        {
            Account = _accountService.DisableAccount(Account.Id);
            return Page();
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
        }

        return Page();
    }
}