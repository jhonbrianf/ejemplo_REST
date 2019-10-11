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
    public class UsuarioController : ControllerBase
    {
        LiteDatabase db = new LiteDatabase(@"MyData.db");
        public UsuarioController()
        {

        }
        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            var usuario = db.GetCollection<Usuarios>("usuario");
            return usuario.FindAll();
        }

        // GET: api/Usuario/5
        [HttpGet("{nombre}", Name = "Buscar")]
        public IEnumerable<Usuarios> Buscar(string nombre)
        {
            var usuario = db.GetCollection<Usuarios>("usuario");
            return usuario.Find(c => c.nombre.Contains(nombre) );
        }

        // POST: api/Usuario
        [HttpPost]
        public string Post([FromBody] Usuarios value)
        {
            var usuario = db.GetCollection<Usuarios>("usuario");
            usuario.Insert(new Usuarios { nombre = value.nombre, apellido = value.apellido, edad = value.edad });
            return "registro cliente creado con exito";

        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Usuarios value)
        {
            value.Id = id;
            var usuario = db.GetCollection<Usuarios>("usuario");
            usuario.Update(value);
            return "registro actualizado";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var usuario = db.GetCollection<Usuarios>("usuario");
            usuario.Delete(c => c.Id.Equals(id));
            return "cliente eliminado con exito";
        }
    }
}
