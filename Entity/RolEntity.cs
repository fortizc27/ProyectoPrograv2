using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Entity
{
    public class RolEntity : DBEntity
    {
        public int? Rol_id { get; set; }
        public string Rol_Description { get; set; }
    }
}
