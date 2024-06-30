using Proyecto.DAL.Repositories;
using Proyecto.BLL.IServices;
using Proyecto.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.BLL.Services
{
    public class GenericService<T> : Proyecto.DAL.Repositories.GenericRepository<T>, Proyecto.BLL.IServices.IGenericService<T> where T : class
    {
    }
}