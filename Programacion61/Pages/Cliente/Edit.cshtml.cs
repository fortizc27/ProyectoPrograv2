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
    public class EditModel : PageModel
    {
        private readonly IClienteService clienteService;

        public EditModel (IClienteService clienteService)
	    {
            this.clienteService = clienteService;
	    }

        //Enables us to call the customer entity attributes
        [BindProperty]
        [FromBody]
        public ClienteEntity Entity { get; set; } = new ClienteEntity();

        //Maps the Id to be edited
        [BindProperty(SupportsGet =true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                //Edit
                if (id.HasValue)
                {
                    Entity = await clienteService.GetById(new() { IdCliente = id });
                }

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
                if (Entity.IdCliente.HasValue)
                {
                    result = await clienteService.Update(Entity);
                }
                else
                {
                    result = await clienteService.Insert(Entity);
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
