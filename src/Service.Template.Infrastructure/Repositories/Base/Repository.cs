
using Dapper; 
using Dapper.Contrib.Extensions;
using Service.Template.Domain.Enum; 
using Microsoft.Extensions.Configuration;
using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; using System.Linq; 
using static Dapper.SqlMapper;
using Service.Template.Domain.Interfaces.Repositories.Base;
using System.Data.SqlClient;

namespace Service.Template.Infrastructure.Repositories.Base
{
    public abstract class Repository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly string _connectionString;

        protected Repository(EDataBaseConnection eDataBaseConnection, IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(Convert.ToString((int)eDataBaseConnection));
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> GetMultiple<T1, T2>(string sql, object parameters,
                                        Func<GridReader, IEnumerable<T1>> func1,
                                        Func<GridReader, IEnumerable<T2>> func2)
        {
            var objs = ObterMultiple(sql, parameters, func1, func2);
            return Tuple.Create(objs[0] as IEnumerable<T1>, objs[1] as IEnumerable<T2>);
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> GetMultiple<T1, T2, T3>(string sql, object parameters,
                                        Func<GridReader, IEnumerable<T1>> func1,
                                        Func<GridReader, IEnumerable<T2>> func2,
                                        Func<GridReader, IEnumerable<T3>> func3)
        {
            var objs = ObterMultiple(sql, parameters, func1, func2, func3);
            return Tuple.Create(
                  objs[0] as IEnumerable<T1>
                , objs[1] as IEnumerable<T2>
                , objs[2] as IEnumerable<T3>);
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>> GetMultiple<T1, T2, T3, T4>(string sql, object parameters, Func<GridReader, IEnumerable<T1>> func1, Func<GridReader, IEnumerable<T2>> func2, Func<GridReader, IEnumerable<T3>> func3, Func<GridReader, IEnumerable<T4>> func4)
        {
            var objs = ObterMultiple(sql, parameters, func1, func2, func3, func4);
            return Tuple.Create(
                  objs[0] as IEnumerable<T1>
                , objs[1] as IEnumerable<T2>
                , objs[2] as IEnumerable<T3>
                , objs[3] as IEnumerable<T4>
                );
        }

    public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>
    GetMultiple<T1, T2, T3, T4, T5>(string sql, object parameters,
                                Func<GridReader, IEnumerable<T1>> func1,
                                Func<GridReader, IEnumerable<T2>> func2,
                                Func<GridReader, IEnumerable<T3>> func3,
                                Func<GridReader, IEnumerable<T4>> func4,
                                Func<GridReader, IEnumerable<T5>> func5
    )
        {
            var objs = ObterMultiple(sql, parameters, func1, func2, func3, func4, func5);
            return Tuple.Create(
                  objs[0] as IEnumerable<T1>
                , objs[1] as IEnumerable<T2>
                , objs[2] as IEnumerable<T3>
                , objs[3] as IEnumerable<T4>
                , objs[4] as IEnumerable<T5>
                );
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>
            GetMultiple<T1, T2, T3, T4, T5, T6>(string sql, object parameters,
                                        Func<GridReader, IEnumerable<T1>> func1,
                                        Func<GridReader, IEnumerable<T2>> func2,
                                        Func<GridReader, IEnumerable<T3>> func3,
                                        Func<GridReader, IEnumerable<T4>> func4,
                                        Func<GridReader, IEnumerable<T5>> func5,
                                        Func<GridReader, IEnumerable<T6>> func6
            )
        {
            var objs = ObterMultiple(sql, parameters, func1, func2, func3, func4, func5, func6);
            return Tuple.Create(
                  objs[0] as IEnumerable<T1>
                , objs[1] as IEnumerable<T2>
                , objs[2] as IEnumerable<T3>
                , objs[3] as IEnumerable<T4>
                , objs[4] as IEnumerable<T5>
                , objs[5] as IEnumerable<T6>
                );
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>
            GetMultiple<T1, T2, T3, T4, T5, T6, T7>(string sql, object parameters,
                                        Func<GridReader, IEnumerable<T1>> func1,
                                        Func<GridReader, IEnumerable<T2>> func2,
                                        Func<GridReader, IEnumerable<T3>> func3,
                                        Func<GridReader, IEnumerable<T4>> func4,
                                        Func<GridReader, IEnumerable<T5>> func5,
                                        Func<GridReader, IEnumerable<T6>> func6,
                                        Func<GridReader, IEnumerable<T7>> func7
            )
        {
            var objs = ObterMultiple(sql, parameters, func1, func2, func3, func4, func5, func6, func7);
            return Tuple.Create(
                  objs[0] as IEnumerable<T1>
                , objs[1] as IEnumerable<T2>
                , objs[2] as IEnumerable<T3>
                , objs[3] as IEnumerable<T4>
                , objs[4] as IEnumerable<T5>
                , objs[5] as IEnumerable<T6>
                , objs[6] as IEnumerable<T7>
                );
        }

        private List<object> ObterMultiple(string sql, object parameters, params Func<GridReader, object>[] readerFuncs)
        {
            var returnResults = new List<object>();
            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    var gridReader = con.QueryMultiple(sql, parameters);

                    foreach (var readerFunc in readerFuncs)
                    {
                        var obj = readerFunc(gridReader);
                        returnResults.Add(obj);
                    }
                }
                finally { con.Close(); con.Dispose(); }
            }

            return returnResults;
        }


        public virtual async Task<IEnumerable<TEntity>> Get(string query)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    return await con.QueryAsync<TEntity>(query);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    return await con.GetAllAsync<TEntity>();
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public virtual IEnumerable<TEntity> GetSync(string query)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    return con.Query<TEntity>(query);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public virtual IEnumerable<TEntity> GetAllSync()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    return con.GetAll<TEntity>();
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public virtual async Task<TEntity> GetById(long id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    return await con.GetAsync<TEntity>(id);
                }
                finally
                {
                    con.Close();
                }
            }
        }


        public TEntity GetByIdSync(long id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    return con.Get<TEntity>(id);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void SetId<T>(T obj, int id, IDictionary<string, object> propertyPairs)
        {
            if (propertyPairs.Count == 1)
            {
                var propertyName = propertyPairs.Keys.First();
                var propertyInfo = obj.GetType().GetProperty(propertyName);
                if (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(Int64))
                {
                    propertyInfo.SetValue(obj, id, null);
                }
            }
        }
        public void Insert(TEntity entity)
        {
            var propertyContainer = new DapperUtils().ParsePropertiesInsert(entity);
            var sql = string.Format("INSERT INTO [{0}] ({1}) VALUES (@{2}) SELECT CAST(scope_identity() AS int)",
            typeof(TEntity).Name,
            string.Join(", ", propertyContainer.ValueNames),
            string.Join(", @", propertyContainer.ValueNames));

            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    var id = con.Query<int>(sql, propertyContainer.ValuePairs, commandType: System.Data.CommandType.Text).First();

                    SetId(entity, id, propertyContainer.IdPairs);

                }
                catch (Exception ex)
                {
                    string sEx = ex.Message;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    return await con.UpdateAsync<TEntity>(entity);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public bool UpdateSync(TEntity entity)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    return con.Update<TEntity>(entity);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public virtual async Task<bool> Delete(TEntity entity)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    return await con.DeleteAsync<TEntity>(entity);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public virtual async Task<int> ExecuteCommand(string query)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    var resultado = (await con.ExecuteAsync(query));
                    return resultado;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public virtual async Task<bool> InsertCommand(string query)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    var rowsAffected = await con.ExecuteAsync(query);
                    return (rowsAffected > 0);
                }
                catch (Exception ex)
                {
                    string sEx = ex.Message;
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }


    }
}