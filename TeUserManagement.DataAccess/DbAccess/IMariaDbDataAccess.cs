using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeUserManagement.DataAccess.DbAccess
{
    public interface IMariaDbDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters);
        Task SaveData<T>(string storedProcedure, T parameters);
    }
}