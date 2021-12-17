using Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DB;

namespace WBL
{

    public interface ICategoriaService
    {
        Task<DBEntity> Insert(CategoriaEntity entity);
        Task<DBEntity> Update(CategoriaEntity entity);
        Task<DBEntity> Delete(CategoriaEntity entity);
        Task<IEnumerable<CategoriaEntity>> Get();
        Task<IEnumerable<CategoriaEntity>> GetLista();
        Task<CategoriaEntity> GetById(CategoriaEntity entity);
    }

    public class CategoriaService : ICategoriaService
    {
        private readonly IDataAccess sql;

        public CategoriaService(IDataAccess sql)
        {
            this.sql = sql;
        }

        public async Task<IEnumerable<CategoriaEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<CategoriaEntity>("CategoriaObtener");
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<CategoriaEntity>> GetLista()
        {

            try
            {
                var result = sql.QueryAsync<CategoriaEntity>("CategoriaLista");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CategoriaEntity> GetById(CategoriaEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<CategoriaEntity>("CategoriaObtener", new { entity.IdCategoria });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Insert(CategoriaEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("CategoriaInsertar", new
                {
                    entity.NombreCategoria
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Update(CategoriaEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("CategoriaActualizar", new
                {
                    entity.IdCategoria,
                    entity.NombreCategoria
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Delete(CategoriaEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("CategoriaEliminar", new { entity.IdCategoria });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
