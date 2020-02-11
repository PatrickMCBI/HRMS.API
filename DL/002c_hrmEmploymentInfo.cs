using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMSDL
{
    public class _002c_hrmEmploymentInfoDomain
    {
        [Range(0,int.MaxValue)]
        public int ID { get; set; }
        public int empMasterId_002a { get; set; }
        public int employmentTypeID { get; set; }
        public int biometricIdentity { get; set; }
        public DateTime resignedDate { get; set; }
        public int employementStatusID { get; set; }

    }
}
