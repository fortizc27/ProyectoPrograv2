using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBL;
using Entity;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController
    {
        private readonly ICategoriaService categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaEntity>> Get()
        {
            try
            {
                return await categoriaService.Get();
            }
            catch (Exception ex)
            {

                return new List<CategoriaEntity>();
            }


        }

        [HttpGet("{id}")]
        public async Task<CategoriaEntity> Get(int id)
        {
            try
            {
                return await categoriaService.GetById(new CategoriaEntity { IdCategoria = id });
            }
            catch (Exception ex)
            {

                return new CategoriaEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }


        [HttpPost]
        public async Task<DBEntity> Create(CategoriaEntity entity)
        {
            try
            {
                return await categoriaService.Insert(entity);
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }


        [HttpPut]
        public async Task<DBEntity> Update(CategoriaEntity entity)
        {
            try
            {
                return await categoriaService.Update(entity);
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }

        [HttpDelete("{id}")]
        public async Task<DBEntity> Delete(int id)
        {
            try
            {
                return await categoriaService.Delete(new CategoriaEntity() { IdCategoria = id });
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }
    }
}
