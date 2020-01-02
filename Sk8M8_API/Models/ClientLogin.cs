namespace Sk8M8_API.Models
{
    public class ClientLogin : BaseEntity
    {
        public Client Client { get; set; }
        public string IPAddress { get; set; }
    }
}
