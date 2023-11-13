using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess;
using DataAccess.DataAccess;
using BusinessLogic.IService;
using Azure.Messaging;

namespace Presentaion.Pages.VipMembers
{
    public class RegisterVipMemberModel : PageModel
    {
        private readonly IVipmemberService _vipmemberService;
        private readonly ICustomerService _customerService;
        private readonly IStudioService _studioService;
        public RegisterVipMemberModel(IVipmemberService vipmemberService, ICustomerService customerService, IStudioService studioService)
        {
            _vipmemberService = vipmemberService;
            _customerService = customerService;
            _studioService = studioService;
        }
        [BindProperty(SupportsGet = true)]
        public Guid StudioId { get; set; }
        [BindProperty]
        public Customer Customer { get; set; }
        [BindProperty]
        public Studio Studio { get; set; }

        public IActionResult OnGet(Guid id)
        {

            var accId = HttpContext.Session.GetString("AccountID");
            if (accId == null)
            {
                return RedirectToPage("../LoginPage");
            }
            else
            {
                StudioId = id;
                Guid accountid = Guid.Parse(accId);
                var customer = _customerService.GetCusByAccountId(accountid);
                Customer = customer;
                //var studio = _studioService.GetStudioByAccountId(accountid);
                Studio = _studioService.GetById(StudioId);
                return Page();
            }          
        }

        [BindProperty]
        public VipMember VipMember { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            try
            {
                var accId = HttpContext.Session.GetString("AccountID");
                Guid accountid = Guid.Parse(accId);
                var customer = _customerService.GetCusByAccountId(accountid);
                Customer = customer;
                if (customer == null)
                {
                    throw new Exception("You are not customer");
                }
                else
                {
                    Guid newGuid = Guid.NewGuid();

                    VipMember = new VipMember
                    {
                        Id = newGuid,
                        StudioId = StudioId,
                        CustomerId = Customer.Id,
                    };
                    bool isVip = _vipmemberService.IsVip(customer.Id, StudioId);
                    if (isVip == true)
                    {
                        throw new Exception("You are already V.I.P in this studio");
                    }
                    var newvip = _vipmemberService.RegisterVip(customer.Id, StudioId,VipMember);
                    if (newvip == null)
                    {
                        throw new Exception("You have to participate at this studio at least once to register");
                    }
                    else
                    {
                        TempData["SuccessMessage"] = "Đăng kí thành công";
                        return Page();
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["notification"] = ex.Message.ToString();
            }
            return Page();
        }
    }
}
