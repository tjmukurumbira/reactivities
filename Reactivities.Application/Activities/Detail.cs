using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reactivities.Core.Entities;
using Reactivities.Data;

namespace Reactivities.Application.Activities
{
    public class DetailQuery : IRequest<Activity>
    {
        public Guid Id { get; set; }
    }
    public class DetailHandler : IRequestHandler<DetailQuery, Activity>
    {
        private readonly ReactivitiesDbContext context;

        public DetailHandler(ReactivitiesDbContext context)
        {
            this.context = context;
        }

        public async Task<Activity> Handle(DetailQuery request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities.FindAsync(request.Id);
            return activity;
        }
    }



}