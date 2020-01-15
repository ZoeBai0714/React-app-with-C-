using MediatR;
using Domain;
using Database;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Application.Activities
{ 
    public class List
    {
        public class Query : IRequest<List<Activity>> { }//<List<Activity> is type parameter, it's placeholder, it identifies the type of the argument that will be passed in
        public class Handler : IRequestHandler<Query, List<Activity>> // this is an interface, so we need to implement the method. Here we are passing parameter Query from the above class, and return a list of Activity
        {
            private readonly DataContext context;
            public Handler(DataContext context)
            {
                this.context = context;
            }                                 // Query below is from the template above, it returns all the activities (a list of activity)
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activities = await context.Activities.ToListAsync();
                return activities;
            }
        }
    }


}