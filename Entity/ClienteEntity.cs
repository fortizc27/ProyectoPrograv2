using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ClienteEntity : DBEntity
    {
        
        public int? IdCliente { get; set; }

        public string NombreCliente { get; set; }

        public string PrimerApellidoCliente { get; set; }

        public string SegundoApellidoCliente { get; set; }

        public string DireccionCliente { get; set; }

        public DateTime FechaDeNacimientoCliente { get; set; }

        public string TelefonoCliente { get; set; }

        public string CedulaCliente { get; set; }

    }
}
