using Microsoft.AspNetCore.Identity;
using PMISBLayer.Data;
using PMISBLayer.DTOs;
using PMISBLayer.Entities;
using PMISBLayer.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMISBLayer.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<Person> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AdminRepository(ApplicationDbContext context,
             UserManager<Person> userManager
            , RoleManager<IdentityRole> roleManager
            )
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;

        }
        public List<ProjectManager> getallProjectManager()
        {
            return context.ProjectManagers.ToList();
        }
        public async Task InsertNewUser(InsertNewUserDTO userDTO)
        {

            var user = new ProjectManager();
            user.FullName = userDTO.FullName;
            user.PhoneNumber = userDTO.PhoneNumber;
            user.Email = userDTO.Email;
            user.UserName = userDTO.Email;
            user.EmailConfirmed = true;

            var result = await userManager.CreateAsync(user, userDTO.Password);
            var s = await userManager.AddToRoleAsync(user , "MANAGER");
        }
        public ProjectManager getpromanagerbyid(string id)
        {
            return context.ProjectManagers.SingleOrDefault(x => x.Id == id);
        }
        public ProjectManager getpassbyid(string id)
        {
            return context.ProjectManagers.SingleOrDefault(x => x.Id == id);
        }
        public async Task UpdatePass(UpdatePassDTO UPDTO)
        {
            var luser = context.ProjectManagers.SingleOrDefault(x => x.Id == UPDTO.Id);
            var changePassword = await userManager.ChangePasswordAsync(luser, UPDTO.OldPassword, UPDTO.NewPassword);
            context.SaveChanges();
        }
        public void UpdateUser(UpdateUserDTO UpUDTO)
        {
            var luser = context.ProjectManagers.SingleOrDefault(x => x.Id == UpUDTO.Id);
            luser.FullName = UpUDTO.FullName;
            luser.PhoneNumber = UpUDTO.PhoneNumber;
            context.SaveChanges();
        }
        public void DeleteUser(string id)
        {
            var pm = context.ProjectManagers.SingleOrDefault(x => x.Id == id);
            context.ProjectManagers.Remove(pm);
            context.SaveChanges();

        }

    }
}
