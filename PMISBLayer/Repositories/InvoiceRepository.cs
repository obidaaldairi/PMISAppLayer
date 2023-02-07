using Microsoft.EntityFrameworkCore;
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
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext context;
        public InvoiceRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Invoice> GetAllInvoice(string projectManagerId)
        {
            return context.Invoices
                .Include(x=>x.Project)
                .Include(x => x.InvoicePaymentTarms)
                .ThenInclude(x => x.PaymentTerm)
                .ThenInclude(x => x.Deliverable)
                .ThenInclude(x => x.ProjectPhase)
                .ThenInclude(x => x.Project)
                .Where(x=>x.InvoicePaymentTarms
                .All(x=>x.PaymentTerm.Deliverable.ProjectPhase.Project.ProjectManagerId == projectManagerId))
                
                .ToList();
        }
        public List<PaymentTerm> GetAllPaymentTermsByProjectId(int ProjectId)
        {
            return context.PaymentTerms
                .Where(x => x.Deliverable.ProjectPhase.Project.ProjectId == ProjectId)
                .ToList();
        }
        public List<Project> GetAllProject(string projectManagerId)
        {
            return context.Projects
                .Where(x => x.ProjectManagerId == projectManagerId)
                .ToList();
        }
        public void InsertInvoice(InsertInvoiceDTO InvDTO)
        {
            Invoice newInvoice = new Invoice();
            newInvoice.InvoiceTitle = InvDTO.InvoiceTitle;
            newInvoice.InvoiceDate = InvDTO.InvoiceDate;
            newInvoice.ProjectId = InvDTO.ProjectId;
            context.Invoices.Add(newInvoice);
            context.SaveChanges();
            foreach(var inp in InvDTO.PaymentTermIds)
            {
                
                InvoicePaymentTarm INPT = new InvoicePaymentTarm();
                INPT.InvoiceId = newInvoice.InvoiceId;
                INPT.PaymentTermId = inp;
                var pays = context.PaymentTerms.SingleOrDefault(q => q.PaymentTermId == inp);
                pays.IsInvoice = true;
              context.InvoicePaymentTarms.Add(INPT);
            }
            context.SaveChanges();
        }
        public Invoice EditInvoice(int InvoiceId)
        {
            return context.Invoices.SingleOrDefault(x => x.InvoiceId == InvoiceId);
        }
        public void UpdateInvoice(UpdateInvoiceDTO UpInvDTO)
        {
            var LInvoice = context.Invoices.SingleOrDefault(x => x.InvoiceId == UpInvDTO.InvoiceId);
            LInvoice.InvoiceTitle = UpInvDTO.InvoiceTitle;
            LInvoice.InvoiceDate = UpInvDTO.InvoiceDate;
            foreach(var inpmt in context.InvoicePaymentTarms.Where(x=>x.InvoiceId == UpInvDTO.InvoiceId).ToList())
            {
                var pays = context.PaymentTerms.SingleOrDefault(q => q.PaymentTermId == inpmt.PaymentTermId);
                pays.IsInvoice = false;
                context.InvoicePaymentTarms.Remove(inpmt);
            }
            foreach(var inmpt in UpInvDTO.PaymentTermIds)
            {
                var newInpm = new InvoicePaymentTarm()
                {
                    InvoiceId = UpInvDTO.InvoiceId,
                    PaymentTermId = inmpt
                };
                var pays = context.PaymentTerms.SingleOrDefault(q => q.PaymentTermId == inmpt);
                pays.IsInvoice = true;
                context.InvoicePaymentTarms.Add(newInpm);
            }
            context.SaveChanges();

        }
        public void DeleteInvoice(int InvoiceId)
        {
            var inv = context.Invoices.Include(q=>q.InvoicePaymentTarms).SingleOrDefault(x => x.InvoiceId == InvoiceId);
            foreach (var item in inv.InvoicePaymentTarms)
            {
                var pays = context.PaymentTerms.SingleOrDefault(q => q.PaymentTermId == item.PaymentTermId);
                pays.IsInvoice = false;
                context.InvoicePaymentTarms.Remove(item);
            }
            context.Invoices.Remove(inv);
            context.SaveChanges();
        }
        public List<int> getallinvoicePaymenttern(string projectManagerId)
        {
            return context.InvoicePaymentTarms
              .Where(x => x.PaymentTerm.Deliverable.ProjectPhase.Project.ProjectManagerId == projectManagerId).Select(x => x.PaymentTermId).ToList();
        }
        public List<InvoicePaymentTarm> getpmtbyinvId(int InvoiceId)
        {
            return context.InvoicePaymentTarms.Include(x=>x.PaymentTerm)
                .Where(x => x.InvoiceId == InvoiceId).ToList();
        }

        public Invoice GetInvoiceById(int id)
        {
            return context.Invoices
                .Include(v => v.InvoicePaymentTarms)
                .ThenInclude(b => b.PaymentTerm)
                .ThenInclude(q => q.Deliverable)
                .Include(y=>y.Project)
                .Include(c=>c.Project.Client)
                .SingleOrDefault(b => b.InvoiceId == id);
        }
    }
}
