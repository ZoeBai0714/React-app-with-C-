using System;
using System.Threading;
using System.Threading.Tasks;
using Database;
using Domain;
using MediatR;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest // no return here
        {
            public Guid Id { set; get; }
            public string Title { set; get; }
            public string Description { set; get; }
            public string Category { set; get; }
            public string City { set; get; }
            public string Venue { set; get; }
            public DateTime Date { set; get; }
        }

        public class Handler : IRequestHandler<Command> // pass in parameter Command from above
        {

            private readonly DataContext context;
            public Handler(DataContext context)
            {

                this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = new Activity()
                {
                    Id = request.Id,
                    Title = request.Title,
                    Description = request.Description,
                    Category = request.Category,
                    City = request.City,
                    Venue = request.Venue,
                    Date = request.Date
                };
                context.Activities.Add(activity);//both of List and Detail is using async here, but we are not using Addasync here to create, read this method, this method is only used when generating special value generator
                var success = await context.SaveChangesAsync() > 0;// this SaveChangesAsync will return a integer, which is the number of changes saved into database
                if (success) return Unit.Value; // empty object, then client site will return 200 when getting this
                throw new Exception("Problem saving changes");
            }

        }
    }
}