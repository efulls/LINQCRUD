﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WEB_API_CRUD_LINQ_SQL.Models;

namespace WEB_API_CRUD_LINQ_SQL.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<newemp> empobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44325/api/empcrud");

            var consumeapi = hc.GetAsync("Empcrud");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if(readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<newemp>>();
                displaydata.Wait();
                empobj = displaydata.Result;
            }
            return View(empobj);
        }

        public ActionResult Details(int id)
        {
            EmpClass empobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44325/api/");

            var consumeapi = hc.GetAsync("Empcrud?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if(readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<EmpClass>();
                displaydata.Wait();
                empobj = displaydata.Result;
            }
            return View(empobj);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmpClass ec)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44325/api/Empcrud");

            var insertdata = hc.PostAsJsonAsync<EmpClass>("Empcrud", ec);
            insertdata.Wait();

            var savedata = insertdata.Result;
            if(savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Edit(int id)
        {
            EmpClass empobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44325/api/");

            var consumeapi = hc.GetAsync("Empcrud?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<EmpClass>();
                displaydata.Wait();
                empobj = displaydata.Result;
            }
            return View(empobj);
        }

        [HttpPost]
        public ActionResult Edit(EmpClass ec)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44325/api/Empcrud");

            var insertdata = hc.PutAsJsonAsync<EmpClass>("Empcrud", ec);
            insertdata.Wait();

            var savedata = insertdata.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(ec);

        }

        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44325/api/empcrud");

            var consumeapi = hc.DeleteAsync("Empcrud/"+id.ToString());
            consumeapi.Wait();

            var deleterecord = consumeapi.Result;
            if (deleterecord.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}