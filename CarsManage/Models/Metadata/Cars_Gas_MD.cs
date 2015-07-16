using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsManage.Models
{
    [MetadataType(typeof(Cars_Gas_MD))]
    public partial class Cars_Gas
    {
        public class Cars_Gas_MD
        {
            [Display(Name = "汽油編號")]
            public string Gas_no { get; set; }
            [Display(Name = "汽油種類")]
            public string Gas_nm { get; set; }
        }
    }
}