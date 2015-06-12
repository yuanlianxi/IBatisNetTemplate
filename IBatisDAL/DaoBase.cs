using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataAccess.Interfaces;
using IBatisNet.DataMapper;
using IBatisNet.DataAccess;
using IBatisNet.DataAccess.DaoSessionHandlers;
using System.Collections;
using IBatisNet.Common.Exceptions;
using IBatisNet.Common.Pagination;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Scope;
using System.Text.RegularExpressions;
using System.Data;
using IBatisNet.DataAccess.SessionStore;

namespace IBatisDAL
{
    public class DaoBase : IDao
    {
        protected const int PAGE_SIZE = 4;

        /// <summary>
        /// Looks up the parent DaoManager, gets the local transaction
        /// (which should be a SqlMapDaoTransaction) and returns the
        /// SqlMap associated with this DAO.
        /// </summary>
        /// <returns>The SqlMap instance for this DAO.</returns>
        protected ISqlMapper GetLocalSqlMap()
        {
            IDaoManager daoManager = DaoManager.GetInstance(this);
            //异步
            //HybridWebThreadSessionStore newSessionStore = new HybridWebThreadSessionStore(daoManager.Id);
            //daoManager.SessionStore = newSessionStore;

            SqlMapDaoSession sqlMapDaoSession = (SqlMapDaoSession)daoManager.LocalDaoSession;

            return sqlMapDaoSession.SqlMap;
        }

        //TODO:查询SQL
        protected string ShowSql(string statementName, object parameterObject)
        {
            //if (m_logger.IsDebugEnabled)
            //{
            string paramtype = "";
            if (parameterObject == null)
            {
                paramtype = "null";
            }
            else
                paramtype = parameterObject.GetType().ToString();
            string strSql = GetSql(statementName, parameterObject);
            if (string.IsNullOrEmpty(strSql) && strSql.Length > 1000)
            {
                strSql = strSql.Substring(0, 1000) + "...";
            }

            return strSql;
            //    m_logger.Debug("执行IBatis脚本:" + statementName, "\n参数类型:" + paramtype + "\nSQL语句:" + strSql);
            //}
        }

