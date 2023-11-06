using BusinessLogic.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Login;

public class LoginPage : PageModel
{
    private IAccountService _accountService;

    public LoginPage(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public void OnGet()
    {
        // Handle the GET request, if needed
    }

    public async Task<IActionResult> OnPost()
    {
        var account = await _accountService.Login(Username, Password);
        if (account == null)
        { 
            ModelState.AddModelError(string.Empty, "Tài khoản không tồn tại");
        }
        HttpContext.Session.SetString("AccountID", account.Id.ToString());
        return RedirectToPage("./Index");
    }
}