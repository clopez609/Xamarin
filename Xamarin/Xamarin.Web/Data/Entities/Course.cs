using System;

namespace Xamarin.Web.Data.Entities
{
    public class Course : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DayAndHour { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int? MatterId { get; set; }
        public Matter Matter { get; set; }
        public User User { get; set; }

    }
}
