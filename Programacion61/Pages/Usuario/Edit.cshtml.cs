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
    public class EditModel : PageModel
    {
        private readonly IUsuarioService UsuarioService;
        //private readonly IRolService RolService;

        public EditModel(IUsuarioService UsuarioService)
        {
            this.UsuarioService = UsuarioService;
            //this.RolService = RolService;
        }

        [BindProperty]
        [FromBody]

        public UsuarioEntity Entity { get; set; } = new UsuarioEntity();

        //public IEnumerable<RolEntity> RolLista { get; set; } = new List<RolEntity>();

        [BindProperty(SupportsGet = true)]
        public String Id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (!String.IsNullOrEmpty(Id))
                {
                    Entity = await UsuarioService.GetById(new() { Usuario = Id });
                }

               //RolLista = await RolService.GetRolLista();
               
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
                if (!String.IsNullOrEmpty(Entity.Usuario))
                {
                    result = await UsuarioService.Update(Entity);


                }
                else
                {
                    result = await UsuarioService.Create(Entity);

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
