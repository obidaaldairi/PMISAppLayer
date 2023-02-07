using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PMISBLayer.DTOs;
using PMISBLayer.Entities;
using PMISBLayer.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.Controllers
{
    [Authorize(Roles ="ADMIN")]
    public class AdminController : Controller
    {
        private readonly IAdminRepository AdminRepo;
        public AdminController(IAdminRepository AdminRepo)
        {
            this.AdminRepo = AdminRepo;
        }
        public IActionResult Index()
        {
            try
            {
                ViewBag.manager = AdminRepo.getallProjectManager();
                return View();
            }
            catch(Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
            
        }
        public IActionResult NewUser()
        {
            try
            {
                return View();

            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }
        public async Task<IActionResult> InsertNewUser(InsertNewUserDTO userDTO)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await AdminRepo.InsertNewUser(userDTO);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("NewUser");
                }
                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
            
        }
        public IActionResult EditUser(string id)
        {
            try
            {
               var u = AdminRepo.getpromanagerbyid(id);
                return View(u);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
            
        }
        public IActionResult EditPass(string id)
        {
            var p = AdminRepo.getpassbyid(id);
            return View(p);
        }
        public async Task<IActionResult> UpdatePass(UpdatePassDTO UPDTO)
        {
            await AdminRepo.UpdatePass(UPDTO);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateUser(UpdateUserDTO UpUDTO)
        {
            try
            {
                AdminRepo.UpdateUser(UpUDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
            
        }
        public IActionResult DeleteUser(string id)
        {
            try
            {
                AdminRepo.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }

    }
}
