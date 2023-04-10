using AutoMapper;
using Hotel_Management_Application.Contracts;
using Hotel_Management_Service.Contract;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;

namespace Hotel_Management_System
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService_;

        public ServiceManager(IRepositoryManager repositoryManager,
            IMapper mapper,
            UserManager<CustomerDetails> userManager,
            IConfiguration configuration)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() =>
                new AuthenticationService(mapper, userManager, configuration));
        }
        public IAuthenticationService AuthenticationService => _authenticationService_.Value;
    }
}
