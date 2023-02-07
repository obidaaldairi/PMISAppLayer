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
    public class PhaseController : Controller
    {
        private readonly IPhaseRepository phaseRepo;
        public PhaseController(IPhaseRepository phaseRepo)
        {
            this.phaseRepo = phaseRepo;
        }
        public IActionResult Index()
        {
            ViewBag.phase = phaseRepo.GetAllPhases();
            return View();
        }
        public IActionResult NewPhase()
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
        public IActionResult InsertPhase(InsertPhaseDTO2 phDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    phaseRepo.InsertPhase(phDTO);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("NewPhase");
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }
        public IActionResult EditPhase(int PhaseId)
        {
            try
            {
                var ph = phaseRepo.EditPhase(PhaseId);
                return View(ph);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }
        public IActionResult UpdatePhase(UpdatePhaseDTO2 UpphDTO)
        {
            try
            {
                phaseRepo.UpdatePhase(UpphDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }
        public IActionResult DeletePhase(int PhaseId)
        {
            try
            {
                phaseRepo.DeletePhase(PhaseId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }
    }
}
