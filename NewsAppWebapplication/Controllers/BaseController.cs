using Microsoft.AspNetCore.Mvc;

namespace NewsAppWebapplication.Controllers
{
    public class BaseController : Controller
    {
        public void SetDisplayToast(string type, string Message)
        {
            try
            {
                TempData["AlertType"] = type;
                TempData["AlertMsg"] = Message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetSesstionString(string key)
        {
            try
            {
                return HttpContext.Session.GetString(key) == null ? "" : HttpContext.Session.GetString(key);
            }
            catch (global::System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
