using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMSDL
{
    public class _001b_hrmRefGenderListDomain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }
        public string genderName { get; set; }
    }
}
