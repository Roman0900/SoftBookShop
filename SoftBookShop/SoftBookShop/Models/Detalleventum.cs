using System;
using System.Collections.Generic;

namespace SoftBookShop.Models
{
    public partial class Detalleventum
    {
        public int IdDetalleVenta { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public double PrecioUnitario { get; set; }
        public int Cantidad { get; set; }

        public virtual Producto IdProductoNavigation { get; set; } = null!;
        public virtual Venta IdVentaNavigation { get; set; } = null!;
    }
}
