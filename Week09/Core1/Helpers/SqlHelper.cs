using System.Data.SqlClient;
using System.Data;

namespace Core1.Helpers;

public static class SqlHelper
{
    private const string _connectionString = @"Server = DESKTOP-RB7OAC3\SQLEXPRESS;Database = AzMB101_Jafar_AdoNet_ORM;Trusted_Connection=true";
    
    public static string QGetAll(string table) => "SELECT * FROM " + table;
    public static string QGetById(string table, int id) => QGetAll(table) + " WHERE ID = " + id;
    public static string QDeleteById(string table, int id) => "DELETE " + table + " WHERE ID = " + id;
    public static string QInsert(string table, string[] values)
    {
        string query = $"INSERT INTO {table} (";
        DataTable dt = GetDatas(QGetAll(table));
        for (int i = 0; ;)
        {
            query += dt.Columns[++i];
            if (i < values.Length)
            {
                query += ", ";
            }
            else break;
        }
        query += ") VALUES (";

        for (int i = 0; ;)
        {
            query += values[i++];
            if (i < values.Length)
            {
                query += ", ";
            }
            else break;
        }
        return query + ")";
    }
    public static string QUpdate(string table, int id, string[] values)
    {
        string query = $"UPDATE {table} SET ";
        DataTable dt = GetDatas(QGetAll(table));

        for (int i = 0; ;)
        {
            query += dt.Columns[i + 1] + " = " + values[i++];
            if (i < values.Length)
            {
                query += ", ";
            }
            else break;
        }

        return query + " WHERE ID = " + id;
    }

    public static DataTable GetDatas(string query)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        DataTable dt = new DataTable();
        using SqlDataAdapter sda = new SqlDataAdapter(query, connection);

        sda.Fill(dt);
        connection.Close();
        return dt;
    }
    public static int Exec(string query)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand command = new SqlCommand(query, connection);

        int result = command.ExecuteNonQuery();
        connection.Close();
        return result;
    }
}