﻿using Dapper;
using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;

namespace OA.DataAccessLayer.Concrete.GenericRepository
{
	public class GenericRepository<T, InsertTRequest, UpdateTRequest> : IGenericRepository<T, InsertTRequest, UpdateTRequest>
	where T : class, new()
	where InsertTRequest : class
	where UpdateTRequest : class
	{
		private readonly ISqlToolsProvider _sqlToolsProvider;
		private readonly IDapperContext _dapperContext;
		private readonly ILogger<GenericRepository<T, InsertTRequest, UpdateTRequest>> _logger;

		public GenericRepository(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<T, InsertTRequest, UpdateTRequest>> logger)
		{
			_sqlToolsProvider = sqlToolsProvider;
			_dapperContext = dapperContext;
			_logger = logger;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			try
			{
				using (var sqlConnection = _dapperContext.GetConnection())
				{
					string tableName = _sqlToolsProvider.GetTableName<T>();
					(string? columnName, string propertyName) = _sqlToolsProvider.GetKeyColumnAndPropertyName<T>();

					var sql = $"DELETE FROM {tableName} WHERE {columnName} = @{propertyName};";
					var parameters = new DynamicParameters();
					parameters.Add($"@{propertyName}", id);

					var result = await sqlConnection.ExecuteAsync(sql, parameters);
					return result > 0;
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while deleting entity with ID {Id}", id);
				return false;
			}
		}

		public async Task<IEnumerable<T>> GetActivesAsync()
		{
			using (var sqlConnection = _dapperContext.GetConnection())
			{
				string tableName = _sqlToolsProvider.GetTableName<T>();
				Dictionary<string, string> columnNamePropertyNameDict = _sqlToolsProvider.GetColumnAndPropertyNames<T>();

				string columnNamesPropNames = _sqlToolsProvider.GetFormattedColumnsAndPropertyNames<T>(columnNamePropertyNameDict, "{0} AS {1}");

				var sql = $"SELECT {columnNamesPropNames} FROM {tableName} WHERE Status = 1";

				return await sqlConnection.QueryAsync<T>(sql);
			}
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			using (var sqlConnection = _dapperContext.GetConnection())
			{
				string tableName = _sqlToolsProvider.GetTableName<T>();
				Dictionary<string, string> columnNamePropertyNameDict = _sqlToolsProvider.GetColumnAndPropertyNames<T>();

				string columnNamesPropNames = _sqlToolsProvider.GetFormattedColumnsAndPropertyNames<T>(columnNamePropertyNameDict, "{0} AS {1}");

				var sql = $"SELECT {columnNamesPropNames} FROM {tableName}";

				return await sqlConnection.QueryAsync<T>(sql);
			}
		}

		public async Task<T> GetByIdAsync(int id)
		{
			try
			{
				using (var sqlConnection = _dapperContext.GetConnection())
				{
					string tableName = _sqlToolsProvider.GetTableName<T>();
					Dictionary<string, string> columnNamePropertyNameDict = _sqlToolsProvider.GetColumnAndPropertyNames<T>();

					string aliasedColumnNamesPropNames = _sqlToolsProvider.GetFormattedColumnsAndPropertyNames<T>(columnNamePropertyNameDict, "{0} AS {1}");

					(string? columnName, string propertyName) = _sqlToolsProvider.GetKeyColumnAndPropertyName<T>();

					var sql = $"SELECT {aliasedColumnNamesPropNames} FROM {tableName} WHERE {columnName} = @{propertyName}";

					var parameters = new DynamicParameters();
					parameters.Add($"@{propertyName}", id);

					var values = await sqlConnection.QueryFirstOrDefaultAsync<T>(sql, parameters);

					return values!;
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while retrieving entity with ID {Id}", id);
				return null!;
			}
		}

		public async Task<bool> InsertAsync(InsertTRequest request)
		{
			try
			{
				using (var sqlConnection = _dapperContext.GetConnection())
				{
					string tableName = _sqlToolsProvider.GetTableName<T>();
					Dictionary<string, string> columnNamePropertyNameDict = _sqlToolsProvider.GetColumnAndPropertyNames<T>(key: false);

					var columnsToInsert = columnNamePropertyNameDict.Keys
						.Where(key => key != "CreatedAt" && key != "Status");

					var sql = $"INSERT INTO {tableName} ({string.Join(", ", columnsToInsert)}) " +
							  $"VALUES ({string.Join(", ", columnsToInsert.Select(propName => $"@{columnNamePropertyNameDict[propName]}"))})";

					var parameters = new DynamicParameters();
					foreach (var prop in columnsToInsert)
					{
						parameters.Add($"@{columnNamePropertyNameDict[prop]}", typeof(InsertTRequest).GetProperty(columnNamePropertyNameDict[prop])?.GetValue(request));
					}

					int rowsAffected = await sqlConnection.ExecuteAsync(sql, parameters);
					return rowsAffected > 0;
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while inserting entity.");
				return false;
			}
		}

		public async Task<bool> RemoveAsync(int id)
		{
			try
			{
				using (var sqlConnection = _dapperContext.GetConnection())
				{
					string tableName = _sqlToolsProvider.GetTableName<T>();
					(string? columnName, string propertyName) = _sqlToolsProvider.GetKeyColumnAndPropertyName<T>();

					var sql = $"UPDATE {tableName} SET Status = 0 WHERE {columnName} = @{propertyName};";
					var parameters = new DynamicParameters();
					parameters.Add($"@{propertyName}", id);

					var result = await sqlConnection.ExecuteAsync(sql, parameters);
					return result > 0;
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while removing entity with ID {Id}", id);
				return false;
			}
		}

		public async Task<bool> UpdateAsync(UpdateTRequest request)
		{
			try
			{
				using (var sqlConnection = _dapperContext.GetConnection())
				{
					string tableName = _sqlToolsProvider.GetTableName<T>();
					Dictionary<string, string> columnNamePropertyNameDict = _sqlToolsProvider.GetColumnAndPropertyNames<T>(key: false);

					(string? columnName, string propertyName) = _sqlToolsProvider.GetKeyColumnAndPropertyName<T>();

					string aliasedColumnNamesPropNames = _sqlToolsProvider.GetFormattedColumnsAndPropertyNames<T>(columnNamePropertyNameDict, "{0} = @{1}");

					var sql = $"UPDATE {tableName} SET {aliasedColumnNamesPropNames} WHERE {columnName} = @{propertyName}";

					var parameters = new DynamicParameters();
					foreach (var prop in columnNamePropertyNameDict.Values)
					{
						parameters.Add($"@{prop}", typeof(UpdateTRequest).GetProperty(prop)?.GetValue(request));
					}
					parameters.Add($"@{propertyName}", typeof(UpdateTRequest).GetProperty(propertyName)?.GetValue(request));

					int rowsAffected = await sqlConnection.ExecuteAsync(sql, parameters);
					return rowsAffected > 0;
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while updating entity.");
				return false;
			}
		}
	}
}
