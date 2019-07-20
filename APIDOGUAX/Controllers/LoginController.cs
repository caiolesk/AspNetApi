using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APIDOGUAX.Filter;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebApiGuaxCore.Manager;
using WebApiGuaxCore.Model;

namespace APIDOGUAX.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly ILoginManager _loginManager;
        public LoginController(ILoginManager loginManager, IMapper mapper) : base(mapper)
        {
            this._loginManager = loginManager;
        }

        [HttpPost("create")]
        [ValidateModel]
        [Produces(typeof(Login))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Inserido com sucesso", Type = typeof(Login))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> CreateLogin([FromBody] Login login)
        {
            var newLogin = _mapper.Map<Login>(login);
            await _loginManager.CreateLogin(newLogin);

            return Ok();
        }

        [HttpPost("signIn")]
        [Produces(typeof(Login))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Inserido com sucesso", Type = typeof(Login))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> SignIn([FromBody] Login login)
        {
            var newLogin = _mapper.Map<Login>(login);
            var result = await _loginManager.SignIn(newLogin);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        //[Produces(typeof(Login))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Inserido com sucesso", Type = typeof(Login))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> Delete(int id)
        {
            //var newLogin = _mapper.Map<Login>(login);
            await _loginManager.DeleteLogin(id);

            return Ok();
        }
    }
}