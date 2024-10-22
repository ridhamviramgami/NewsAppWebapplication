using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.API_Model
{
    public class ChangePasswordAPIModel
    {
        public string OldPassword {  get; set; }
        public string NewPassword {  get; set; }
        public string UserId {  get; set; }
    }
}
