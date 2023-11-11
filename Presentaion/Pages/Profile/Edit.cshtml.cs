using BusinessLogic.IService;
using BusinessLogic.Service;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Profile
{
    public class EditModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public EditModel (ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [BindProperty]
        public Customer Customer { get; set; } = default;
        public IActionResult OnGet(Guid id)
        {
            var accId = HttpContext.Session.GetString("AccountID");
            if (accId == null)
            {
                return RedirectToPage("/LoginPage");
            }

            Guid accountId = Guid.Parse(accId);
            if(id != accountId)
            {
                return RedirectToPage("/LoginPage");
            }
            try
            {
                Customer = _customerService.GetCusById(accountId);
                return Page();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return Page();

            }
        }
        public IActionResult OnPost()
        {
            
            try
            {
                Customer = _customerService.UdpateCustomer(Customer.Id, Customer);
                if (Customer == null)
                {
                    throw new Exception();
                }
                return Redirect("/Profile/Index");
            }
            catch (Exception ex)
            {
				ViewData["notification"] = ex.Message.ToString();
				TempData["ErrorMessage"] = ex.Message;
            }

            return Page();
        }
    }
}
