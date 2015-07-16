using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsManage.Models
{
    [MetadataType(typeof(Dlv_Center_MD))]
    public partial class Dlv_Center
    {
        public class Dlv_Center_MD
        {
            [Display(Name = "物流中心編號")]
            public string Center_no { get; set; }
            [Display(Name = "物流中心")]
            public string Center_nm { get; set; }
            [Display(Name = "地址")]
            public string Addr { get; set; }
            [Display(Name = "電話")]
            public string Tel { get; set; }
            [Display(Name = "傳真")]
            public string Fax { get; set; }
            [Display(Name = "電子郵件")]
            public string Email { get; set; }
            [Display(Name = "內容")]
            public string Contact { get; set; }
            [Display(Name = "是否顯示")]
            public string Dsp_sw { get; set; }
        }
    }
}