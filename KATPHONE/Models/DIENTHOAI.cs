//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KATPHONE.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DIENTHOAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIENTHOAI()
        {
            this.CTHDs = new HashSet<CTHD>();
        }
    
        public int MASP { get; set; }
        public string TENSP { get; set; }
        public Nullable<decimal> GIABAN { get; set; }
        public Nullable<decimal> GIANHAP { get; set; }
        public string KICHTHUOC { get; set; }
        public string BONHO { get; set; }
        public Nullable<int> SOLUONG { get; set; }
        public string TRONGLUONG { get; set; }
        public string MAUSAC { get; set; }
        public string HEDIEUHANH { get; set; }
        public string CAMERA { get; set; }
        public string ANH { get; set; }
        public int MANSX { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }
        public virtual NHASANXUAT NHASANXUAT { get; set; }
    }
}
