using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM2_EXAMEN3.Models
{
    public class BaseDatos
    {
        readonly SQLiteAsyncConnection db;
        public BaseDatos(String dbpath)
        {
            db = new SQLiteAsyncConnection(dbpath);
            //creacion de las tablas de la bd 
            db.CreateTableAsync<Pagos>().Wait();
        }

        //Metodos del CRUD para Sitios 

        #region Sitios 
        //Select 
        public Task<List<Pagos>> ObtenerPago()
        {
            return db.Table<Pagos>().ToListAsync();
        }

        //Insert 
        public Task<int> InsertPago(Pagos pagos)
        {
            if (pagos.IdPago != 0)
            {
                return db.UpdateAsync(pagos);
            }
            else
            {
                return db.InsertAsync(pagos);
            }
        }
        //Traer un solo sitio (Ubicacion) 
        //public Task<Sitios> ObtenerSitios(int pid)
        //{
        //    return db.Table<Sitios>()
        //        .Where(i => i.id == pid)
        //        .FirstOrDefaultAsync();
        //}

        //Delete 
        public Task<int> EliminarFoto(Pagos foto)
        {
            return db.DeleteAsync(foto);
        }
        #endregion Sitios 
    }
}
