using Microsoft.EntityFrameworkCore;
using Model.API_Model;
using Model.Context;
using Model.Model;
using NewsAppWebapplication_IServices;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AccountServices : IAccountServices, IDisposable
    {
        #region Private variable
        private readonly Informia_Context _context;
        private bool _disposed = false;
        #endregion

        #region Constructor
        public AccountServices(Informia_Context context)
        {
            _context = context;
        }
        #endregion

        #region Public method
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context?.Dispose();
                }
                _disposed = true;
            }
        }
        ~AccountServices()
        {
            Dispose(false);
        }

        public bool NewRegistration(UserMaster usermaster)
        {
            try
            {
                if (usermaster != null)
                {
                    usermaster.UserId = Guid.NewGuid().ToString();
                    usermaster.InsertedDate = DateTime.Now;
                    usermaster.IsActive = true;
                    _context.usermaster.Add(usermaster);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public UserMaster GetLogin(LoginAPIModel loginAPIModel)
        {
            try
            {
                UserMaster userMaster = new UserMaster();

                if (loginAPIModel != null)
                {
                    var checkdata = _context.usermaster.Where(x => (x.Email == loginAPIModel.Email || x.Password == loginAPIModel.Password && x.IsActive == true)).FirstOrDefault();

                    if (checkdata != null)
                    {
                        userMaster.UserId = checkdata.UserId;
                        userMaster.Name = checkdata.Name;
                        return userMaster;
                    }
                    else
                    {
                        return userMaster;
                    }
                }
                else
                {
                    return userMaster;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}
