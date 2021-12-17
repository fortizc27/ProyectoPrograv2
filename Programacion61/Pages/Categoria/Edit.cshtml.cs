using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace Programacion61.Pages.Categoria
{
    public class EditModel : PageModel
    {
        private readonly ICategoriaService categoriaService;

        public EditModel(ICategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }

        //Enables us to call the customer entity attributes
        [BindProperty]
        [FromBody]
        public CategoriaEntity Entity { get; set; } = new CategoriaEntity();

        //Maps the Id to be edited
        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                //Edit
                if (id.HasValue)
                {
                    Entity = await categoriaService.GetById(new() { IdCategoria = id });
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

                //Edit
                if (Entity.IdCategoria.HasValue)
                {
                    result = await categoriaService.Update(Entity);
                }
                else
                {
                    result = await categoriaService.Insert(Entity);
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
