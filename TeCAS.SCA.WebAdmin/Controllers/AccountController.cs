using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Collections.Generic;
using TeCAS.SCA.Entities;
using TeCAS.SCA.Services.Operations;
using TeCAS.SCA.WebAdmin.Models;
using static TeCAS.SCA.Entities.Enumerations.EnumerationLists;

namespace TeCAS.SCA.WebAdmin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountOperations _helperAccount;
        private readonly IMapper _mapper;

        public AccountController(IAccountOperations helperAccount, IMapper mapper)
        {
            _helperAccount = helperAccount;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult ListAccount()
        {
            return View();
        }

        //public List<AccountVM> GetAccounts()
        //{
        //    var customers = _helperAccount.GetAll();
        //    var customerVm = _mapper.Map<List<Account>, List<AccountVM>>(customers);

        //    return customerVm;
        //}

        public IActionResult AddAccount(Guid id)
        {
            //var tmp = _helperAccount.RetrieveByCustomerId(id);
            var TypeAccount = from TypeAccount e in Enum.GetValues(typeof(TypeAccount))
                              select new
                              {
                                  Id = (int)e,
                                  Name = e.ToString()
                              };
            ViewBag.TypeAccount = new SelectList(TypeAccount, "Id", "Name");
            //if (tmp == null)
            //{
            //    ViewBag.TypeAccount = new SelectList(TypeAccount, "Id", "Name");
            //    return View();
            //}

            //ViewBag.TypeAccount = new SelectList(TypeAccount, "Id", "Name", tmp.TypeAccount);
            ViewBag.customerId = id;
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            var tmp = _helperAccount.RetrieveById(id);

            if (tmp != null)
            {
                var TypeAccount = from TypeAccount e in Enum.GetValues(typeof(TypeAccount))
                                  select new
                                  {
                                      Id = (int)e,
                                      Name = e.ToString()
                                  };
                ViewBag.TypeAccount = new SelectList(TypeAccount, "Id", "Name", tmp.TypeAccount);
                var accountVM = _mapper.Map<AccountVM>(tmp);
                ViewBag.customerId = tmp.CustomerId;
                return View("AddAccount", accountVM);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAccount(AccountVM accountVm)
        {
            string msgSuccess = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("AddAccount", accountVm);
                }
                else
                {
                    var oAccount = _mapper.Map<Account>(accountVm);

                    if (accountVm.Id == Guid.Empty)
                    {
                        _helperAccount.Create(oAccount);
                        msgSuccess = "La cuenta se registró con éxito";
                    }
                    else
                    {
                        _helperAccount.Update(oAccount);
                        msgSuccess = "La cuenta se actualizó con éxito";
                    }

                    ViewBag.messageSuccess = msgSuccess;
                }
            }
            catch (Exception ex)
            {
                var TypeAccount = from TypeAccount e in Enum.GetValues(typeof(TypeAccount))
                                  select new
                                  {
                                      Id = (int)e,
                                      Name = e.ToString()
                                  };
                ViewBag.TypeAccount = new SelectList(TypeAccount, "Id", "Name", accountVm.TypeAccount);
                ViewBag.MessageError = ex.Message;
                ViewBag.customerId = accountVm.CustomerId;
                return View("AddAccount", accountVm);
            }

            TempData["messageSuccess"] = msgSuccess;
            return RedirectToAction("Index");
        }

        public List<AccountVM> GetAccounts()
        {
            var accounts = _helperAccount.GetAllComplete();
            var accountVm = _mapper.Map<List<Account>, List<AccountVM>>(accounts);

            return accountVm;
        }
    }
}
