using System;
using System.Threading;
using System.Threading.Tasks;
using Database;
using MediatR;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { set; get; }
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
                System.Diagnostics.Debug.WriteLine("??????", request.Id);
                var activity = await context.Activities.FindAsync(request.Id);
                if (activity == null)

                    throw new Exception("Could not find activity");
                context.Remove(activity);
                var success = await context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;
                throw new Exception("Problem deleting changes");
            }

        }
    }
}