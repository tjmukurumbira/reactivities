using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reactivities.Core.Entities;
using Reactivities.Data;

namespace Reactivities.Application.Activities
{

    public class CreateCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }
    }

    public class CreateHandler : IRequestHandler<CreateCommand>
    {
        private readonly ReactivitiesDbContext context;

        public CreateHandler(ReactivitiesDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var activity = new Activity
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                Category = request.Category,
                Date = request.Date,
                City = request.City,
                Venue = request.Venue,

            };

            context.Activities.Add(activity);
            var result = await context.SaveChangesAsync() > 0;
            if (result)
                return Unit.Value;
            throw new Exception("PRoblem saving changes");
        }
    }


}