using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DL
{
    public class _002b_hrmPersonalInfoDomain
    {
        [Range(0,int.MaxValue)]
        public int ID { get; set; }
        public int empMasterID_002a { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public int civilStatusID { get; set; }

    }
}
