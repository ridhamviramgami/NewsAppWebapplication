using Helper.CommonHelper;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Model.API_Model;
using Model.Model;
using NewsAppWebapplication_IServices;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace NewsAppWebapplication.Controllers
{
    public class AccountController : BaseController
    {
        #region Private Variable
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IAccountServices _iaccountServices;
        #endregion

        #region Constructor
        public AccountController(IHostingEnvironment hostingEnvironment, IAccountServices accountServices)
        {
            _hostingEnvironment = hostingEnvironment;
            _iaccountServices = accountServices;
        }
        #endregion

        #region Public method
        [HttpGet]
        public IActionResult Registration()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Registration(UserMaster usermaster)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(usermaster.Name) || string.IsNullOrWhiteSpace(usermaster.Email) || string.IsNullOrWhiteSpace(usermaster.Mobile) || string.IsNullOrWhiteSpace(usermaster.Password))
                {
                    SetDisplayToast(Toster.E_Type, APIMessage.PassMandatoryFields);
                    return View();
                }
                #endregion

                var isAddData = _iaccountServices.NewRegistration(usermaster);

                if (isAddData)
                {
                    SetDisplayToast(Toster.S_Type, APIMessage.RegistrationSuccess);
                    return RedirectToAction("Login");
                }
                else
                {
                    SetDisplayToast(Toster.E_Type, APIMessage.RegistrationFailed);
                    return View();
                }

                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Login(LoginAPIModel loginAPIModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    #region Validation
                    if (string.IsNullOrWhiteSpace(loginAPIModel.Email) || string.IsNullOrWhiteSpace(loginAPIModel.Password))
                    {
                        SetDisplayToast(Toster.E_Type, APIMessage.PassMandatoryFields);
                        return View();
                    }
                    #endregion

                    loginAPIModel.Token = Guid.NewGuid().ToString();
                    var getlogin = _iaccountServices.GetLogin(loginAPIModel);

                    if (getlogin.UserId != 0)
                    {
                        return Redirect("/Home/Index");
                    }
                    else
                    {
                        SetDisplayToast(Toster.E_Type, APIMessage.InvalidCredentials);
                        return View();
                    }
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}