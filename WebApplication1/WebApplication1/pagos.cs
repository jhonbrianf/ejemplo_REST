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
    public class Pagos
    {
        public int Id { get; set; }

        public double monto 
        {
            get; set;
        }
        public string fecha
        {
            get ; set;
        }
  


    }
}