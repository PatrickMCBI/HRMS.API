using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DL
{
    public class _002h_hrmEmpSalaryAddOnDomain
    {
        [Range(0,int.MaxValue)]
        public int ID { get; set; }
        public int empMasterID_002a { get; set; }
        public decimal salaryAddOn { get; set; }
        public DateTime date { get; set; }
        public Boolean isCurrent { get; set; }

    }
}
