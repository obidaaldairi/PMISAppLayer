using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
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
    public class PaymentTermController : Controller
    {
        private readonly IProjectRepository projectRepo;
        private readonly IProjectTypeRepository projectTypeRepo;
        private readonly IProjectStatusRepository projectStatusRepo;
        private readonly IPhaseRepository phaseRepo;
        private readonly IProjectPhaseRepository projectphaseRepo;
        private readonly IDeliverableRepository deliverableRepo;
        private readonly IPaymentTermRepository paymentTermRepo;
        private readonly ApplicationDbContext context;

        public PaymentTermController(IProjectRepository projectRepo
           , IProjectTypeRepository projectTypeRepo,
           IProjectStatusRepository projectStatusRepo,
           IPhaseRepository phaseRepo,
           IProjectPhaseRepository projectphaseRepo,
           IDeliverableRepository deliverableRepo,
           IPaymentTermRepository paymentTermRepo, ApplicationDbContext context)
        {
            this.projectRepo = projectRepo;
            this.projectTypeRepo = projectTypeRepo;
            this.projectStatusRepo = projectStatusRepo;
            this.phaseRepo = phaseRepo;
            this.projectphaseRepo = projectphaseRepo;
            this.deliverableRepo = deliverableRepo;
            this.paymentTermRepo = paymentTermRepo;
            this.context = context;
        }
        public IActionResult Index()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.PaymentTerm = paymentTermRepo.GetAllPaymentTerm(userId);
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }
        public IActionResult NewPaymentTerm()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var del = paymentTermRepo.GetDeliverables(userId);
                ViewBag.Deliv = del;
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }
        public IActionResult InsertPaymentTerm(InsertPaymentTermDTO pmtDTO)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var dev = paymentTermRepo.getdeliv(pmtDTO);
                    decimal num = 0;
                    var pays = context.PaymentTerms
                        .Include(p => p.Deliverable.ProjectPhase)
                        .Include(q => q.Deliverable.ProjectPhase.Project)
                        .Where(y => y.Deliverable.ProjectPhase.ProjectId == dev.ProjectPhase.ProjectId)
                        .ToList();
                    foreach (var item in pays)
                    {
                        num = num + item.PaymentTermAmount;
                    }
                    num = num + pmtDTO.PaymentTermAmount;
                    if (num <= dev.ProjectPhase.Project.ContractAmount)
                    {
                        paymentTermRepo.InsertPaymentTerm(pmtDTO);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                        var del = paymentTermRepo.GetDeliverables(userId);
                        ViewBag.Deliv = del;
                        ViewBag.msg = false;
                        return View("NewPaymentTerm");
                    }
                }
                else
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var del = paymentTermRepo.GetDeliverables(userId);
                    ViewBag.Deliv = del;
                    return View("NewPaymentTerm");
                }
                

            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }
        public IActionResult EditPaymentTerm(int PaymentTermId)
        {
            try
            {
                var pmt = paymentTermRepo.EditPaymentTerm(PaymentTermId);
                return View(pmt);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }
        public JsonResult GetIsNotInovicePayment(int id)
        {
            var pmt = paymentTermRepo.GetIsNotInovicePayment(id);
            return new JsonResult(pmt);
        }
        public IActionResult UpdatePaymentTerm(UpdatePaymentTermDTO UpPmtDTO)
        {
            try
            {
                var lpmt = context.PaymentTerms
                    .Include(q => q.Deliverable)
                    .Include(p => p.Deliverable.ProjectPhase)
                    .Include(q => q.Deliverable.ProjectPhase.Project)
                    .SingleOrDefault(x => x.PaymentTermId == UpPmtDTO.PaymentTermId);
                decimal num = 0;
                var pays = context.PaymentTerms
                    .Include(t => t.Deliverable)
                    .Include(p => p.Deliverable.ProjectPhase)
                    .Include(q => q.Deliverable.ProjectPhase.Project)
                    .Where(y => y.Deliverable.ProjectPhase.ProjectId == lpmt.Deliverable.ProjectPhase.ProjectId)
                    .ToList();

                lpmt.PaymentTermTitle = UpPmtDTO.PaymentTermTitle;
                lpmt.PaymentTermAmount = UpPmtDTO.PaymentTermAmount;
                foreach (var item in pays)
                {
                    num = num + item.PaymentTermAmount;
                }
                num = num + 0;
                if (num <= lpmt.Deliverable.ProjectPhase.Project.ContractAmount)
                {
                    paymentTermRepo.UpdatePaymenet(lpmt);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.msg = false;
                    return View("EditPaymentTerm" , lpmt);
                }

               
                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }
        public IActionResult DeletePaymentTerm(int PaymentTermId)
        {
            try
            {
                paymentTermRepo.DeletePaymentTerm(PaymentTermId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }
    }
}
