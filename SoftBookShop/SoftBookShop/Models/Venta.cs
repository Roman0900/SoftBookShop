using System;
using System.Collections.Generic;

namespace SoftBookShop.Models
{
    public partial class Venta
    {
        public Venta()
        {
            Detalleventa = new HashSet<Detalleventum>();
        }

        public int IdVenta { get; set; }
        public int IdMetodoPago { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }

        public virtual Metodopago IdMetodoPagoNavigation { get; set; } = null!;
        public virtual ICollection<Detalleventum> Detalleventa { get; set; }
    }
}