        /// <summary>
        /// Simple convenience method to wrap the SqlMap method of the same name.
        /// Wraps the exception with a IBatisNetException to isolate the SqlMap framework.
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        protected IList ExecuteQueryForList(string statementName, object parameterObject)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                if (!sqlMap.IsSessionStarted)
                {
                    sqlMap.OpenConnection();
                }
                ShowSql(statementName, parameterObject);
                return sqlMap.QueryForList(statementName, parameterObject);
            }
            catch (Exception e)
            {
                IBatisNetException newException = new IBatisNetException("Error executing query '" + statementName + "' for List.  SQL: " + GetSql(statementName, parameterObject), e);
                throw newException;
            }
        }

        /// <summary>
        /// Simple convenience method to wrap the SqlMap method of the same name.
        /// Wraps the exception with a IBatisNetException to isolate the SqlMap framework.
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <param name="skipResults"></param>
        /// <param name="maxResults"></param>
        /// <returns></returns>
        protected IList ExecuteQueryForList(string statementName, object parameterObject, int skipResults, int maxResults)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                if (!sqlMap.IsSessionStarted)
                {
                    sqlMap.OpenConnection();
                }
                ShowSql(statementName, parameterObject);
                return sqlMap.QueryForList(statementName, parameterObject, skipResults, maxResults);
            }
            catch (Exception e)
            {
                IBatisNetException newException = new IBatisNetException("Error executing query '" + statementName + "' for List.  SQL: " + GetSql(statementName, parameterObject), e);
                throw newException;
            }
        }

        /// <summary>
        /// Simple convenience method to wrap the SqlMap method of the same name.
        /// Wraps the exception with a IBatisNetException to isolate the SqlMap framework.
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        protected IList<T> ExecuteQueryForList<T>(string statementName, object parameterObject)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                if (!sqlMap.IsSessionStarted)
                {
                    sqlMap.OpenConnection();
                }
                ShowSql(statementName, parameterObject);
                return sqlMap.QueryForList<T>(statementName, parameterObject);
            }
            catch (Exception e)
            {
                IBatisNetException newException = new IBatisNetException("Error executing query '" + statementName + "' for Lisy.  SQL: " + GetSql(statementName, parameterObject), e);
                throw newException;
            }
        }

        /// <summary>
        /// Simple convenience method to wrap the SqlMap method of the same name.
        /// Wraps the exception with a IBatisNetException to isolate the SqlMap framework.
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <param name="skipResults"></param>
        /// <param name="maxResults"></param>
        /// <returns></returns>
        protected IList<T> ExecuteQueryForList<T>(string statementName, object parameterObject, int skipResults, int maxResults)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                if (!sqlMap.IsSessionStarted)
                {
                    sqlMap.OpenConnection();
                }
                ShowSql(statementName, parameterObject);
                return sqlMap.QueryForList<T>(statementName, parameterObject, skipResults, maxResults);
            }
            catch (Exception e)
            {
                IBatisNetException newException = new IBatisNetException("Error executing query '" + statementName + "' for List.  SQL: " + GetSql(statementName, parameterObject), e);
                throw newException;
            }
        }


        /// <summary>
        /// Simple convenience method to wrap the SqlMap method of the same name.
        /// Wraps the exception with a IBatisNetException to isolate the SqlMap framework.
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        protected IPaginatedList ExecuteQueryForPaginatedList(string statementName, object parameterObject, int pageSize)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                if (!sqlMap.IsSessionStarted)
                {
                    sqlMap.OpenConnection();
                }
                ShowSql(statementName, parameterObject);
                return sqlMap.QueryForPaginatedList(statementName, parameterObject, pageSize);
            }
            catch (Exception e)
            {
                IBatisNetException newException = new IBatisNetException("Error executing query '" + statementName + "' for List.  SQL: " + GetSql(statementName, parameterObject), e);
                throw newException;
            }
        }

        /// <summary>
        /// Simple convenience method to wrap the SqlMap method of the same name.
        /// Wraps the exception with a IBatisNetException to isolate the SqlMap framework.
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        protected object ExecuteQueryForObject(string statementName, object parameterObject)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();

            try
            {
                if (!sqlMap.IsSessionStarted)
                {
                    sqlMap.OpenConnection();
                }
                ShowSql(statementName, parameterObject);
                return sqlMap.QueryForObject(statementName, parameterObject);
            }
            catch (Exception e)
            {
                IBatisNetException newException = new IBatisNetException("Error executing query '" + statementName + "' for Object.  SQL: " + GetSql(statementName, parameterObject), e);
                throw newException;
            }
        }
        /// <summary>
        /// Simple convenience method to wrap the SqlMap method of the same name.
        /// Wraps the exception with a IBatisNetException to isolate the SqlMap framework.
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        protected T ExecuteQueryForObject<T>(string statementName, object parameterObject)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();

            try
            {
                if (!sqlMap.IsSessionStarted)
                {
                    sqlMap.OpenConnection();
                }
                ShowSql(statementName, parameterObject);
                return sqlMap.QueryForObject<T>(statementName, parameterObject);
            }
            catch (Exception e)
            {
                IBatisNetException newException = new IBatisNetException("Error executing query '" + statementName + "' for Object.  SQL: " + GetSql(statementName, parameterObject), e);
                throw newException;
            }
        }
        /// <summary>
        /// Simple convenience method to wrap the SqlMap method of the same name.
        /// Wraps the exception with a IBatisNetException to isolate the SqlMap framework.
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        protected int ExecuteUpdate(string statementName, object parameterObject)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();

            try
            {
                if (!sqlMap.IsSessionStarted)
                {
                    sqlMap.OpenConnection();
                }
                ShowSql(statementName, parameterObject);
                return sqlMap.Update(statementName, parameterObject);
            }
            catch (Exception e)
            {
                IBatisNetException newException = new IBatisNetException("Error executing query '" + statementName + "' for Update.  SQL: " + GetSql(statementName, parameterObject), e);
                throw newException;
            }
        }

        /// <summary>
        /// Simple convenience method to wrap the SqlMap method of the same name.
        /// Wraps the exception with a IBatisNetException to isolate the SqlMap framework.
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        protected object ExecuteInsert(string statementName, object parameterObject)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();

            try
            {
                if (!sqlMap.IsSessionStarted)
                {
                    sqlMap.OpenConnection();
                }
                ShowSql(statementName, parameterObject);
                return sqlMap.Insert(statementName, parameterObject);
            }
            catch (Exception e)
            {
                IBatisNetException newException = new IBatisNetException("Error executing query '" + statementName + "' for Object.  SQL: " + GetSql(statementName, parameterObject), e);
                throw newException;
            }
        }

        public string GetSql(string statementName, object paramObject)
        {
            ISqlMapper mapper = null;
            try
            {
                mapper = Mapper.Instance();
            }
            catch (Exception)
            {
                mapper = GetLocalSqlMap();
            }

            IMappedStatement statement = mapper.GetMappedStatement(statementName);
            if (!mapper.IsSessionStarted)
            {
                mapper.OpenConnection();
            }
            RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, paramObject, mapper.LocalSession);
            string strsql = scope.PreparedStatement.PreparedSql;
            Regex regex = new Regex(@"\s+");
            string strresult = regex.Replace(strsql, " ");
            return strresult;
        }

        protected object ExecuteDelete(string statementName, object parameterObject)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();

            try
            {
                if (!sqlMap.IsSessionStarted)
                {
                    sqlMap.OpenConnection();
                }
                ShowSql(statementName, parameterObject);
                return sqlMap.Delete(statementName, parameterObject);
            }
            catch (Exception e)
            {
                IBatisNetException newException = new IBatisNetException("Error executing query '" + statementName + "' for Object.  SQL: " + GetSql(statementName, parameterObject), e);
                throw newException;
            }
        }


        protected DataTable ExcuteForDataTable(string statementName, object parameterObject, string connectionType)
        {
            DateTime dt1 = DateTime.Now;
            string defaultConnection = string.Empty;
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                ShowSql(statementName, parameterObject);
                DataSet ds = new DataSet();
                IMappedStatement statement = sqlMap.GetMappedStatement(statementName);
                if (!sqlMap.IsSessionStarted)
                {
                    sqlMap.OpenConnection();
                }
                RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, parameterObject, sqlMap.LocalSession);
                statement.PreparedCommand.Create(scope, sqlMap.LocalSession, statement.Statement, parameterObject);
                IDbCommand command = scope.Session.CreateCommand(CommandType.Text);

                command.CommandText = scope.IDbCommand.CommandText;
                //IDbCommand command = scope.IDbCommand;
                for (int i = 0; i < scope.IDbCommand.Parameters.Count;)
                {
                    object o = scope.IDbCommand.Parameters[i];
                    scope.IDbCommand.Parameters.Remove(o);
                    command.Parameters.Add(o);
                }
                //IDbDataAdapter adapter = sqlMap.LocalSession.CreateDataAdapter(command);
                //adapter.SelectCommand = command;
                //adapter.Fill(ds);
                sqlMap.LocalSession.CreateDataAdapter(command).Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception e)
            {
                IBatisNetException newException = new IBatisNetException("Error executing query '" + statementName + "' for DataSet.  SQL: " + GetSql(statementName, parameterObject), e);
                throw newException;
            }
            finally
            {
                if (!string.IsNullOrEmpty(connectionType))
                {
                    sqlMap.DataSource.ConnectionString = defaultConnection;
                    sqlMap.CloseConnection();
                }
            }
        }
        /// <summary>
        /// 返回一个dataSet数据
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <param name="connectionType"></param>
        /// <returns></returns>
        protected DataSet ExcuteForDataSet(string statementName, object parameterObject, string connectionType)
        {
            DateTime dt1 = DateTime.Now;
            string defaultConnection = string.Empty;
            ISqlMapper sqlMap = GetLocalSqlMap();

            try
            {
                ShowSql(statementName, parameterObject);
                DataSet ds = new DataSet();
                IMappedStatement statement = sqlMap.GetMappedStatement(statementName);
                if (!sqlMap.IsSessionStarted)
                {
                    sqlMap.OpenConnection();
                }
                RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, parameterObject, sqlMap.LocalSession);
                statement.PreparedCommand.Create(scope, sqlMap.LocalSession, statement.Statement, parameterObject);
                IDbCommand command = sqlMap.LocalSession.CreateCommand(CommandType.Text);
                command.CommandText = scope.IDbCommand.CommandText;
                sqlMap.LocalSession.CreateDataAdapter(command).Fill(ds);
                return ds;

            }
            catch (Exception e)
            {
                IBatisNetException newException = new IBatisNetException("Error executing query '" + statementName + "' for DataSet.  SQL: " + GetSql(statementName, parameterObject), e);
                throw newException;
            }

            finally
            {
                if (!string.IsNullOrEmpty(connectionType))
                {
                    sqlMap.DataSource.ConnectionString = defaultConnection;
                    sqlMap.CloseConnection();
                }
            }
        }

        protected DataTable ExcuteForDataTable(string statementName, object parameterObject)
        {
            return ExcuteForDataTable(statementName, parameterObject, null);
        }

        protected DataSet ExcuteForDataSet(string statementName, object parameterObject)
        {
            return ExcuteForDataSet(statementName, parameterObject, null);
        }

        protected DataTable ExcuteForDataTable(string statementName, object parameterObject, int skipResults, int maxResults)
        {
            DateTime dt1 = DateTime.Now;
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                ShowSql(statementName, parameterObject);
                DataTable dt = new DataTable();
                IMappedStatement statement = sqlMap.GetMappedStatement(statementName);
                if (!sqlMap.IsSessionStarted)
                {
                    sqlMap.OpenConnection();
                }
                RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, parameterObject, sqlMap.LocalSession);
                statement.PreparedCommand.Create(scope, sqlMap.LocalSession, statement.Statement, parameterObject);
                // IDbCommand command = sqlMap.LocalSession.CreateCommand(CommandType.Text);
                // command.CommandText = scope.IDbCommand.CommandText;
                IDataReader reader = scope.IDbCommand.ExecuteReader();

                int fieldCount = reader.FieldCount;//Access to the current line number of rows
                for (int count = 0; count < fieldCount; count++)
                {
                    dt.Columns.Add(reader.GetName(count), reader.GetFieldType(count));
                }

                for (int i = 1; i < skipResults; i++)
                {
                    if (!reader.Read())
                    {
                        break;
                    }
                }
                int resultsFetched = 0;
                while (resultsFetched < maxResults && reader.Read())
                {
                    DataRow datarow = dt.NewRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        datarow[i] = reader[i];
                    }
                    dt.Rows.Add(datarow);
                    resultsFetched++;
                }
                if (!reader.IsClosed)
                {
                    reader.Close();
                    reader.Dispose();
                }
                return dt;

            }
            catch (Exception e)
            {
                IBatisNetException newException = new IBatisNetException("Error executing query '" + statementName + "' for DataSet.  SQL: " + GetSql(statementName, parameterObject), e);
                throw newException;
            }
        }


        protected DataTable ExecuteUpdateSql(string sql)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();

            try
            {
                if (!sqlMap.IsSessionStarted)
                {
                    sqlMap.OpenConnection();
                }

                IDbCommand command = sqlMap.LocalSession.CreateCommand(CommandType.Text);
                command.CommandText = sql;
                DataSet ds = new DataSet();
                sqlMap.LocalSession.CreateDataAdapter(command).Fill(ds);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                    return ds.Tables[0];
                return null;
            }
            catch (Exception e)
            {
                IBatisNetException newException = new IBatisNetException("Error executing query 'ExecuteUpdateSql' for Object.  SQL: " + sql, e);
                throw newException;
            }
        }


    }
}
