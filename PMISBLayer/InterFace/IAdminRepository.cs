using PMISBLayer.DTOs;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PMISBLayer.InterFace
{
    public interface IAdminRepository
    {
        public List<ProjectManager> getallProjectManager();
        public Task InsertNewUser(InsertNewUserDTO userDTO);
        public ProjectManager getpromanagerbyid(string id);
        public void UpdateUser(UpdateUserDTO UpUDTO);
        public void DeleteUser(string id);
        public ProjectManager getpassbyid(string id);
        public Task UpdatePass(UpdatePassDTO UPDTO);


    }
}
