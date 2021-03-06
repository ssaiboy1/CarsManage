//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarsManage.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cars
    {
        public Cars()
        {
            this.Cars_Insurance = new HashSet<Cars_Insurance>();
        }
    
        public int Uid { get; set; }
        public string Center_no { get; set; }
        public int Company_no { get; set; }
        public string Car_no { get; set; }
        public int Brand_no { get; set; }
        public string Model { get; set; }
        public Nullable<decimal> Tonnage { get; set; }
        public Nullable<decimal> Total_tonnage { get; set; }
        public Nullable<decimal> AllLink_tonnage { get; set; }
        public string Gas_no { get; set; }
        public Nullable<System.DateTime> Buy_date { get; set; }
        public Nullable<System.DateTime> Permit_date { get; set; }
        public Nullable<System.DateTime> Make_date { get; set; }
        public Nullable<int> Cc { get; set; }
        public string Body_no { get; set; }
        public string Body_model { get; set; }
        public string Engine_no { get; set; }
        public Nullable<int> Seat { get; set; }
        public string Color { get; set; }
        public int Carstate_no { get; set; }
    
        public virtual Cars_Brand Cars_Brand { get; set; }
        public virtual Cars_Company Cars_Company { get; set; }
        public virtual Cars_Gas Cars_Gas { get; set; }
        public virtual Cars_State Cars_State { get; set; }
        public virtual Dlv_Center Dlv_Center { get; set; }
        public virtual ICollection<Cars_Insurance> Cars_Insurance { get; set; }
    }
}
