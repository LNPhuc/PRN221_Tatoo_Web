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

        public RegisterVipMemberModel(IVipmemberService vipmemberService, ICustomerService customerService)
        {
            _vipmemberService = vipmemberService;
            _customerService = customerService;
        }
        [BindProperty(SupportsGet = true)]
        public Guid StudioId { get; set; }
        [BindProperty]
        public Customer Customer { get; set; }

        public string Name { get; set; }

        public IActionResult OnGet(Guid id)
        {
            StudioId = id;
            var accId = HttpContext.Session.GetString("AccountID");
            Guid accountid = Guid.Parse(accId);
            var customer = _customerService.GetCusByAccountId(accountid);
            Customer = customer;
            return Page();
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

                    var newvip = _vipmemberService.RegisterVip(customer.Id, VipMember);
                    if (newvip == null)
                    {
                        throw new Exception("You are not allowed to register");
                    }
                    else
                    {
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
