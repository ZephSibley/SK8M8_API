namespace Sk8M8_API.Models
{
    public class UserPermission : BaseEntity
    {
        public Client Client { get; set; }
        public Permission Permission { get; set; }
    }
}
