using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsManage.Models
{
    [MetadataType(typeof(Cars_Insurance_MD))]
    public partial class Cars_Insurance
    {
        public class Cars_Insurance_MD
        {
            [Display(Name = "主鍵")]
            public int Uid { get; set; }
            [Display(Name = "關連車輛")]
            public int Car_Uid { get; set; }
            [Display(Name = "保險公司")]
            public int Company_no { get; set; }
            [Display(Name = "保險號碼")]
            public string Insurance_no { get; set; }
            [Display(Name = "保險卡號")]
            public string Card_no { get; set; }
            [Display(Name = "開始日期")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public Nullable<System.DateTime> Date_S { get; set; }
            [Display(Name = "到期日期")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public Nullable<System.DateTime> Date_E { get; set; }
            [Display(Name = "備註")]
            public string Remark { get; set; }

        }
    }
}