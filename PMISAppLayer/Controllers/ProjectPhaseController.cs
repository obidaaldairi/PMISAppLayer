using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMISBLayer.DTOs;
using PMISBLayer.InterFace;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PMISAppLayer.Controllers
{
    [Authorize(Roles = "MANAGER")]
    public class ProjectPhaseController : Controller
    {
        private readonly IProjectRepository projectRepo;
        private readonly IProjectTypeRepository projectTypeRepo;
        private readonly IProjectStatusRepository projectStatusRepo;
        private readonly IPhaseRepository phaseRepo;
        private readonly IProjectPhaseRepository projectphaseRepo;

        public ProjectPhaseController(IProjectRepository projectRepo
           , IProjectTypeRepository projectTypeRepo,
           IProjectStatusRepository projectStatusRepo,
           IPhaseRepository phaseRepo,
           IProjectPhaseRepository projectphaseRepo)
        {
            this.projectRepo = projectRepo;
            this.projectTypeRepo = projectTypeRepo;
            this.projectStatusRepo = projectStatusRepo;
            this.phaseRepo = phaseRepo;
            this.projectphaseRepo = projectphaseRepo;
        }
        public IActionResult Index()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                ViewBag.projectPhases = projectphaseRepo.GetAllProjectPhaseManager(userId);
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }
        public IActionResult EditProjectPhase(int ProjectPhaseId)
        {
            try
            {
                var projectphase = projectphaseRepo.GetSingleProjectPhase(ProjectPhaseId);
                return View(projectphase);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }
        public IActionResult UpdateProjectPhase(UpdateProjectPhaseDTO NewpphDTO)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    projectphaseRepo.UpdateProjectPhase(NewpphDTO);
                    return RedirectToAction("Index");
                }
                else
                {
                    var projectphase = projectphaseRepo.GetSingleProjectPhase(NewpphDTO.ProjectPhaseId);
                    return View("EditProjectPhase", projectphase);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }

        public IActionResult DeleteProjectPhase(int ProjectPhaseId)
        {
            try
            {
                projectphaseRepo.DeleteProjectPhase(ProjectPhaseId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }


    }
}
