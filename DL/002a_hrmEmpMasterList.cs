using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMSDL
{
    public class _002a_hrmEmpMasterListDomain
    {
        [Range(0,int.MaxValue)]
        public int ID { get; set; }
        public int empNoID_001c { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int genderID { get; set; }

    }
}
