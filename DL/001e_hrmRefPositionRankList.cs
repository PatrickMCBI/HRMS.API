using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DL
{
    public class _001e_hrmRefPositionRankListDomain
    {
        [Range(0,int.MaxValue)]
        public int ID { get; set; }
        public int positionID_001d { get; set; }
        public int positionRank { get; set; }
        public decimal baseSalary { get; set; }
    }
}
