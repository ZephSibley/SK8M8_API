using Sk8M8_API.Models;

namespace Sk8M8_API.Services
{
    public interface ISessionManagementService
    {
        void Authenticate(Client client);
    }
}