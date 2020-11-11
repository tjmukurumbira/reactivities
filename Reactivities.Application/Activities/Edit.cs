using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reactivities.Data;

namespace Reactivities.Application.Activities
{
    public class Edit
    {
        public class  Command : IRequest 
        {
            public Guid Id { get ; set; }
            public string Title { get; set; }        
            public string Description { get; set; }
            public string Category { get; set; }
            public string City { get; set; }
            public string Venue { get; set; }
            public DateTime? Date { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ReactivitiesDbContext context;

            public Handler(ReactivitiesDbContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {   
                var activity = await context.Activities.FindAsync(request.Id);
                if (activity == null)
                    throw new Exception("Activity not found");   

                    activity.Title = request.Title ??  activity.Title;
                    activity.Description = request.Description ??  activity.Description;
                    activity.Category = request.Category ??  activity.Category;
                    activity.Date = request.Date ??  activity.Date;
                    activity.City = request.City ??  activity.Category;
                    activity.Venue = request.Venue ??  activity.Venue;

                var result  = await context.SaveChangesAsync() > 0;
                if (result)
                return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}