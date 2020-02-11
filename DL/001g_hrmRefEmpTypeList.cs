using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DL
{
    public class _001g_hrmRefEmpTypeListDomain
    {
        [Range(0,int.MaxValue)]
        public int ID { get; set; }
        public string typeName { get; set; }

    }
}
