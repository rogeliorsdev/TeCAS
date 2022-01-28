using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TeCAS.SCA.Entities;
using TeCAS.SCA.Services.Operations;
using TeCAS.SCA.WebAdmin.Models;

namespace TeCAS.SCA.WebAdmin.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerOperations _helperCustomer;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerOperations helperCustomer, IMapper mapper)
        {
            _helperCustomer = helperCustomer;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<CustomerVM> GetCustomers()
        {
            var customers = _helperCustomer.GetAll();
            var customerVm = _mapper.Map<List<Customer>, List<CustomerVM>>(customers);

            return customerVm;
        }

        public IActionResult Edit(Guid id)
        {
            var tmp = _helperCustomer.RetrieveById(id);

            if(tmp != null)
            {
                var customerVM = _mapper.Map<CustomerVM>(tmp);
                return View("AddCustomer", customerVM);
            }

            return RedirectToAction("Index");
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveCustomer(CustomerVM customerVm)
        {
            string msgSuccess = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("AddCustomer", customerVm);
                }
                else
                {
                    var oCustomer = _mapper.Map<Customer>(customerVm);
                    
                    if(customerVm.Id == Guid.Empty)
                    {
                        _helperCustomer.Create(oCustomer);
                        msgSuccess = "El usuario se registró con éxito";
                    }
                    else
                    {
                        _helperCustomer.Update(oCustomer);
                        msgSuccess = "El usuario se actualizó con éxito";
                    }

                    ViewBag.messageSuccess = msgSuccess;
                }
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
                return View("AddCustomer", customerVm);
            }

            TempData["messageSuccess"] = msgSuccess;
            return RedirectToAction("Index");
        }
    }
}
