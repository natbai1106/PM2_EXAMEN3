using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM2_EXAMEN3.Models
{
    public class Puestos
    {
        public string value { get; set; }
        public List<Puestos> Puesto{ get; set; }

        public static List<Puestos> ObtenerCargos()
        {
            var cargo = new List<Puestos>()
            {
                new Puestos(){ value ="Cajero" },
                new Puestos(){ value ="Computacion" },
                new Puestos(){ value ="Auditor" },
                new Puestos(){ value ="Gerente" },
                new Puestos(){ value ="Supervisor" }
            };
        return cargo;
        }        
    }
}
