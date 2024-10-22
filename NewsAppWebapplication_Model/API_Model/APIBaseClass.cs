using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.API_Model
{
    public class APIBaseClass
    {
        public int Status { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
    }
}
