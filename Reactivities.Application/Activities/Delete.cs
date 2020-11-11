using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reactivities.Data;

namespace Reactivities.Application.Activities
{
    public class Delete
    {
        public class  Command : IRequest 
        {
            public Guid Id { get; set; }   
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

                context.Remove(activity);    

                var result  = await context.SaveChangesAsync() > 0;

                if (result)  return Unit.Value;
                
                throw new Exception("Problem saving changes");
            }
        }
    }
}