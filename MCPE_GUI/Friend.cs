using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCPE_GUI
{
    public class Friend : Account
    {
        public string _Name{ get => Username; set => Username = value; }
        public bool _IsOnline {get=> IsLoggedIn; set => IsLoggedIn = value; }
        public Friend(string name,bool stat):base(name,"")
        {
            _Name = name;
            _IsOnline = stat;
        }
        public Friend():base("NULL","")
        {
            _Name = "NULL";
            _IsOnline = false;
        }
        public static bool ApiCheckIsOnline(string name)
        {
            return false;
        }
    }
}
