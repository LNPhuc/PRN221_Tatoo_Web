using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.SchedulePage
{
    public class ScheduleViewModel : PageModel
    {
        private readonly ISchedulingService m_schedulingService;

        private readonly IBookingService m_bookingService;

        public ScheduleViewModel(ISchedulingService schedulingService, IBookingService bookingService)
        {
            m_schedulingService = schedulingService;
            m_bookingService = bookingService;
        }

        public IList<Customer> Customers { get; set; } = default!;

        public IList<Scheduling> Schedulings { get; set; } = default!;

        public IList<Booking> Bookings { get; set; } = default!;

        public IList<Account> Accounts { get; set; } = default;
        [BindProperty]
        public Guid studioID { get; set; }
        public IActionResult OnGet(Guid id)
        {
            //id = Guid.Parse("C3F6CF3C-D089-4D12-BD78-2989B622B737");
            studioID = id;
            string userName = HttpContext.Session.GetString("AccountRole");
            if (userName == null || userName != "Staff")
            {
                return RedirectToPage("/LoginPage");
            }
            ShowDataOnTable(studioID);
            return Page();
        }
        public IActionResult OnGetBookingCancel(Guid id, Guid studioid)
        {
            Booking curBooking = new Booking();
            curBooking = m_schedulingService.GetBookingByID(id);
            curBooking.Status = "CANCEL";
            m_schedulingService.UpdateBooking(curBooking);
            m_schedulingService.SaveChanges();

            ShowDataOnTable(studioid);
            return Page();
        }
        public IActionResult OnGetBookingDone(Guid id, Guid studioid)
        {
            Booking curBooking = new Booking();
            curBooking = m_schedulingService.GetBookingByID(id);
            curBooking.Status = "DONE";
            m_schedulingService.UpdateBooking(curBooking);
            m_schedulingService.SaveChanges();
            ShowDataOnTable(studioid);
            return Page();
        }
        public IActionResult OnGetCancel(Guid id, Guid studioid)
        {
            Scheduling scheduling = new Scheduling();
            scheduling = m_schedulingService.GetById(id);
            scheduling.Status = "CANCEL";
            m_schedulingService.Update(scheduling);
            m_schedulingService.SaveChanges();
            ShowDataOnTable(studioid);


            return Page();
        }
        public IActionResult OnGetDone(Guid id, Guid studioid)
        {
            Scheduling scheduling = new Scheduling();
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
                List<Customer> listGetCus = new List<Customer>();
                List<Account> listGetAcc = new List<Account>();

                Bookings = m_schedulingService.GetBookingByStudio(id);
                if (Bookings.Count > 0)
                {
                    foreach (var booking in Bookings)
                    {
                        Customer customer = m_schedulingService.GetCustomerByID(((Guid)booking.CustomerId));
                        listGetCus.Add(customer);
                        Account account = m_schedulingService.GetAccountByID((Guid)customer.AccountId);
                        listGetAcc.Add(account);
                    }
                    Customers = listGetCus.ToList();
                    Accounts = listGetAcc.ToList();
                }
            }
            if (m_schedulingService.GetSchedulingByStudio(id) != null)
            {
                Schedulings = m_schedulingService.GetSchedulingByStudio(id);
            }
        }
    }
}
