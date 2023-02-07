using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMISBLayer.DTOs;
using PMISBLayer.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class ProjectStatusController : Controller
    {
        private readonly IProjectStatusRepository statusRepo;
        public ProjectStatusController(IProjectStatusRepository statusRepo)
        {
            this.statusRepo = statusRepo;
        }
        public IActionResult Index()
        {
            try
            {
                ViewBag.Status = statusRepo.GetAllProjectStatuses();
                return View();
            }
            catch(Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }
        public IActionResult NewProjectStatus()
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
        public IActionResult InsertProjectStatus(InsertProjectStatusDTO proSDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    statusRepo.InsertProjectStatus(proSDTO);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("NewProjectStatus");
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }
        public IActionResult EditProjectStatus(int ProjectStatusId)
        {
            try
            {
                var s = statusRepo.EditProjectStatus(ProjectStatusId);
                return View(s);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }
        public IActionResult UpdateProjectStatus(UpdateProjectStatusDTO UpsDTO)
        {
            try
            {
                statusRepo.UpdateProjectStatus(UpsDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }
        public IActionResult DeleteProjectStatus(int ProjectStatusId)
        {
            try
            {
                statusRepo.DeleteProjectStatus(ProjectStatusId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }
    }
}
