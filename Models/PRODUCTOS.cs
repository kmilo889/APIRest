namespace APIRest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRODUCTOS
    {
     //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    //   public PRODUCTOS()
    //    {
    //        PEDIDOS = new HashSet<PEDIDOS>();
    //    }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProDesc { get; set; }

        [Column(TypeName = "money")]
        public decimal? ProValor { get; set; }

       //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       //public virtual ICollection<PEDIDOS> PEDIDOS { get; set; }
    }
}
