using System;
namespace Domain
{
    public class Activity
    {
        public Guid Id { set; get; } // import System. Guid is used as primary key in database, Guid is unlikely to have dubplicate. see reference:https://www.c-sharpcorner.com/article/what-is-guid-in-c-sharp/
        public string Title { set; get; }
        public string Description { set; get; }
        public string Category { set; get; }
        public string City { set; get; }
        public string Venue { set; get; }
        public DateTime Date { set; get; }

    }
}