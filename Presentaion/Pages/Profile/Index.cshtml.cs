using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Profile;

public class IndexModel : PageModel
{
    private readonly IAccountService _accountService;
    private readonly IBookingService _bookingService;
    private readonly ICustomerService _customerService;

    public IndexModel(ICustomerService customerService, IAccountService accountService, IBookingService bookingService)
    {
        _customerService = customerService;
        _accountService = accountService;
        _bookingService = bookingService;
    }

    public Customer Customer { get; set; } = default!;
    public List<Booking> Booking { get; set; }

    public void OnGet()
    {
        var accId = HttpContext.Session.GetString("AccountID");
        var id = new Guid(accId);
        Customer = _customerService.GetCusByAccountId(id);
        Booking = new List<Booking>();
        Booking = _bookingService.GetAllByCusId(Customer.Id).ToList();
    }
}