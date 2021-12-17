using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductoEntity : DBEntity
    {
        public ProductoEntity()
        {
            Categoria = Categoria ?? new CategoriaEntity();
        }
        public int? IdProducto { get; set; }

        public int? IdCategoria { get; set; }

        public virtual CategoriaEntity Categoria { get; set; }

        public string Nombre { get; set; }

        public int Cantidad { get; set; }

        public string Caracteristicas { get; set; }

        public int Precio { get; set; }

        public bool Estado { get; set; }

    }
}
