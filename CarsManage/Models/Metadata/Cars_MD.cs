using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsManage.Models
{
    [MetadataType(typeof(Cars_MD))]
    public partial class Cars
    {
        public class Cars_MD
        {
            public virtual Cars_Brand Cars_Brand { get; set; }
            public virtual Dlv_Center Dlv_Center { get; set; }
            public virtual Cars_Gas Cars_Gas { get; set; }

            [Display(Name = "物流中心")]
            public string Center_no { get; set; }
            [Display(Name = "所屬公司")]
            public int Company_no { get; set; }
            [Required]
            [Display(Name = "車號")]
            public string Car_no { get; set; }
            [Display(Name = "廠牌編號")]
            public int Brand_no { get; set; }
            [Display(Name = "型號")]
            public string Model { get; set; }
            [Display(Name = "載重")]
            [DisplayFormat(DataFormatString = "{0:#0.###}", ApplyFormatInEditMode = true)]
            public Nullable<decimal> Tonnage { get; set; }
            [Display(Name = "總重量")]
            [DisplayFormat(DataFormatString = "{0:#0.###}", ApplyFormatInEditMode = true)]
            public Nullable<decimal> Total_tonnage { get; set; }
            [Display(Name = "總連結重量")]
            [DisplayFormat(DataFormatString = "{0:#0.###}", ApplyFormatInEditMode = true)]
            public Nullable<decimal> AllLink_tonnage { get; set; }
            [Display(Name = "汽油種類編號")]
            public string Gas_no { get; set; }
            [Display(Name = "購買日期")]
            //[DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
            public Nullable<System.DateTime> Buy_date { get; set; }
            [Display(Name = "領牌日期")]
            //[DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
            public Nullable<System.DateTime> Permit_date { get; set; }
            [Display(Name = "製造日期")]
            //[DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
            public Nullable<System.DateTime> Make_date { get; set; }
            [Display(Name = "排氣量")]
            public Nullable<int> Cc { get; set; }
            [Display(Name = "車身號碼")]
            public Nullable<int> Body_no { get; set; }
            [Display(Name = "車身式樣及附加配備")]
            public string Body_model { get; set; }
            [Display(Name = "引擎號碼")]
            public string Engine_no { get; set; }
            [Display(Name = "駕駛座座位")]
            public Nullable<int> Seat { get; set; }
            [Display(Name = "狀態")]
            public int Carstate_no { get; set; }
            [Display(Name = "顏色")]
            public string Color { get; set; }

        }
    }
}