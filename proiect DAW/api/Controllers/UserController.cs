﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.users;
using Domain;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserConstroller: ControllerBase
    {
        private readonly IMediator _mediator;
        public UserConstroller(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<user>>> List()
        {
            return await _mediator.Send(new list.Query());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<user>> search(Guid id)
        {
            return await _mediator.Send(new search.Query{Id=id});

        }

    }
}
