using System;
using System.Collections.Generic;

namespace SoftBookShop.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Detalleventa = new HashSet<Detalleventum>();
        }

        public int IdProducto { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdCategoria { get; set; }
        public string? Imagen { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }
        public ulong Estado { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; } = null!;
        public virtual ICollection<Detalleventum> Detalleventa { get; set; }
    }
}
