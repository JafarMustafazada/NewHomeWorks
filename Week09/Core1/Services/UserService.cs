using Core1.Exceptions;
using Core1.Helpers;
using Core1.Models;
using System.Data;

namespace Core1.Services;

public class UserService
{
    static Users _currentUser = new Users();

    public static bool IsLogin() => _currentUser.Id > 0;
    public static string Welcome() => UserService._currentUser.Name + " " + UserService._currentUser.Surname;
    public static void Delete(int id)
    {
        SqlHelper.Exec(SqlHelper.QDeleteById("Blogs", id) +
            $" AND {UserService._currentUser.Id} = Blogs.[User_ID]");
    }
    public static void Create(Blogs Data)
    {
        SqlHelper.Exec(SqlHelper.QInsert("Blogs", new string[] {
            $"'{Data.Title}'", $"'{Data.Describtion}'", $"'{UserService._currentUser.Id}'"
        }));
    }
    public static void Edit(int id, Blogs Data)
    {
        SqlHelper.Exec(SqlHelper.QUpdate("Blogs", id, new string[] {
            $"'{Data.Title}'", $"'{Data.Describtion}'"
        }) + $" AND {UserService._currentUser.Id} = Blogs.[User_ID]");

    }
    public static int Register(Users user)
    {
        DataTable dt = SqlHelper.GetDatas(SqlHelper.QGetAll("Users") + $" WHERE Username = '{user.Username}'");
        if (dt.Rows.Count > 0) throw new UsernameExistException();

        SqlHelper.Exec(SqlHelper.QInsert("Users", new string[] {
            $"'{user.Name}'", $"'{user.Surname}'",
            $"'{user.Username}'", $"HASHBYTES('SHA2_256', '{user.Password}')" }));

        dt = SqlHelper.GetDatas(SqlHelper.QGetAll("Users") + $" WHERE Username = '{user.Username}'");
        return (int)(dt.Rows[0]["ID"]);
    }

    public static bool Login(string username, string password)
    {
        DataTable dt = SqlHelper.GetDatas(SqlHelper.QGetAll("Users")
            + $" WHERE Username = '{username}'"
            + $" AND [Password] = HASHBYTES('SHA2_256', '{password}')");

        if (dt.Rows.Count > 0)
        {
            UserService._currentUser.Id = (int)dt.Rows[0]["ID"];
            UserService._currentUser.Name = (string)dt.Rows[0]["Name"];
            UserService._currentUser.Surname = (string)dt.Rows[0]["Surname"];
            UserService._currentUser.Username = username;
            UserService._currentUser.Password = password;
            return true;
        }
        else return false;
    }
}
