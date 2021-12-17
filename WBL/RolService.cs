using DB;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WBL
{
    public interface IRolService
    {
        Task<IEnumerable<RolEntity >> GetRolLista();
    }

    public class RolService : IRolService
    {
        private readonly IDataAccess sql;

        public RolService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region Metodos

        //Metodo Lista de Roles
        public async Task<IEnumerable<RolEntity>> GetRolLista()
        {

            try
            {
                var result = sql.QueryAsync<RolEntity>("RolLista");

                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
