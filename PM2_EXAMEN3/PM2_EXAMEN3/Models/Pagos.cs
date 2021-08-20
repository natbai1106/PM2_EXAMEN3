using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM2_EXAMEN3.Models
{
    public class Pagos
    {
        [PrimaryKey, AutoIncrement]
        public int IdPago { get; set; }

        [MaxLength(300)]
        public string Descripcion { get; set; }

        public double Monto { get; set; }

        public string Fecha { get; set; }

        public byte[] Foto_recibo { get; set; }
    }   
}
