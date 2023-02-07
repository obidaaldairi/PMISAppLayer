using PMISBLayer.DTOs;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.InterFace
{
    public interface IClientRepository
    {
        public List<Client> GetAllClients();
        public void InsertClient(InsertClientDTO CliDTO);
        public Client EditClient(int ClientId);
        public void UpdateCLient(UpdateCLient UpCDTO);
        public void DeleteClient(int ClientId);


    }
}
