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
    public class ClienteController : ControllerBase
    {
        LiteDatabase db = new LiteDatabase(@"MyData.db");
            public ClienteController ()
            {

            }
        // GET: api/Cliente
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            var cliente = db.GetCollection<Cliente>("clientes");
            return cliente.FindAll();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}", Name = "Get")]
        public Cliente Get(int id)
        {
            var cliente = db.GetCollection<Cliente>("clientes");
            return cliente.Find(c => c.Id.Equals(id)).FirstOrDefault();
        }

        // POST: api/Cliente
        [HttpPost]
        public string Post([FromBody] Cliente value)
        {
            var cliente = db.GetCollection<Cliente>("clientes");
            cliente.Insert(new Cliente {nombre=value.nombre,apellido=value.apellido,edad=value.edad });
            return "registro cliente creado con exito";
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Cliente value)
        {
            value.Id = id;
            var cliente = db.GetCollection<Cliente>("clientes");
            cliente.Update(value);
            return "registro actualizado";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var cliente = db.GetCollection<Cliente>("clientes");
            cliente.Delete(c=>c.Id.Equals(id));
            return "cliente eliminado con exito";
        }
    }
}
