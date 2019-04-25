namespace WVS_List.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class List
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public List()
        {
            Produkts = new HashSet<Produkt>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ListID { get; set; }

        public string Name { get; set; }

        public int Status { get; set; }

        public DateTime LastModified { get; set; }

        public virtual Group Group { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produkt> Produkts { get; set; }
    }
}
