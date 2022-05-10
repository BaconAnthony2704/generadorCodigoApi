using generadorCodigo.Modelos;
using generadorCodigo.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace generadorCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablaController : ControllerBase
    {
        private readonly RepositoryValue _repo;
        public TablaController(RepositoryValue repository)
        {
            _repo = repository;
        }

        [HttpGet("[action]")]
        public async Task<List<InformacionTabla>> ObtenerTablas()
        {
            return await _repo.ObtenerTodasTablas();
        }

        [HttpPost("[action]")]
        public async Task<List<CamposInformacionTabla>> ObtenerCamposTablas([FromBody] InfoTab t)
        
        
        {
            
            return await _repo.ObtenerCamposTabla(t.tabla);
        }

    }
}
