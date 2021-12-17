using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PedidoEntity : DBEntity
    {
        public PedidoEntity()
        {
            Cliente = Cliente ?? new ClienteEntity();
            Producto = Producto ?? new ProductoEntity();
        }

        public int? IdPedido { get; set; }

        public int? IdCliente { get; set; }

        public int? IdProducto { get; set; }


        public string Codigo { get; set; } = "OD"  +  new Random().Next(25500000);
        
        public DateTime Fecha { get; set; } = DateTime.Now;

        public int Cantidad { get; set; }

        public int PrecioUnitario { get; set; }

        public int Envio { get; set; }

        public int SubTotal { get; set; }

        public decimal IVA { get; set; }

        public decimal Total { get; set; }

        public virtual ClienteEntity Cliente { get; set; }
        public virtual ProductoEntity Producto { get; set; }

    }
}
