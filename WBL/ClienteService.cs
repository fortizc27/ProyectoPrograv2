using Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DB;

namespace WBL
{
    public interface IClienteService
    {
        Task<DBEntity> Insert(ClienteEntity entity);
        Task<DBEntity> Update(ClienteEntity entity);
        Task<DBEntity> Delete(ClienteEntity entity);
        Task<IEnumerable<ClienteEntity>> GetLista();

        Task<IEnumerable<ClienteEntity>> Get();
        Task<ClienteEntity> GetById(ClienteEntity entity);
    }

    public class ClienteService : IClienteService
    {
        private readonly IDataAccess sql;

        public ClienteService (IDataAccess sql)
	    {
            this.sql = sql;
	    }

        public async Task<IEnumerable<ClienteEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ClienteEntity>("ClienteObtener");
                return await result;
            }
            catch (Exception)
            {
                throw;
            }       
        }

        public async Task<ClienteEntity> GetById(ClienteEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ClienteEntity>("ClienteObtener", new { entity.IdCliente });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ClienteEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<ClienteEntity>("dbo.ClienteLista");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<DBEntity> Insert(ClienteEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ClienteInsertar", new
                {
                    entity.NombreCliente,
                    entity.PrimerApellidoCliente,
                    entity.SegundoApellidoCliente,
                    entity.DireccionCliente,
                    entity.FechaDeNacimientoCliente,
                    entity.TelefonoCliente,
                    entity.CedulaCliente
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Update(ClienteEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ClienteActualizar", new
                {
                    entity.IdCliente,
                    entity.NombreCliente,
                    entity.PrimerApellidoCliente,
                    entity.SegundoApellidoCliente,
                    entity.DireccionCliente,
                    entity.FechaDeNacimientoCliente,
                    entity.TelefonoCliente,
                    entity.CedulaCliente
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Delete(ClienteEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ClienteEliminar", new { entity.IdCliente });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
