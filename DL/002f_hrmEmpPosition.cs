using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DL
{
    public class _002f_hrmEmpPositionDomain
    {
        [Range(0,int.MaxValue)]
        public int ID { get; set; }
        public int empMasterID_002a { get; set; }
        public int positionRankId_001e { get; set; }
        public DateTime Date { get; set; }
        public Boolean isActive { get; set; }

    }
}
