using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApplication1
{
    public class Usuarios
    {
        public int Id { get; set; }

        public string nombre
        {
            get; set;
        }
        public string apellido
        {
            get; set;
        }
        public int edad
        {
            get; set;
        }
    }
}
