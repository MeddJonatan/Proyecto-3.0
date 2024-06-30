using Proyecto.DAL.IRepositories;
using Proyecto.DAL.Context;
using Proyecto.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ProyectoContext db = new ProyectoContext ();

        public bool Actualizar(T obj)
        {
            try
            {
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool Eliminar(int Id)
        {
            var obj = db.Set<T>().Find(Id);

            if (obj != null)
            {
                db.Entry(obj).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool Insertar(T obj)
        {
            try
            {
                db.Entry(obj).State = EntityState.Added;
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public IEnumerable<T> Listar()
        {
            return db.Set<T>().ToList();
        }


        public IEnumerable<T> ListarProc(string proc, List<SqlParameter> parametros)
        {
            object[] prm = parametros.ToArray();
            var csv = String.Join(",", parametros.Select(l => l.ParameterName));
            return db.Database.SqlQuery<T>(proc + csv, prm).ToList();
        }
    }
}