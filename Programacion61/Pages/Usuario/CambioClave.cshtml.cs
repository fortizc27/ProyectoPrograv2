using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace Programacion61.Pages.Usuario
{
    public class CambioClaveModel : PageModel
    {
        private readonly IUsuarioService UsuarioService;

        public CambioClaveModel(IUsuarioService UsuarioService)
        {
            this.UsuarioService = UsuarioService;
        }

        [BindProperty]
        [FromBody]

        public UsuarioEntity Entity { get; set; } = new UsuarioEntity();

        [BindProperty(SupportsGet = true)]
        public String Id { get; set; }
        public String SegundaClave { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (!String.IsNullOrEmpty(Id))
                {
                    Entity = await UsuarioService.GetById(new() { Usuario = Id });
                }

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }


        }

        public async Task<IActionResult> OnPost()
        {

            try
            {
                var result = new DBEntity();
                if (String.Equals(Entity.Clave,SegundaClave))
                {
                    result = await UsuarioService.UpdateClave(Entity);
                }

                return new JsonResult(result);
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }


        }

    }
}
