using System;
using System.Threading;
using System.Threading.Tasks;
using Database;
using MediatR;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { set; get; }
            public string Title { set; get; }
            public string Description { set; get; }
            public string Category { set; get; }
            public string City { set; get; }
            public string Venue { set; get; }
            public DateTime? Date { set; get; }
        }

        public class Handler : IRequestHandler<Command>
        {

            private readonly DataContext context;
            public Handler(DataContext context)
            {

                this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                // handler logic here
                var activity = await context.Activities.FindAsync(request.Id);
                if (activity == null)
                    throw new Exception("Could not found activity");
                activity.Title = request.Title ?? activity.Title;
                activity.Date = request.Date ?? activity.Date;
                activity.City = request.City ?? activity.City;
                activity.Venue = request.Venue ?? activity.Venue;
                activity.Category = request.Category ?? activity.Category;
                activity.Description = request.Description ?? activity.Description;

                var success = await context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}
