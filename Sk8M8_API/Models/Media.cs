namespace Sk8M8_API.Models
{
    public class Media : BaseEntity
    {
        public Client Client { get; set; }
        public string Filename { get; set; }
    }
}
