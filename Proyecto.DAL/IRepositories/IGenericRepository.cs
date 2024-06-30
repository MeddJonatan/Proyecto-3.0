using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.DAL.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> Listar();
        bool Insertar(T obj);
        bool Actualizar(T obj);
        bool Eliminar(int Id);

        IEnumerable<T> ListarProc(string proc, List<SqlParameter> Parametros);
    }
}