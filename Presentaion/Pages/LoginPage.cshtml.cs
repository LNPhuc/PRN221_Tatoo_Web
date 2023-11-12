using BusinessLogic.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Presentaion.Pages.Login;

public class LoginPage : PageModel
{
    private IAccountService _accountService;

    public LoginPage(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public void OnGet()
    {
	}

    public async Task<IActionResult> OnPost()
    {
        try
        {
            var account = await _accountService.Login(Email, Password);
            if (account == null)
            {
                ViewData["notification"] = "Tài khoản không tồn tại";
                return Page();
            }
            else
            {
                HttpContext.Session.SetString("AccountID", account.Id.ToString());
                HttpContext.Session.SetString("AccountName", account.UserName);
                HttpContext.Session.SetString("AccountRole", account.Role);


                return RedirectToPage("./Index");
            }
        }
        catch(Exception ex)
        {
            ViewData["notification"] = ex.Message.ToString();
        }
        return Page();
    }
}