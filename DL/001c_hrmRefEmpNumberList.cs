using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMSDL
{
    public class _001c_hrmRefEmpNumberListDomain
    {
        [Range(0,int.MaxValue)]
        public int ID { get; set; }
        public int prefixID_001 { get; set; }
        public int empSeriesNo { get; set; }
        public DateTime dateHired { get; set; }
    }
}
