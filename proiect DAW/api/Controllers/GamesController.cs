using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.gamez;
using Domain;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesConstroller: ControllerBase
    {
        private readonly IMediator _mediator;
        public GamesConstroller(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<games>>> List()
        {
            return await _mediator.Send(new list.Query());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<games>> search(Guid id)
        {
            return await _mediator.Send(new search.Query{Id=id});

        }
        [HttpPost]
        public async Task<ActionResult<Unit>> create(create.Command command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> edit(Guid id, edit.Command command)
        {
            command.Id=id;
            return await _mediator.Send(command);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> delete(Guid id)
        {
            return await _mediator.Send(new delete.Command{Id = id});
        }
    }
}
