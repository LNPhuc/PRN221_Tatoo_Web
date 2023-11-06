using BusinessLogic.DTOS.Account;
using BusinessLogic.IService;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Register;

public class StudioRegister : PageModel
{
    private IAccountService _accountService;

    public StudioRegister(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [BindProperty] public CreateStudio CreateStudio { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        _accountService.CreateStudioAccount(CreateStudio);
        return RedirectToPage("/LoginPage");
    }
}