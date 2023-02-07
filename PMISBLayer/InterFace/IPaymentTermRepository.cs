using PMISBLayer.DTOs;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.InterFace
{
    public interface IPaymentTermRepository
    {
        public List<PaymentTerm> GetAllPaymentTerm(string projectManagerId);
        public List<Deliverable> GetDeliverables(string projectManagerId);
        public void InsertPaymentTerm(InsertPaymentTermDTO pmtDTO);
        public PaymentTerm EditPaymentTerm(int PaymentTermId);
        public void DeletePaymentTerm(int PaymentTermId);
        public Deliverable getdeliv(InsertPaymentTermDTO pmtDTO);
        public List<PaymentTerm> GetIsNotInovicePayment(int id);
        public void UpdatePaymenet(PaymentTerm term);
    }
}
