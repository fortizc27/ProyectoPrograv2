using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace Programacion61.Pages.Producto
{
    public class EditModel : PageModel
    {
        private readonly IProductoService productoService;
        private readonly ICategoriaService categoriaService;

        public EditModel(IProductoService productoService, ICategoriaService categoriaService)
        {
            this.productoService = productoService;
            this.categoriaService = categoriaService;
        }

        //Enables us to call the customer entity attributes
        [BindProperty]
        [FromBody]
        public ProductoEntity Entity { get; set; } = new ProductoEntity();

        public IEnumerable<CategoriaEntity> CategoriaLista = new List<CategoriaEntity>();

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
                    Entity = await productoService.GetById(new() { IdProducto = id });
                }

                CategoriaLista = await categoriaService.GetLista();
                return Page();
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();

                //Edit
                if (Entity.IdProducto.HasValue)
                {
                    result = await productoService.Update(Entity);
                }
                else
                {
                    result = await productoService.Insert(Entity);
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
