using System;
using System.Threading;
using System.Threading.Tasks;
using Database;
using Domain;
using MediatR;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Activity>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly DataContext context;
            public Handler(DataContext context)
            {
                this.context = context;
            }
                                            
            // Query below is from the template above, it returns one activity 
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Id);// get id through request
                return activity;
            }
        }
    }
}
