﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Entities
{
    public class Phase
    {

        public int PhaseId { get; set; }
        public string PhaseName { get; set; }
        public List<ProjectPhase> ProjectPhases { get; set; }
    }
}
