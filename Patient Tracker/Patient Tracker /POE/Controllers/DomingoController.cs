using DomingoRoofWorks.Models;
using DomingoRoofWorks.Respiratory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace DomingoRoofWorks.Controllers
{
    public class DomingoController : Controller
    {
        //Get; View all the Job cards
        public ActionResult GetAllJobCards()
        {
            JobCardRespiratory JobCardRepo = new JobCardRespiratory();
            ModelState.Clear();
            return View(JobCardRepo.GetAllJobCards());

        }


        //Get; View all the Employee Information
        public ActionResult GetAllEmployees()
        {
            EmployeeRespiratory EmployeeRepo = new EmployeeRespiratory();
            ModelState.Clear();
            return View(EmployeeRepo.GetAllEmployees());

        }

        //Get; View all the invoice Information
        public ActionResult GetAllInvoices()
        {
            InvoiceRespiratory InvoiceRepo = new InvoiceRespiratory();
            ModelState.Clear();
            return View(InvoiceRepo.GetAllInvoices());

        }

        //Get: Job_Cards / Return Job_Cards view

        public ActionResult AddJobCard()
        {
            return View();
        }


        //Get: Employee/ Return employee view

        public ActionResult AddEmployee()
        {
            return View();
        }

        //Get: Invoice / Return Invoice view

        public ActionResult AddInvoice()
        {
            return View();
        }

        //POST: Job_Cards /Add Job_Cards  
        [HttpPost]
        public ActionResult AddJobCard(JobCardModel Job)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JobCardRespiratory JobCardRepo = new JobCardRespiratory();
                    if (JobCardRepo.AddJobCard(Job))
                    {
                        ViewBag.Message = "Job card details successfully added ";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //POST: Employee/Add Employee 
        [HttpPost]
        public ActionResult AddEmployee(EmployeeModel Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRespiratory EmployeeRepo = new EmployeeRespiratory();
                    if (EmployeeRepo.AddEmployee(Emp))
                    {
                        ViewBag.Message = "Employee details successfully added ";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        //POST: Invoice/Add Invoice 
        [HttpPost]
        public ActionResult AddInvoice(Models.InvoiceModel Invoice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InvoiceRespiratory InvoiceRepo = new InvoiceRespiratory();
                    if (InvoiceRepo.AddInvoice(Invoice))
                    {
                        ViewBag.Message = "Employee details successfully added ";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //Get: Employee / Edit Employee Details

        public ActionResult EditJobCard(int JobCardId)
        {
            JobCardRespiratory JobCardRepo = new JobCardRespiratory();
            return View(JobCardRepo.GetAllJobCards().Find(Job => Job.JobCardId == JobCardId));
        }

        //Get: Employee / Edit Employee Details

        public ActionResult EditEmployee(String EmployeeId)
        {
            EmployeeRespiratory EmployeeRepo = new EmployeeRespiratory();
            return View(EmployeeRepo.GetAllEmployees().Find(Emp => Emp.EmpId == EmployeeId));
        }

        //Get: Invoice / Edit Invoice Details

        public ActionResult EditInvoice(int JobCardId)
        {
            InvoiceRespiratory InvoiceRepo = new InvoiceRespiratory();
            return View(InvoiceRepo.GetAllInvoices().Find(Invoice => Invoice.JobCardId == JobCardId));
        }


        //POST: job cards /Update existing Job_Card 
        [HttpPost]
        public ActionResult EditJobCard(int JobCardId, JobCardModel obj)
        {
            try
            {
                JobCardRespiratory JobCardRepo = new JobCardRespiratory();
                JobCardRepo.UpdateJobCard(obj);

                return RedirectToAction("Get all Job_Cards ");
            }
            catch
            {
                return View();
            }
        }


        //POST: Employee/Update existing Employee 
        [HttpPost]
        public ActionResult EditEmployee(string EmployeeId, EmployeeModel obj)
        {
            try
            {
                EmployeeRespiratory EmployeeRepo = new EmployeeRespiratory();
                EmployeeRepo.UpdateEmployee(obj);

                return RedirectToAction("Get all Employees");
            }
            catch
            {
                return View();
            }
        }




        //POST: Invoice/Update existing Invoice 
        [HttpPost]
        public ActionResult EditInvoice(int JobCardId, Models.InvoiceModel obj)
        {
            try
            {
                InvoiceRespiratory InvoiceRepo = new InvoiceRespiratory();
                InvoiceRepo.UpdateInvoice(obj);

                return RedirectToAction("Get all Employees");
            }
            catch
            {
                return View();
            }
        }


        //Get: Job_Cards  / Delete existing Job_Cards 
        public ActionResult DeleteJobCard(int JobCardId)
        {
            try
            {
                JobCardRespiratory JobCardRepo = new JobCardRespiratory();
                if (JobCardRepo.DeleteJobCard(JobCardId))
                {
                    ViewBag.AlerMag = "Job_Cards details successfully deleted.  ";
                }
                return RedirectToAction("Get All Employees");
            }
            catch
            {
                return View();
            }
        }

        //Get: Employee / Delete existing Employee
        public ActionResult DeleteEmployee(string EmployeeId)
        {
            try
            {
                EmployeeRespiratory EmployeeRepo = new EmployeeRespiratory();
                if (EmployeeRepo.DeleteEmployee(EmployeeId))
                {
                    ViewBag.AlerMag = "Employee details successfully deleted.  ";
                }
                return RedirectToAction("Get All Employees");
            }
            catch
            {
                return View();
            }
        }


        //Get: Invoice / Delete existing Invoice
        public ActionResult DeleteInvoice(int JobCardId)
        {
            try
            {
                InvoiceRespiratory InvoiceRepo = new InvoiceRespiratory();
                if (InvoiceRepo.DeleteInvoice(JobCardId))
                {
                    ViewBag.AlerMag = "Employee details successfully deleted.  ";
                }
                return RedirectToAction("Get All Employees");
            }
            catch
            {
                return View();
            }
        }


    }
}
