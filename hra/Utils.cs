using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hra
{
    public class Utils
    {
        private static Utils _instance = new();
        public static Utils Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Utils();
                }
                return _instance;
            }
        }
        private Utils()
        {
        }


        public void ChangeForm(Form from, Form to)
        {
            from.Hide();
            to.Show();
        }
    }

   
}
