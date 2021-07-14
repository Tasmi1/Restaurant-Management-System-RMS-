//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class InventoryProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InventoryProduct()
        {
            this.PurchaseProducts = new HashSet<PurchaseProduct>();
        }
    
        public System.Guid InventoryProductID { get; set; }
        public string ProductsName { get; set; }
        public System.DateTime ManufactureDate { get; set; }
        public System.DateTime ExpDate { get; set; }
        public string Description { get; set; }
        public System.Guid CategoryID { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseProduct> PurchaseProducts { get; set; }
    }
}
