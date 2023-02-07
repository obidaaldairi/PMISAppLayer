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
    public class ProjectTypeController : Controller
    {
        private readonly IProjectTypeRepository typeRepo;
        public ProjectTypeController(IProjectTypeRepository typeRepo)
        {
            this.typeRepo = typeRepo;
        }
        public IActionResult Index()
        {
            try
            {
                ViewBag.Type = typeRepo.GetAllProjectType();
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }
        public IActionResult NewProjectType()
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
        public IActionResult InsertProjectType(InsertProjectTypeDTO ptDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    typeRepo.InsertProjectType(ptDTO);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("NewProjectType");
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }
        public IActionResult EditProjectType(int ProjectTypeId)
        {
            try
            {
                var s = typeRepo.EditProjectType(ProjectTypeId);
                return View(s);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }
        public IActionResult UpdateProjectType(UpdateProjectTypeDTO UptDTO)
        {
            try
            {
                typeRepo.UpdateProjectType(UptDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }
        public IActionResult DeleteProjectType(int ProjectTypeId)
        {
            try
            {
                typeRepo.DeleteProjectType(ProjectTypeId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }
    }
}
