using DB;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WBL
{
    public interface IUsuarioService
    {
        Task<UsuarioEntity> Login(UsuarioEntity entity);
        Task<DBEntity> Create(UsuarioEntity entity);
        Task<DBEntity> Update(UsuarioEntity entity);
        Task<DBEntity> UpdateClave(UsuarioEntity entity);
        Task<DBEntity> Delete(UsuarioEntity entity);
        Task<IEnumerable<UsuarioEntity>> Get();
        Task<UsuarioEntity> GetById(UsuarioEntity entity);
    }

    public class UsuarioService : IUsuarioService
    {
        private readonly IDataAccess sql;

        public UsuarioService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region MetodosCrud
        public async Task<DBEntity> Create(UsuarioEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("UsuarioInsertar", new
                {
                    entity.Usuario,
                    entity.Nombre,
                    entity.Clave,
                    entity.Estado,
                    entity.Rol_id
                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo Delete
        public async Task<DBEntity> Delete(UsuarioEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("UsuarioEliminar", new
                {
                    entity.Usuario,
                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Metodo Get
        public async Task<IEnumerable<UsuarioEntity>> Get()
        {
            try
            {

                var result = sql.QueryAsync<UsuarioEntity>("UsuarioObtener");

                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo GetById
        public async Task<UsuarioEntity> GetById(UsuarioEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<UsuarioEntity>("UsuarioObtener", new
                { entity.Usuario });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Login
        public async Task<UsuarioEntity> Login(UsuarioEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<UsuarioEntity>("Login", new
                {

                    entity.Usuario,
                    entity.Clave,
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo Update
        public async Task<DBEntity> Update(UsuarioEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("UsuarioActualizar", new
                {
                    entity.Usuario,
                    entity.Nombre,
                    entity.Clave,
                    entity.Estado,
                    entity.Rol_id
                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }


        //Metodo Update Clave
        public async Task<DBEntity> UpdateClave(UsuarioEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("UsuarioActualizarClave", new
                {
                    entity.Usuario,
                    entity.Clave
                });

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
