using Adminservices.Models;
using Adminservices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminservices.Services
{
    public interface IJwtManagerRepository 
    {
        Tokens Authenticate(AdminLoginViewModel admin, bool IsRegister);
        List<AdminTb> FindAll();
    }
}
