using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsManage.Models
{
    [MetadataType(typeof(Cars_State_MD))]
    public partial class Cars_State
    {
        public class Cars_State_MD
        {
            [Display(Name = "車輛狀態編號")]
            public int Carstate_no { get; set; }
            [Display(Name = "車輛狀態")]
            public string Carstate_nm { get; set; }
        }
    }
}