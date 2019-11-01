namespace Xamarin.Web.Data.Entities
{
    public class Matter : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CarrerId { get; set; }
        public Career Carrer { get; set; }
    }
}
