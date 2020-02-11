using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DL
{
    public class _002g_hrmEmpSalaryDomain
    {
        [Range(0,int.MaxValue)]
        public int ID { get; set; }
        public int empMasterId_002a { get; set; }
        public decimal salary { get; set; }
        public DateTime date { get; set; }
        public Boolean isCurrent { get; set; }

    }
}
