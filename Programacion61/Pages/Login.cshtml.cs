using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Programacion61.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ServiceApi serviceApi;

        public LoginModel(ServiceApi serviceApi)
        {
            this.serviceApi = serviceApi;
        }

        [FromBody]
        [BindProperty]

        public UsuarioEntity Entity { get; set; } = new UsuarioEntity();


        //public async Task<IActionResult> OnPost()
        //{

        //    try
        //    {
        //        var result = await serviceApi.UsuarioLogin(Entity);
        //        if (result.CodeError == 0)
        //        {
        //            HttpContext.Session.Set<UsuarioEntity>(IApp.UsuarioSession, result);
        //            return new JsonResult(result);
        //        }
        //        else
        //        {
        //            return new JsonResult(result);
        //        }

        //    }

        //    catch (Exception ex)
        //    {

        //        return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
        //    }

        //}
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();

            return Redirect("../Login");
        }
    }
}
