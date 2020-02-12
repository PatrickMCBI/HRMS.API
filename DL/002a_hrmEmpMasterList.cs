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
        [Range(0, int.MaxValue)]
        public int ID { get; set; }
        public int empNoID_001c { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int genderID { get; set; }
        public DateTime dateHired { get; set; }


        public _vwEmployeeNumberDomain EmployeeNumber { get; set; }
        public _001c_hrmRefEmpNumberListDomain empNumber { get; set; }
        public _002b_hrmPersonalInfoDomain PersonalInfo { get; set; }
        public _002c_hrmEmploymentInfoDomain EmploymentInfo { get; set; }
        public _002d_hrmSpouseNameDomain SpouseName { get; set; }
        public _002e_hrmEmpAllowanceDomain EmpAllowance { get; set; }
        public _002f_hrmEmpPositionDomain EmpPosition { get; set; }
        public _002g_hrmEmpSalaryDomain EmpSalary { get; set; }
        public _002h_hrmEmpSalaryAddOnDomain EmpSalaryAddOn { get; set; }
    }
}
