using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class StarsController : Controller
    {
        private readonly StarRepository repository;

        public StarsController(StarRepository repository)
        {
            this.repository = repository;
        }

        // GET: Stars
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<IEntity>>> Index()
        {
            return await repository.GetAll();
        }
    }
}
