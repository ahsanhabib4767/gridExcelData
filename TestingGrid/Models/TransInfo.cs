using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestingGrid.Models
{
    [MetadataType(typeof(TargetVM))]
    public partial class TransInfo
    {

        public int TransID { get; set; }
        public int TransStatus { get; set; }
        public string TransMessage { get; set; }

    }
    public class TargetVM
    {

        public int id { get; set; }
        public Nullable<int> SL { get; set; }
        public string Name { get; set; }
        public string Roll { get; set; }
        public string Class { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
       // public virtual ICollection<TargetVM> TargetDetail { get; set; }
    }
}