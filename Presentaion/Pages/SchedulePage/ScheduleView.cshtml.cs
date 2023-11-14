using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.SchedulePage
{
    public class ScheduleViewModel : PageModel
    {
        private readonly ISchedulingService m_schedulingService;
        private readonly IStudioService m_studioService;
        private readonly IBookingService m_bookingService;

        public ScheduleViewModel(ISchedulingService schedulingService, IBookingService bookingService, IStudioService studioService)
        {
            m_schedulingService = schedulingService;
            m_bookingService = bookingService;
            m_studioService = studioService;
        }

        public IList<Customer> Customers { get; set; } = default!;

        public IList<Scheduling> Schedulings { get; set; } = default!;

        public IList<Booking> Bookings { get; set; } = default!;

        public IList<Account> Accounts { get; set; } = default;
        public IList<Artist> Artishs { get; set; } = default;
        [BindProperty]
        public Guid studioID { get; set; }
        public IActionResult OnGet()
        {

            Guid userId = Guid.Parse(HttpContext.Session.GetString("AccountID"));
            var studio = m_studioService.GetStudioByAccountId(userId);
            studioID = studio.Id;
            if (userId == null || studio.Account.Role != "STAFF" || studioID == Guid.Empty)
            {
                return RedirectToPage("/LoginPage");
            }
            //studioID = Guid.Parse("C3F6CF3C-D089-4D12-BD78-2989B622B737");
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
            return OnGet();
        }
        public IActionResult OnGetBookingDone(Guid id, Guid studioid)
        {
            Booking curBooking = new Booking();
            curBooking = m_schedulingService.GetBookingByID(id);
            curBooking.Status = "DONE";
            m_schedulingService.UpdateBooking(curBooking);
            m_schedulingService.SaveChanges();
            ShowDataOnTable(studioid);
            return OnGet();
        }
        public IActionResult OnGetCancel(Guid id, Guid studioid)
        {
            Scheduling scheduling = new Scheduling();
            scheduling = m_schedulingService.GetById(id);
            scheduling.Status = "CANCEL";
            m_schedulingService.Update(scheduling);
            m_schedulingService.SaveChanges();
            ShowDataOnTable(studioid);


            return OnGet();
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
                List<Artist> ListGetArtish = new List<Artist>();

                Bookings = m_schedulingService.GetBookingByStudio(id);
                if (Bookings.Count > 0)
                {
                    foreach (var booking in Bookings)
                    {
                        Customer customer = m_schedulingService.GetCustomerByID(((Guid)booking.CustomerId));
                        listGetCus.Add(customer);
                        Account account = m_schedulingService.GetAccountByID((Guid)customer.AccountId);
                        listGetAcc.Add(account);
                        if (booking.ArtistId != null) 
                        { 
                            Artist artish = m_schedulingService.GetArtistById(((Guid)booking.ArtistId));
                            ListGetArtish.Add(artish);
                        }
                        else
                        {
                            Artist artish = new Artist { };
                            ListGetArtish.Add(artish);
                        }                        
                    }
                    Customers = listGetCus;
                    Accounts = listGetAcc;
                    Artishs = ListGetArtish;
                }
            }
            if (m_schedulingService.GetSchedulingByStudio(id) != null)
            {
                Schedulings = m_schedulingService.GetSchedulingByStudio(id);
            }
        }
    }
}
