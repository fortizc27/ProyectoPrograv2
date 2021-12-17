using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace Programacion61.Pages.Pedido
{
    public class EditModel : PageModel
    {
        private readonly IPedidoService pedidoService;
        private readonly IProductoService productoService;
        private readonly IClienteService clienteService;

        public EditModel(IPedidoService pedidoService,IProductoService productoService, IClienteService clienteService)
        {
            this.pedidoService = pedidoService;
            this.productoService = productoService;
            this.clienteService = clienteService;
        }

        //Enables us to call the customer entity attributes
        [BindProperty]
        [FromBody]
        public PedidoEntity Entity { get; set; } = new PedidoEntity();

        public IEnumerable<ProductoEntity> ProductoLista = new List<ProductoEntity>();
        public IEnumerable<ClienteEntity> ClienteLista = new List<ClienteEntity>();

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
                    Entity = await pedidoService.GetById(new() { IdPedido = id });
                }

                //Populates the Drop Down options
                ClienteLista = await clienteService.GetLista();
                ProductoLista = await productoService.GetLista();
                return Page();
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }

        //Insert and Update Operations
        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();

                //Edit
                if (Entity.IdPedido.HasValue)
                {
                    result = await pedidoService.Update(Entity);
                }
                else
                {
                    result = await pedidoService.Insert(Entity);
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
