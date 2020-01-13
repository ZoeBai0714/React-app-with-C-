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
        public class Handler : IRequestHandler<Query, List<Activity>> // this is an interface, so we need to implement the method
        {
            private readonly DataContext context;
            public Handler(DataContext context)
            {
                this.context = context;
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activities = await context.Activities.ToListAsync();
                return activities;
            }
        }
    }


}