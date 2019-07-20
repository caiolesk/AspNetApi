using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using APIDOGUAX.Filter;
using APIDOGUAX.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebApiGuaxCore.Manager;
using WebApiGuaxCore.Model;

namespace APIDOGUAX.Controllers
{
    [Route("api/teste")]
    public class TesteController : BaseController
    {
        private readonly IAdicionar _adicionar;

        public TesteController(IAdicionar adicionar, IMapper mapper) : base(mapper)
        {
            this._adicionar = adicionar;
        }

        [HttpPost("usuario")]
        [ValidateModel]
        [Produces(typeof(User))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Inserido com sucesso", Type = typeof(User))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var newUser = _mapper.Map<User>(user);
            await _adicionar.createUser(newUser);

            return Ok();
        }

        [HttpPost("telefone")]
        [ValidateModel]
        [Produces(typeof(PhoneCreateDTO))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Inserido com sucesso", Type = typeof(PhoneCreateDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> CreatePhone([FromBody] PhoneCreateDTO phone)
        {
            var newPhone = _mapper.Map<Phone>(phone);
            await _adicionar.createPhoneUser(newPhone);

            return Ok();
        }

        //[httppost("endereco")]
        //[validatemodel]
        //[produces(typeof(adresscreatedto))]
        //[swaggerresponse((int)httpstatuscode.ok, description = "inserido com sucesso", type = typeof(adresscreatedto))]
        //[swaggerresponse((int)httpstatuscode.badrequest, description = "requisição mal-formatada")]
        //[swaggerresponse((int)httpstatuscode.unauthorized, description = "erro de autenticação")]
        //[swaggerresponse((int)httpstatuscode.conflict, description = "conflito")]
        //[swaggerresponse((int)httpstatuscode.internalservererror, description = "erro na api")]
        //public async task<iactionresult> createadress([frombody] adresscreatedto adress)
        //{
        //    var newadress = _mapper.map<adress>(adress);
        //    await _adicionar.createadressuser(newadress);

        //    return ok();
        //}


        [HttpGet]
        [Produces(typeof(List<User>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Inserido com sucesso", Type = typeof(List<User>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _adicionar.getAll();

            return Ok(result);
        }
    }
}