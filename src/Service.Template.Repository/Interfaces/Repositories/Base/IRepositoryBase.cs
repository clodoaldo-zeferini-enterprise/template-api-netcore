using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Service.Template.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Tuple<IEnumerable<T1>, IEnumerable<T2>> GetMultiple<T1, T2>(string sql, object parameters,
            Func<GridReader, IEnumerable<T1>> func1, Func<GridReader, IEnumerable<T2>> func2);

        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> GetMultiple<T1, T2, T3>(string sql, object parameters,
            Func<GridReader, IEnumerable<T1>> func1,
            Func<GridReader, IEnumerable<T2>> func2,
            Func<GridReader, IEnumerable<T3>> func3);

        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>> GetMultiple<T1, T2, T3, T4>(string sql, object parameters,
            Func<GridReader, IEnumerable<T1>> func1,
            Func<GridReader, IEnumerable<T2>> func2,
            Func<GridReader, IEnumerable<T3>> func3,
            Func<GridReader, IEnumerable<T4>> func4
        );

        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>> GetMultiple<T1, T2, T3, T4, T5>(string sql, object parameters,
            Func<GridReader, IEnumerable<T1>> func1,
            Func<GridReader, IEnumerable<T2>> func2,
            Func<GridReader, IEnumerable<T3>> func3,
            Func<GridReader, IEnumerable<T4>> func4,
            Func<GridReader, IEnumerable<T5>> func5
        );

        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>> GetMultiple<T1, T2, T3, T4, T5, T6>(string sql, object parameters,
            Func<GridReader, IEnumerable<T1>> func1,
            Func<GridReader, IEnumerable<T2>> func2,
            Func<GridReader, IEnumerable<T3>> func3,
            Func<GridReader, IEnumerable<T4>> func4,
            Func<GridReader, IEnumerable<T5>> func5,
            Func<GridReader, IEnumerable<T6>> func6
        );

        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>> GetMultiple<T1, T2, T3, T4, T5, T6, T7>(string sql, object parameters,
            Func<GridReader, IEnumerable<T1>> func1,
            Func<GridReader, IEnumerable<T2>> func2,
            Func<GridReader, IEnumerable<T3>> func3,
            Func<GridReader, IEnumerable<T4>> func4,
            Func<GridReader, IEnumerable<T5>> func5,
            Func<GridReader, IEnumerable<T6>> func6,
            Func<GridReader, IEnumerable<T7>> func7
        );

        Task<IEnumerable<TEntity>> Get(string query);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task<bool> InsertCommand(string query);
        Task<bool> Insert(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<int> ExecuteCommand(string query);
        IEnumerable<TEntity> GetSync(string query);
        IEnumerable<TEntity> GetAllSync();
        TEntity GetByIdSync(Guid id);
        bool UpdateSync(TEntity entity);

    }

}
