using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MV5CApplication.Models;

namespace MV5CApplication.Controllers
{
	public class BankAccountController : Controller
	{
		// GET: BankAccount
		public ActionResult Index()
		{
			var aAccount = new BankAccount(5,new EventLog());
			return View(aAccount);
		}

		// GET: BankAccount/Details/5
		public ActionResult Deposit()
		{
			var aAccount = new BankAccount(5, new EventLog());
			return View(aAccount);
		}

		// GET: BankAccount/Create
		public ActionResult Withdrawal()
		{
			var aAccount = new BankAccount(5, new EventLog());
			return View(aAccount);
		}

		// POST: BankAccount/Create
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: BankAccount/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: BankAccount/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: BankAccount/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: BankAccount/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
