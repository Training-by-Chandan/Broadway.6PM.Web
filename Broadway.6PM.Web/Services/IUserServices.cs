using Broadway._6PM.Web.ViewModel.Admin;
using System.Collections.Generic;

namespace Broadway._6PM.Web.Services
{
    public interface IUserServices
    {
        List<UserlistViewModel> GetAllUsers();
    }
}