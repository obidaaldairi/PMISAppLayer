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
    public class InvoiceController : Controller
    {
        private readonly IProjectRepository projectRepo;
        private readonly IProjectTypeRepository projectTypeRepo;
        private readonly IProjectStatusRepository projectStatusRepo;
        private readonly IPhaseRepository phaseRepo;
        private readonly IProjectPhaseRepository projectphaseRepo;
        private readonly IDeliverableRepository deliverableRepo;
        private readonly IPaymentTermRepository paymentTermRepo;
        private readonly IInvoiceRepository InvoiceRepo;
        private readonly ApplicationDbContext context;

        public InvoiceController(IProjectRepository projectRepo
           , IProjectTypeRepository projectTypeRepo,
           IProjectStatusRepository projectStatusRepo,
           IPhaseRepository phaseRepo,
           IProjectPhaseRepository projectphaseRepo,
           IDeliverableRepository deliverableRepo,
           IPaymentTermRepository paymentTermRepo,
           IInvoiceRepository InvoiceRepo, ApplicationDbContext context)
        {
            this.projectRepo = projectRepo;
            this.projectTypeRepo = projectTypeRepo;
            this.projectStatusRepo = projectStatusRepo;
            this.phaseRepo = phaseRepo;
            this.projectphaseRepo = projectphaseRepo;
            this.deliverableRepo = deliverableRepo;
            this.paymentTermRepo = paymentTermRepo;
            this.InvoiceRepo = InvoiceRepo;
            this.context = context;
        }
        public IActionResult Index()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.Invoice = InvoiceRepo.GetAllInvoice(userId);
                return View();
            }
            catch(Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }

        }
        public IActionResult NewInvoice()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.project = InvoiceRepo.GetAllProject(userId);
                ViewBag.InvoicePmt = InvoiceRepo.getallinvoicePaymenttern(userId);
                return View();
            }
            catch(Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
            
        }
        public IActionResult InsertInvoice(InsertInvoiceDTO InvDTO)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    InvoiceRepo.InsertInvoice(InvDTO);
                    return RedirectToAction("Index");
                }
                else
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    ViewBag.project = InvoiceRepo.GetAllProject(userId);
                    ViewBag.InvoicePmt = InvoiceRepo.getallinvoicePaymenttern(userId);
                    return View("NewInvoice");
                }
                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
            
        }
        public JsonResult GetAllPaymentTermsByProjectId(int ProjectId)
        {
            var pmt = InvoiceRepo.GetAllPaymentTermsByProjectId(ProjectId);
            return new JsonResult(pmt);
        }

        public IActionResult EditInvoice(int InvoiceId , int ProjectId)
        {
            try
            {
                var Invoice = InvoiceRepo.EditInvoice(InvoiceId);
                ViewBag.pmtbyinvid = InvoiceRepo.getpmtbyinvId(InvoiceId);

                return View(Invoice);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
            
        }
        public IActionResult UpdateInvoice(UpdateInvoiceDTO UpInvDTO)
        {
            try
            {
                InvoiceRepo.UpdateInvoice(UpInvDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
            
        }
        public IActionResult DeleteInvoice(int InvoiceId)
        {
            try
            {
                InvoiceRepo.DeleteInvoice(InvoiceId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
            
        }


        public IActionResult ShowInvoice(int id)
        {
            var invoice = InvoiceRepo.GetInvoiceById(id);

            return View(invoice);
        }
    }
}
