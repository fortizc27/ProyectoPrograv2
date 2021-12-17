using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace Programacion61.Pages.Usuario
{
    public class GridModel : PageModel
    {
        private readonly IUsuarioService UsuarioService;

        public GridModel(IUsuarioService UsuarioService)
        {
            this.UsuarioService = UsuarioService;
        }

        public IEnumerable<UsuarioEntity> GridList { get; set; } = new List<UsuarioEntity>();

        public async Task<IActionResult> OnGet()
        {

            try
            {
                GridList = await UsuarioService.Get();


                return Page();

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public async Task<IActionResult> OnDeleteEliminar(String Id)
        {

            try
            {
                var result = await UsuarioService.Delete(new() { Usuario = Id });

                return new JsonResult(result);


            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }

    }
}
