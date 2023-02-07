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
    public class DeliverableController : Controller
    {
        private readonly IProjectRepository projectRepo;
        private readonly IProjectTypeRepository projectTypeRepo;
        private readonly IProjectStatusRepository projectStatusRepo;
        private readonly IPhaseRepository phaseRepo;
        private readonly IProjectPhaseRepository projectphaseRepo;
        private readonly IDeliverableRepository deliverableRepo;

        public DeliverableController(IProjectRepository projectRepo
           , IProjectTypeRepository projectTypeRepo,
           IProjectStatusRepository projectStatusRepo,
           IPhaseRepository phaseRepo,
           IProjectPhaseRepository projectphaseRepo , IDeliverableRepository deliverableRepo)
        {
            this.projectRepo = projectRepo;
            this.projectTypeRepo = projectTypeRepo;
            this.projectStatusRepo = projectStatusRepo;
            this.phaseRepo = phaseRepo;
            this.projectphaseRepo = projectphaseRepo;
            this.deliverableRepo = deliverableRepo;
        }
        public IActionResult Index()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                ViewBag.Deliverable = deliverableRepo.GetAllDeliverable(userId);

                return View();
            }
            catch(Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }
        public IActionResult NewDelivrable()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                ViewBag.ProjectPhase = deliverableRepo.GetProjectPhase(userId);
                return View();
            }
            catch (Exception ex)
            {

                return RedirectToAction("Privacy", "Home");

            }
        }

        public IActionResult InsertDeliverable(InsertDelivrableDTO delivrableDTO)
        {
            try
            {

                if(ModelState.IsValid)
                {
                    var projectphase = projectphaseRepo.GetSingleProjectPhase(delivrableDTO.ProjectPhaseId);
                    if (delivrableDTO.DeliStartDate >= projectphase.StartDate && delivrableDTO.DeliEndDate <= projectphase.EndDate)
                    {
                        deliverableRepo.InsertDeliverable(delivrableDTO);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.msg = false;
                        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                        ViewBag.ProjectPhase = deliverableRepo.GetProjectPhase(userId);
                        return View("NewDelivrable");

                    }
                }
                else
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    ViewBag.ProjectPhase = deliverableRepo.GetProjectPhase(userId);
                    return View("NewDelivrable");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }

        public IActionResult EditDeliverable(int DeliverableId)
        {
            try
            {
                var deliv = deliverableRepo.EditDeliverable(DeliverableId);
                return View(deliv);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }

        public IActionResult UpdateDeliverable(UpdateDeliverableDTO UpDelivDTO)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    deliverableRepo.UpdateDeliverable(UpDelivDTO);
                    return RedirectToAction("Index");
                }
                else
                {
                    var deliv = deliverableRepo.EditDeliverable(UpDelivDTO.DeliverableId);
                    return View("EditDeliverable", deliv);
                }
                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }
        public IActionResult DeleteDeliverable(int DeliverableId)
        {
            try
            {
                deliverableRepo.DeleteDeliverable(DeliverableId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }

       
        public JsonResult GetDate(int ProjectPhaseId)
        {
            var date = deliverableRepo.GetDate(ProjectPhaseId);
            return new JsonResult(date);
        }
    }
}
