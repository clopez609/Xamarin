namespace Xamarin.Web.Data.Entities
{
    public class Course : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public User User { get; set; }

        //public int? MatterId { get; set; }
        //public Matter Matter { get; set; }
    }
}
