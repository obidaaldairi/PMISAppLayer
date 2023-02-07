using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.DTOs
{
    public class InsertProjectDTO
    {
        public string ProjectName { get; set; }
        public int ProjectTypeId { get; set; }
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        //[DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        //[DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int ProjectStatusId { get; set; }
        public List<int> PhaseIds { get; set; }
        public decimal ContractAmount { get; set; }

        public IFormFile ContractFile { get; set; }

        //data annotation custoum validation

    }
}
