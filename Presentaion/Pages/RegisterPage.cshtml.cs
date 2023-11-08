using BusinessLogic.DTOS.Account;
using BusinessLogic.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages;

public class RegisterPage : PageModel
{
    private IAccountService _accountService;

    public RegisterPage(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [BindProperty] public CreateCustomer CreateCustomer { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }
    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        
        try
        {
            if(await _accountService.CheckEmail(CreateCustomer.Email) != null)
            {
                throw new Exception("Email đã được sử dụng. Vui lòng nhập lại!");
            }

            if (CreateCustomer.DateOfBirth >= DateTime.Now)
            {
                throw new Exception("Ngày sinh không hợp lệ. Vui lòng nhập lại!");
            }

            else
            {
                _accountService.CreateCustomerAccount(CreateCustomer);
                return RedirectToPage("./LoginPage");
            }
        }
        catch(Exception ex)
        {
            ViewData["notification"] = ex.Message.ToString();
        }
        return Page();
    }
}