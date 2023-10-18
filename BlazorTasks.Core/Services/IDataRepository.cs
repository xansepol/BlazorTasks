using BlazorTasks.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTasks.Core.Services
{
    public interface IDataRepository<T>
    {
        Task<T?> Get(Guid id);
        Task<T[]> GetAll();
        Task<bool> Create(T item);
        Task<T> Update(T item);
        Task Delete(Guid id);
    }
}
