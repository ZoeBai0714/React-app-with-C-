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
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activities = await _context.Activities.ToListAsync();
                return activities;
            }
        }
    }


}