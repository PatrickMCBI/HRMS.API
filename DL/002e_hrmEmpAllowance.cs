using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMSDL
{
    public class _002e_hrmEmpAllowanceDomain
    {
        [Range(0,int.MaxValue)]
        public int ID { get; set; }
        public int empMasterID_002a { get; set; }
        public decimal allowance { get; set; }

    }
}
