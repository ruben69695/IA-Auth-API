using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AI_AUTH_JR.Model;
using Microsoft.EntityFrameworkCore;
using AI_AUTH_JR.Classes;

namespace AI_AUTH_JR.Controllers
{
    [Produces("application/json")]
    [Route("api/ActionLogin")]
    public class ActionLoginController : Controller
    {
        public ActionLoginController()
        {

        }

        public Auth Get()
        {
            return Auth.Current;
        }

    }
}