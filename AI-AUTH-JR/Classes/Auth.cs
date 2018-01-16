using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AI_AUTH_JR.Model;

namespace AI_AUTH_JR.Classes
{
    public class Auth
    {
        public static Auth Current { get; set; }
        public List<AuthAction> items { get; set; } = new List<AuthAction>();
    }

    public class AuthAction
    {
        public string name { get; set; }
        public string description { get; set; }
    }
}
