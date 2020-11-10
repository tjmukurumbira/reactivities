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

        public async Task<ActionResult<List<Activity>>> List()
        {
            return await  this.mediator.Send(new List.Query());
        }
    }
}