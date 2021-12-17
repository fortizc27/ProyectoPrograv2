using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace Programacion61.Pages.Cliente
{
    public class GridModel : PageModel
    {
        private readonly IClienteService clienteService;
        public IEnumerable<ClienteEntity> GridList { get; set; } = new List<ClienteEntity>();

        public GridModel (IClienteService clienteService)
	    {
            this.clienteService = clienteService;
	    }

                
        public async Task<IActionResult> OnGet()
        {
            try
            {
                //Populates the list with the results returned from the customer get method.
                GridList = await clienteService.Get();
                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnDelete(int id)
        {
            try
            {
                var result = await clienteService.Delete(new() { IdCliente = id });
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError =ex.HResult, MsgError = ex.Message });
            }
        }
    }
}
