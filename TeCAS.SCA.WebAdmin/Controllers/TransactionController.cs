using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TeCAS.SCA.Entities;
using TeCAS.SCA.Services.Operations;
using TeCAS.SCA.WebAdmin.Models;

namespace TeCAS.SCA.WebAdmin.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionOperations _helperTransaction;
        private readonly IAccountOperations _helperAccount;
        private readonly IMapper _mapper;

        public TransactionController(ITransactionOperations helperTransaction, 
            IAccountOperations helperAccount, IMapper mapper)
        {
            _helperTransaction = helperTransaction;
            _helperAccount = helperAccount;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DepositMoney()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DepositMoney(TransactionMoneyVM oTransactionVm)
        {
            string msgSuccess = "";
            try
            {
                _helperTransaction.DepositMoney(oTransactionVm.NoAccount, oTransactionVm.Amount);
                msgSuccess = "El depósito se registró con éxito";
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
                return View(oTransactionVm);
            }

            TempData["messageSuccess"] = msgSuccess;
            return RedirectToAction("Index");
        }

        public List<TransactionVM> GetTransactions()
        {
            var transactions = _helperTransaction.GetAllComplete();
            var transactionVm = _mapper.Map<List<Transaction>, List<TransactionVM>>(transactions);

            return transactionVm;
        }

        [HttpGet]
        public IActionResult HaveMoney()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HaveMoney(TransactionMoneyVM oTransactionVm)
        {
            string msgSuccess = "";
            try
            {
                _helperTransaction.HaveMoney(oTransactionVm.NoAccount, oTransactionVm.Amount);
                msgSuccess = "El retiro se realizó con éxito";
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
                return View(oTransactionVm);
            }

            TempData["messageSuccess"] = msgSuccess;
            return RedirectToAction("Index");
        }
    }
}
