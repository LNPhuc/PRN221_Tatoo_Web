﻿using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.VipMembers;

public class RegisterVipMemberModel : PageModel
{
    private readonly ICustomerService _customerService;
    private readonly IStudioService _studioService;
    private readonly IVipmemberService _vipmemberService;

    public RegisterVipMemberModel(IVipmemberService vipmemberService, ICustomerService customerService,
        IStudioService studioService)
    {
        _vipmemberService = vipmemberService;
        _customerService = customerService;
        _studioService = studioService;
    }

    [BindProperty(SupportsGet = true)] public Guid StudioId { get; set; }

    [BindProperty] public Customer Customer { get; set; }

    [BindProperty] public Studio Studio { get; set; }

    [BindProperty] public VipMember VipMember { get; set; }

    public IActionResult OnGet(Guid id)
    {
        var accId = HttpContext.Session.GetString("AccountID");
        if (accId == null) return RedirectToPage("../LoginPage");

        StudioId = id;
        var accountid = Guid.Parse(accId);
        var customer = _customerService.GetCusByAccountId(accountid);
        Customer = customer;
        //var studio = _studioService.GetStudioByAccountId(accountid);
        Studio = _studioService.GetById(StudioId);
        return Page();
    }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public IActionResult OnPost()
    {
        try
        {
            var accId = HttpContext.Session.GetString("AccountID");
            var accountid = Guid.Parse(accId);
            var customer = _customerService.GetCusByAccountId(accountid);
            Customer = customer;
            if (customer == null) throw new Exception("You are not customer");

            var newGuid = Guid.NewGuid();

            VipMember = new VipMember
            {
                Id = newGuid,
                StudioId = StudioId,
                CustomerId = Customer.Id
            };
            var isVip = _vipmemberService.IsVip(customer.Id, StudioId);
            if (isVip) throw new Exception("You are already V.I.P in this studio");
            var newvip = _vipmemberService.RegisterVip(customer.Id, StudioId, VipMember);
            if (newvip == null)
            {
                throw new Exception("You are not allowed to register");
            }

            ViewData["SuccessMessage"] = "Đăng kí thành công";
            return Page();
        }
        catch (Exception ex)
        {
            ViewData["notification"] = ex.Message;
        }

        return Page();
    }
}