using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App10.Interfaces
{
    public interface IDataService<T> where T : class
    {
        Task<T> GetDataAsync(string url);
    }
}
