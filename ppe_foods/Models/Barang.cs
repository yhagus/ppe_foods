//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ppe_foods.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Barang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Barang()
        {
            this.Penjualans = new HashSet<Penjualan>();
        }
    
        public int ID_Barang { get; set; }
        public string Nama { get; set; }
        public long Harga { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Penjualan> Penjualans { get; set; }
    }
}
