//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fifulya.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProductMaterials = new HashSet<ProductMaterial>();
            this.ProductSales = new HashSet<ProductSale>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Article { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> MinPrice { get; set; }
        public Nullable<int> ProductTypeId { get; set; }
        public Nullable<int> ManForProduction { get; set; }
        public Nullable<int> WorkshopId { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
    
        public virtual ProductType ProductType { get; set; }
        public virtual Workshop Workshop { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductMaterial> ProductMaterials { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductSale> ProductSales { get; set; }
    }
}
