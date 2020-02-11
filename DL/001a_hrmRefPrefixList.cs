using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DL
{
    public class _001a_hrmRefPrefixListDomain
    {
        [Range(0,int.MaxValue)]
        public int ID { get; set; }
        public string prefix { get; set; }
        public string definition { get; set; }
    }
}
