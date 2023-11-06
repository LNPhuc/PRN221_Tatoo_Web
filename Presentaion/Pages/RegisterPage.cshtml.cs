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
        _accountService.CreateCustomerAccount(CreateCustomer);
        return RedirectToPage("./Index");
    }
}