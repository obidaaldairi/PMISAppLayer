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
    public class PaymentTermRepository : IPaymentTermRepository
    {
        private readonly ApplicationDbContext context;
        public PaymentTermRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public List<PaymentTerm> GetAllPaymentTerm(string projectManagerId)
        {
            return context.PaymentTerms
                .Include(c => c.Deliverable).ThenInclude(x => x.ProjectPhase).ThenInclude(x => x.Project)
                .Include(x=>x.Deliverable).ThenInclude(x=>x.ProjectPhase).ThenInclude(x=>x.Phase)
                .Where(x => x.Deliverable.ProjectPhase.Project.ProjectManagerId == projectManagerId)
                .ToList();
        }

        public List<Deliverable> GetDeliverables(string projectManagerId)
        {
            return context.Deliverables
                .Include(x=>x.ProjectPhase)
                .ThenInclude(x=>x.Project)
                .Where(x => x.ProjectPhase.Project.ProjectManagerId == projectManagerId)
                .ToList();
        }
        public void InsertPaymentTerm(InsertPaymentTermDTO pmtDTO)
        {

            PaymentTerm pmt = new PaymentTerm();
            pmt.DeliverableId = pmtDTO.DeliverableId;
            pmt.PaymentTermTitle = pmtDTO.PaymentTermTitle;
            pmt.PaymentTermAmount = pmtDTO.PaymentTermAmount;
            context.PaymentTerms.Add(pmt);
            context.SaveChanges();
        }
        public PaymentTerm EditPaymentTerm(int PaymentTermId)
        {
            return context.PaymentTerms.SingleOrDefault(x => x.PaymentTermId == PaymentTermId);
        }
        
        public void DeletePaymentTerm(int PaymentTermId)
        {
            var pmt = context.PaymentTerms.SingleOrDefault(x => x.PaymentTermId == PaymentTermId);
            context.PaymentTerms.Remove(pmt);
            context.SaveChanges();
        }
        public Deliverable getdeliv(InsertPaymentTermDTO pmtDTO)
        {
            return context.Deliverables
                        .Include(p => p.ProjectPhase)
                        .Include(q => q.ProjectPhase.Project)
                        .SingleOrDefault(t => t.DeliverableId == pmtDTO.DeliverableId);
        }
        
        public List<PaymentTerm> GetIsNotInovicePayment(int id)
        {
            return context.PaymentTerms
                .Include(e => e.Deliverable)
                .Include(e => e.Deliverable.ProjectPhase)
                .Include(e => e.Deliverable.ProjectPhase.Project)
                .Where(v => v.Deliverable.ProjectPhase.Project.ProjectId == id)
                .Where(x => x.IsInvoice == false)
                .ToList();
        }

        public void UpdatePaymenet(PaymentTerm term)
        {
            context.PaymentTerms.Update(term);
            context.SaveChanges();
        }
    }
}
