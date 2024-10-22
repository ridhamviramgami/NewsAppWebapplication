using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.CommonHelper
{
    public static class APIMessage
    {
        #region Common message
        public const string InternalServer = "Internal Server Error";
        public const string PassMandatoryFields = "Please enter all mandatory fields.";
        public const string InvalidCredentials = "Invalid credentials";
        #endregion

        #region Registration
        public const string RegistrationSuccess = "Registration successfully.";
        public const string RegistrationFailed = "Registration failed.";
        #endregion

        #region Log in
        public const string LoginSuccess = "Login successfully.";
        #endregion

        #region Profile
        public const string ProfileUpdate = "Profile updated successfully.";

        public const string ProfileNotUpdate = "Profile not updated.";
        #endregion

        #region Change Password
        public const string PasswordUpdate = "Password updated successfully.";

        public const string PasswordNotMatch = "Current password not matched.";
        #endregion
    }
}
