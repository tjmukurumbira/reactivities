using System; 
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reactivities.Core.Entities;
using Reactivities.Data;

namespace Reactivities.Application.Activities
{
    public class Detail
    {
        public class  Query : IRequest<Activity>
        {
            public Guid Id { get; set; }   
        }
        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly ReactivitiesDbContext context;

            public Handler(ReactivitiesDbContext context)
            {
                this.context = context;
            }

            public async  Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Id);
                return activity;
            }
        }
    }

   
}