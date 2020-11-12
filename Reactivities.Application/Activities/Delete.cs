using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reactivities.Data;

namespace Reactivities.Application.Activities
{
    public class DeleteCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteHandler : IRequestHandler<DeleteCommand>
    {
        private readonly ReactivitiesDbContext context;

        public DeleteHandler(ReactivitiesDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities.FindAsync(request.Id);

            if (activity == null)
                throw new Exception("Activity not found");

            context.Remove(activity);

            var result = await context.SaveChangesAsync() > 0;

            if (result) return Unit.Value;

            throw new Exception("Problem saving changes");
        }
    }

}