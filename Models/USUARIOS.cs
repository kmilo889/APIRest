namespace APIRest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USUARIOS
    {
      // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
      // public USUARIOS()
      //  {
      //     PEDIDOS = new HashSet<PEDIDOS>();
      //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UsuID { get; set; }

        [Required]
        [StringLength(50)]
        public string UsuNombre { get; set; }

        [Required]
        [StringLength(20)]
        public string UsuPass { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PEDIDOS> PEDIDOS { get; set; }
    }
}
