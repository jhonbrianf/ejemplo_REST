using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pagosController : ControllerBase
    {
        LiteDatabase db = new LiteDatabase(@"MyData.db");
        public pagosController()
        {

        }
    // GET: api/pagos
    [HttpGet]
        public IEnumerable<Pagos> Get()
        {
            var pagos = db.GetCollection<Pagos>("pagos");
            return pagos.FindAll();
        }
        

       
        // POST: api/pagos
        [HttpPost]
        public string Post([FromBody] Pagos value)
        {
            var pagos = db.GetCollection<Pagos>("pagos");
            pagos.Insert( value);
            return "registro pagos creado con exito";
        }

        // PUT: api/pagos/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Pagos value)
        {
            value.Id = id;
            var pagos = db.GetCollection<Pagos>("pagos");
            pagos.Update(value);
            return "registro de pagos actualizado";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var pagos = db.GetCollection<Pagos>("pagos");
            pagos.Delete(c => c.Id.Equals(id));
            return "pagos eliminado con exito";
        }
    }
}
