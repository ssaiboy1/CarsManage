using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsManage.Models
{
    [MetadataType(typeof(Cars_Brand_MD))]
    public partial class Cars_Brand
    {
        public class Cars_Brand_MD
        {
            [Display(Name = "廠牌編號")]
            public int Brand_no { get; set; }
            [Display(Name = "廠牌名稱")]
            public string Brand_nm { get; set; }
        }
    }
}