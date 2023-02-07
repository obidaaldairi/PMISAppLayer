using PMISBLayer.DTOs;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.InterFace
{
    public interface IInvoiceRepository
    {
        public List<Invoice> GetAllInvoice(string projectManagerId);
        public List<PaymentTerm> GetAllPaymentTermsByProjectId(int ProjectId);
        public List<Project> GetAllProject(string projectManagerId);
        public Invoice GetInvoiceById(int id);
        public void InsertInvoice(InsertInvoiceDTO InvDTO);
        public Invoice EditInvoice(int InvoiceId);
        public void UpdateInvoice(UpdateInvoiceDTO UpInvDTO);
        public void DeleteInvoice(int InvoiceId);
        public List<int> getallinvoicePaymenttern(string projectManagerId);
        public List<InvoicePaymentTarm> getpmtbyinvId(int InvoiceId);



    }
}
