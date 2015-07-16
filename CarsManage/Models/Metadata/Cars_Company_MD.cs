using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsManage.Models
{
    [MetadataType(typeof(Cars_Company_MD))]
    public partial class Cars_Company
    {
        public class Cars_Company_MD
        {
            [Display(Name = "公司編號")]
            public int Company_no { get; set; }
            [Display(Name = "所屬公司")]
            public string Company_nm { get; set; }
        }
    }
}