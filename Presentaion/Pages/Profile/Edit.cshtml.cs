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
        public Customer Customer { get; set; } = default!;
        public PageResult OnGet(Guid id)
        {
            try
            {
                Customer = _customerService.GetCusById(id);
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
                return Redirect("/Profile/Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return Page();
        }
    }
}
