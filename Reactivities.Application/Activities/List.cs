using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reactivities.Core.Entities;
using Reactivities.Data;

namespace Reactivities.Application.Activities
{
    public class List
    {
        public class  Query : IRequest<List<Activity>>
        {
            
        }
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly ReactivitiesDbContext context;

            public Handler(ReactivitiesDbContext context)
            {
                this.context = context;
            }

            public async  Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activities = await context.Activities.ToListAsync();
                return activities;
            }
        }
    }
}