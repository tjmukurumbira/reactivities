using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reactivities.Application.Activities;
using Reactivities.Core.Entities;


namespace Reactivities.API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly IMediator mediator;
        public ActivitiesController(IMediator mediator)
        {
            this.mediator = mediator;
            
        }
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> List()
        {
            return await  this.mediator.Send(new ListQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> Details(Guid id)
        {
            return await  this.mediator.Send(new DetailQuery{Id = id});
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(CreateCommand createCommand)
        {
            return await mediator.Send(createCommand);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, EditCommand command)
        {
            command.Id = id;
            return await mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {            
            return await this.mediator.Send(new DeleteCommand{ Id = id });
        }
    }
}