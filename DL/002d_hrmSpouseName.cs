using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DL
{
    public class _002d_hrmSpouseNameDomain
    {
        [Range(0,int.MaxValue)]
        public int ID { get; set; }
        public int empMasterID_002a { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }

    }
}
