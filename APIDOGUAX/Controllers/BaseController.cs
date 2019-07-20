
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIDOGUAX.Controllers
{

    public class BaseController : Controller
    {
        public readonly IMapper _mapper;

        public BaseController(IMapper mapper)
        {
            this._mapper = mapper;
        }
    }
}