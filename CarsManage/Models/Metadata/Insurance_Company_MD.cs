using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsManage.Models
{
    [MetadataType(typeof(Insurance_Company_MD))]
    public partial class Insurance_Company
    {
        public class Insurance_Company_MD
        {
            [Display(Name = "保險公司編號")]
            public int Company_no { get; set; }
            [Display(Name = "保險公司")]
            public string Company_nm { get; set; }
        }
    }
}