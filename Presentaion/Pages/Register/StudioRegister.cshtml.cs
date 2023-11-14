using BusinessLogic.DTOS.Account;
using BusinessLogic.IService;
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
        try
        {
            if (await _accountService.CheckEmail(CreateStudio.StudioEmail) != null)
                throw new Exception("Email đã được sử dụng. Vui lòng nhập lại!");

            if (CreateStudio.DateOfBirth >= DateTime.Now)
                throw new Exception("Ngày sinh không hợp lệ. Vui lòng nhập lại!");

            _accountService.CreateStudioAccount(CreateStudio);
            return RedirectToPage("/LoginPage");
        }
        catch (Exception ex)
        {
            ViewData["notification"] = ex.Message;
        }

        return Page();
    }
}