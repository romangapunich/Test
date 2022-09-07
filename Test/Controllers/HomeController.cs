using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MediatR;
using Test.Feature.Queries.Contract;
using Test.Model;

namespace Test.Controllers
{
    [ApiController]
    [Route("reverse")]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;


        public HomeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpGet]
        public async Task<ActionResult<ResultVm>> GetCarByGosNumber([FromQuery] string data)
        {
            var query = new GetResultTestQuery(data);
            return Ok(await _mediator.Send(query));
        }
    }
}
