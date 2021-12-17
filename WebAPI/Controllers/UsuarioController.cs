using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBL;
using Entity;

namespace WebApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService UsuarioService;

        public UsuarioController(IUsuarioService usuariosService)
        {
            this.UsuarioService = UsuarioService;
        }

        [HttpPost("Login")]
        public async Task<UsuarioEntity> Login(UsuarioEntity entity)
        {

            try
            {
                return await UsuarioService.Login(entity);
            }
            catch (Exception ex)
            {

                return new UsuarioEntity() { CodeError=ex.HResult, MsgError=ex.Message };
            }
        
        }



    }
}
