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
    public class ClientController : Controller
    {
        private readonly IClientRepository ClientRepo;
        public ClientController(IClientRepository ClientRepo)
        {
            this.ClientRepo = ClientRepo;
        }
        public IActionResult Index()
        {
            try
            {
                ViewBag.client = ClientRepo.GetAllClients();
                return View();
            }
            catch(Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
            
        }
        public IActionResult NewClient()
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
        public IActionResult InsertClient(InsertClientDTO CliDTO)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    ClientRepo.InsertClient(CliDTO);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("NewClient");
                }
                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }
        public IActionResult EditClient(int ClientId)
        {
            try
            {
                var c = ClientRepo.EditClient(ClientId);
                return View(c);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }
        public IActionResult UpdateCLient(UpdateCLient UpCDTO)
        {
            try
            {
                ClientRepo.UpdateCLient(UpCDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");

            }
        }
        public IActionResult DeleteClient(int ClientId)
        {
            try
            {
                ClientRepo.DeleteClient(ClientId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }
    }
}
