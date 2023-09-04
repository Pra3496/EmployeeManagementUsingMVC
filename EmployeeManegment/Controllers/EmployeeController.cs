using Bussiness.Interface;
using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace EmployeeManegment.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeBussiness employeeBussiness;

        public EmployeeController(IEmployeeBussiness employeeBussiness)
        {
           
            this.employeeBussiness = employeeBussiness;
        }



        public IActionResult Index()
        {
            EmployeeModel employ = new EmployeeModel();
            try
            {
                var result = this.employeeBussiness.GetAllDataFromDataBase();

                if (result != null)
                {

                    return View(result);
                }
                else
                {

                    return RedirectToAction("Create");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeModel model)
        {
            EmployeeModel employ = new EmployeeModel();
            try
            {
                if (ModelState.IsValid)
                {
                    var result = this.employeeBussiness.CreateEmployee(model);


                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }




        [HttpGet]
        public IActionResult Edit(long? EmpId)
        {
            try
            {
                if (EmpId == null)
                {
                    return NotFound();
                }
                var result = this.employeeBussiness.GetAllDataFromDataBase();

                var employee = result.FirstOrDefault(x => x.EmpId == EmpId);

                if (result == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeModel model)
        {
            EmployeeModel employ = new EmployeeModel();
            try
            {
                if (ModelState.IsValid)
                {
                    var result = this.employeeBussiness.UpdateDatafromDatabase(model);


                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet]
        public IActionResult Details(long? EmpId)
        {
            try
            {
                if (EmpId == null)
                {
                    return NotFound();
                }
                var result = this.employeeBussiness.GetAllDataFromDataBase();

                var employee = result.FirstOrDefault(x => x.EmpId == EmpId);

                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        public IActionResult Delete(long EmpId)
        {
            if (EmpId == null)
            {
                return NotFound();
            }

            var result = this.employeeBussiness.GetAllDataFromDataBase();

            var employee = result.FirstOrDefault(x => x.EmpId == EmpId);
            

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(long EmpId)
        {
            try
            {
                if (EmpId == null)
                {
                    return NotFound();
                }

                bool result = this.employeeBussiness.DeleteDatafromDatabase(EmpId);

                if(result != false)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            
        }


    }
}
