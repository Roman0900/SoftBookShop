using System;
using System.Collections.Generic;

namespace SoftBookShop.Models
{
    public partial class Metodopago
    {
        public Metodopago()
        {
            Venta = new HashSet<Venta>();
        }

        public int IdMetodoPago { get; set; }
        public string? Descripcion { get; set; }
        public ulong Estado { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
