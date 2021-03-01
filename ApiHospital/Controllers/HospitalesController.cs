using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiHospital.Models;
using ApiHospital.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalesController : ControllerBase
    {
        RepositoryHospital repo;

        public HospitalesController(RepositoryHospital repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Hospital>> GetHospitales()
        {
            return this.repo.GetHospitales();
        }

        [HttpGet("{id}")]
        public ActionResult<Hospital> GetHospital(int id)
        {
            return this.repo.BuscarHospital(id);
        }
    }
}
