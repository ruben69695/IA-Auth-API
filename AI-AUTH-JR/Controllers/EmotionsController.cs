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
    [Route("api/Emotions")]
    public class EmotionsController : Controller
    {
        public readonly aiAuthdbContext _context;

        public EmotionsController(aiAuthdbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Emotions> Get()
        {
            return _context.Emotions.ToList();
        }
    }
}