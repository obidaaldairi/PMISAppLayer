using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMISAppLayer;
using PMISBLayer.DTOs;
using PMISBLayer.Entities;
using PMISBLayer.InterFace;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PMISAppLayer.Controllers
{
    //[Authorize]
    [Authorize(Roles = "MANAGER")]

    public class ProjectController : Controller
    {
        private readonly IProjectRepository projectRepo;
        private readonly IProjectTypeRepository projectTypeRepo;
        private readonly IProjectStatusRepository projectStatusRepo;
        private readonly IClientRepository clientRepo;
        private readonly IPhaseRepository phaseRepo;
        private readonly IProjectPhaseRepository projectphaseRepo;
        public ProjectController(IProjectRepository projectRepo
            , IProjectTypeRepository projectTypeRepo ,
            IProjectStatusRepository projectStatusRepo,
            IPhaseRepository phaseRepo,
            IProjectPhaseRepository projectphaseRepo,
             IClientRepository clientRepo)
        {
            this.projectRepo = projectRepo;
            this.projectTypeRepo = projectTypeRepo;
            this.projectStatusRepo = projectStatusRepo;
            this.phaseRepo = phaseRepo;
            this.projectphaseRepo = projectphaseRepo;
            this.clientRepo = clientRepo;
        }
        public IActionResult Index()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                ViewBag.projects = projectRepo.GetProjectManagerProjects(userId).ToList();
            }
            catch(Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
            return View();


        }
        public IActionResult NewProject()
        {
            try
            {
                ViewBag.projectTypes = projectTypeRepo.GetAllProjectType();
                ViewBag.projectStatuses = projectStatusRepo.GetAllProjectStatuses();
                ViewBag.clients = clientRepo.GetAllClients();
                //ViewBag.phases = phaseRepo.GetAllPhases();
            }
            catch(Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
            
            return View();
        }
        [HttpPost]
        public IActionResult InsertProject(InsertProjectDTO projectDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Project project = new Project();
                    project.ProjectName = projectDTO.ProjectName;
                    project.ContractAmount = projectDTO.ContractAmount;
                    project.StartDate = projectDTO.StartDate;
                    project.EndDate = projectDTO.EndDate;
                    project.ProjectTypeId = projectDTO.ProjectTypeId;
                    project.ProjectStatusId = projectDTO.ProjectStatusId;
                    project.ClientId = projectDTO.ClientId;
                    project.ContractFileName = projectDTO.ContractFile.FileName;
                    project.ContractFileType = projectDTO.ContractFile.ContentType;


                    project.ProjectManagerId = User.FindFirstValue(ClaimTypes.NameIdentifier);


                    if (projectDTO.ContractFile.Length > 0)
                    {
                        Stream st = projectDTO.ContractFile.OpenReadStream();

                        using (BinaryReader br = new BinaryReader(st))
                        {
                            var byteFile = br.ReadBytes((int)st.Length);
                            project.ContractFile = byteFile;

                            projectRepo.InsertProject(project);
                        }
                    }
                    //foreach (var pp in projectDTO.PhaseIds)
                    //{
                    //    ProjectPhase projectPhase = new ProjectPhase();

                    //    projectPhase.ProjectId = project.ProjectId;
                    //    projectPhase.PhaseId = pp;

                    //    projectphaseRepo.InsertProjectPhase(projectPhase);

                    //}


                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.projectTypes = projectTypeRepo.GetAllProjectType();
                    ViewBag.projectStatuses = projectStatusRepo.GetAllProjectStatuses();
                    ViewBag.clients = clientRepo.GetAllClients();
                    return View("NewProject");
                }
            }
            catch(Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }


        }
        public FileStreamResult ViewContract(int ProjectId)     
        {
            var project = projectRepo.GettProject(ProjectId);

            Stream stream = new MemoryStream(project.ContractFile); 
            return new FileStreamResult(stream, project.ContractFileType); 
        }

        public IActionResult EditProject(int ProjectId)
        {
            try
            {
                var pro = projectRepo.EditProject(ProjectId);

                ViewBag.projectStatus = projectStatusRepo.GetAllProjectStatuses();

                ViewBag.projectType = projectTypeRepo.GetAllProjectType();

                ViewBag.client = clientRepo.GetAllClients();

                //ViewBag.phase = phaseRepo.GetAllPhases();

                //ViewBag.projectPhase = projectphaseRepo.EditProjectPhase(ProjectId);
                return View(pro);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
           
        }

        public IActionResult UpdateProject(UpdateProjectDTO UprojectDTO)
        {
            try
            {
                projectRepo.UpdeteProject(UprojectDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }

        public IActionResult DeleteProject(int ProjectId)
        {
            try
            {
                projectRepo.DeleteProject(ProjectId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }

        }
        //**********************************************************************************
        public IActionResult NewPhase(int ProjectId)
        {
            try
            {
                ViewBag.project = projectRepo.GettProject(ProjectId);
                ViewBag.phases = phaseRepo.GetAllPhases();
                ViewBag.projectPhase = projectphaseRepo.getallprojectPhase(ProjectId);
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }
        public IActionResult InsertPhase(InsertPhaseDTO phaseDTO)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    projectphaseRepo.InsertPhase(phaseDTO);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.project = projectRepo.GettProject(phaseDTO.ProjectId);
                    ViewBag.phases = phaseRepo.GetAllPhases();
                    ViewBag.projectPhase = projectphaseRepo.getallprojectPhase(phaseDTO.ProjectId);
                    return View("NewPhase");
                }
                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }
    }
}
