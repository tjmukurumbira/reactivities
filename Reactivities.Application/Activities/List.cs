using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reactivities.Core.Entities;
using Reactivities.Data;

namespace Reactivities.Application.Activities
{

    public class ListQuery : IRequest<List<Activity>>
    {

    }
    public class ListHandler : IRequestHandler<ListQuery, List<Activity>>
    {
        private readonly ReactivitiesDbContext context;

        public ListHandler(ReactivitiesDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Activity>> Handle(ListQuery request, CancellationToken cancellationToken)
        {
            var activities = await context.Activities.ToListAsync();
            return activities;
        }
    }

}