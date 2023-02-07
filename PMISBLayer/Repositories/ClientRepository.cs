using PMISBLayer.Data;
using PMISBLayer.DTOs;
using PMISBLayer.Entities;
using PMISBLayer.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext context;
        public ClientRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Client> GetAllClients()
        {
            return context.Clients.ToList();
        }
        public void InsertClient(InsertClientDTO CliDTO)
        {
            var c = new Client();
            c.ClientName = CliDTO.ClientName;
            c.ClientPhone = CliDTO.ClientPhone;
            c.ClientEmail = CliDTO.ClientEmail;
            c.Address = CliDTO.Address;
            context.Clients.Add(c);
            context.SaveChanges();
        }
        public Client EditClient(int ClientId)
        {
            return context.Clients.SingleOrDefault(x => x.ClientId == ClientId);
        }
        public void UpdateCLient(UpdateCLient UpCDTO)
        {
            var lClient = context.Clients.SingleOrDefault(x => x.ClientId == UpCDTO.ClientId);
            lClient.ClientName = UpCDTO.ClientName;
            lClient.ClientPhone = UpCDTO.ClientPhone;
            lClient.ClientEmail = UpCDTO.ClientEmail;
            lClient.Address = UpCDTO.Address;
            context.SaveChanges();
        }
        public void DeleteClient(int ClientId)
        {
            var c = context.Clients.SingleOrDefault(x => x.ClientId == ClientId);
            context.Clients.Remove(c);
            context.SaveChanges();
        }

    }
}
