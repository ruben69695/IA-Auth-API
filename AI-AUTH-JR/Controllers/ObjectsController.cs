using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AI_AUTH_JR.Model;

namespace AI_AUTH_JR.Controllers
{
    [Produces("application/json")]
    [Route("api/Objects")]
    public class ObjectsController : Controller
    {
        private readonly aiAuthdbContext _context;

        public ObjectsController(aiAuthdbContext context)
        {
            _context = context;
        }

        public IEnumerable<Objects> Get()
        {
            return _context.Objects.ToList();
        }
    }
}