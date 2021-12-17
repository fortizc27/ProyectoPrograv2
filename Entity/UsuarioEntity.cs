using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Entity
{
    public class UsuarioEntity : DBEntity
    {
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public int Rol_id { get; set; }
        public string Rol_Description { get; }
        public Boolean Estado { get; set; }
    }
}
