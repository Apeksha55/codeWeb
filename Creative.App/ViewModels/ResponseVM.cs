using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creative.Model.ViewModel
{
    public class ResponseVM<T>
    {
        public T Response { get; set; }
        public bool HasException { get; set; }
        public string ErrorMsg { get; set; }


    }
}