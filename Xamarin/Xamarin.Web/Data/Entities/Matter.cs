namespace Xamarin.Web.Data.Entities
{
    public class Matter
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? CarrerId { get; set; }
        public virtual Career Carrer { get; set; }
    }
}
