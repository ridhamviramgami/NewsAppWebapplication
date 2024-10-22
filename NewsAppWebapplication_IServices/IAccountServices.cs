using Model.API_Model;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAppWebapplication_IServices
{
    public interface IAccountServices
    {
        bool NewRegistration(UserMaster usermaster);
        UserMaster GetLogin(LoginAPIModel loginAPIModel);
    }
}
