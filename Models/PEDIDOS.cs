namespace APIRest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PEDIDOS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PedID { get; set; }

        public int? PedUsu { get; set; }

        public int? pedPro { get; set; }

        [Column(TypeName = "money")]
        public decimal? pedVrUnit { get; set; }

        public double? PedCant { get; set; }

        [Column(TypeName = "money")]
        public decimal? PedSubtot { get; set; }

        public double? PedIVA { get; set; }

        [Column(TypeName = "money")]
        public decimal? PedTotal { get; set; }

        //public  PRODUCTOS PRODUCTOS { get; set; }

        //public USUARIOS USUARIOS { get; set; }
    }
}
