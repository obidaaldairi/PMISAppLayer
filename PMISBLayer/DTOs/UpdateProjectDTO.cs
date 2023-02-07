using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer
{
    public class UpdateProjectDTO
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int ProjectTypeId { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectStatusId { get; set; }
        public List<int> PhaseIds { get; set; }
        public decimal ContractAmount { get; set; }
    }
}
