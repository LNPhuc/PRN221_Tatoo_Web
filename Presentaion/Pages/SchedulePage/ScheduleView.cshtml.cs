using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.SchedulePage;

public class ScheduleViewModel : PageModel
{
    private readonly IBookingService m_bookingService;
    private readonly ISchedulingService m_schedulingService;
    private readonly IStudioService m_studioService;

    public ScheduleViewModel(ISchedulingService schedulingService, IBookingService bookingService,
        IStudioService studioService)
    {
        m_schedulingService = schedulingService;
        m_bookingService = bookingService;
        m_studioService = studioService;
    }

    public IList<Customer> Customers { get; set; } = default!;

    public IList<Scheduling> Schedulings { get; set; } = default!;

    public IList<Booking> Bookings { get; set; } = default!;

    public IList<Account> Accounts { get; set; }

    [BindProperty] public Guid studioID { get; set; }

    public IActionResult OnGet()
    {
        var userId = Guid.Parse(HttpContext.Session.GetString("AccountID"));
        var studio = m_studioService.GetStudioByAccountId(userId);
        studioID = studio.Id;
        if (userId == null || studio.Account.Role != "STAFF" || studioID == Guid.Empty)
            return RedirectToPage("/LoginPage");
        ShowDataOnTable(studioID);
        return Page();
    }

    public IActionResult OnGetBookingCancel(Guid id, Guid studioid)
    {
        var curBooking = new Booking();
        curBooking = m_schedulingService.GetBookingByID(id);
        curBooking.Status = "CANCEL";
        m_schedulingService.UpdateBooking(curBooking);
        m_schedulingService.SaveChanges();

        ShowDataOnTable(studioid);
        return Page();
    }

    public IActionResult OnGetBookingDone(Guid id, Guid studioid)
    {
        var curBooking = new Booking();
        curBooking = m_schedulingService.GetBookingByID(id);
        curBooking.Status = "DONE";
        m_schedulingService.UpdateBooking(curBooking);
        m_schedulingService.SaveChanges();
        ShowDataOnTable(studioid);
        return Page();
    }

    public IActionResult OnGetCancel(Guid id, Guid studioid)
    {
        var scheduling = new Scheduling();
        scheduling = m_schedulingService.GetById(id);
        scheduling.Status = "CANCEL";
        m_schedulingService.Update(scheduling);
        m_schedulingService.SaveChanges();
        ShowDataOnTable(studioid);


        return Page();
    }

    public IActionResult OnGetDone(Guid id, Guid studioid)
    {
        var scheduling = new Scheduling();
        scheduling = m_schedulingService.GetById(id);
        scheduling.Status = "DONE";
        m_schedulingService.Update(scheduling);
        m_schedulingService.SaveChanges();

        ShowDataOnTable(studioid);
        return Page();
    }

    public void ShowDataOnTable(Guid id)
    {
        if (m_schedulingService.GetBookingByStudio(id) != null)
        {
            var listGetCus = new List<Customer>();
            var listGetAcc = new List<Account>();

            Bookings = m_schedulingService.GetBookingByStudio(id);
            if (Bookings.Count > 0)
            {
                foreach (var booking in Bookings)
                {
                    var customer = m_schedulingService.GetCustomerByID((Guid)booking.CustomerId);
                    listGetCus.Add(customer);
                    var account = m_schedulingService.GetAccountByID((Guid)customer.AccountId);
                    listGetAcc.Add(account);
                }

                Customers = listGetCus.ToList();
                Accounts = listGetAcc.ToList();
            }
        }

        if (m_schedulingService.GetSchedulingByStudio(id) != null)
            Schedulings = m_schedulingService.GetSchedulingByStudio(id);
    }
}