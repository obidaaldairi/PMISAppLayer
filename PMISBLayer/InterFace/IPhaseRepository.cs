using PMISBLayer.DTOs;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.InterFace
{
    public interface IPhaseRepository
    {
        public List<Phase> GetAllPhases();
        public void InsertPhase(InsertPhaseDTO2 phDTO);
        public Phase EditPhase(int PhaseId);
        public void UpdatePhase(UpdatePhaseDTO2 UpphDTO);
        public void DeletePhase(int PhaseId);



    }
}
