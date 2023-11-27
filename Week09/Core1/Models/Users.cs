using Core1.Exceptions;

namespace Core1.Models;

public class Users
{
    int _id;
    string _name, _surname, _username, _password;

    public int Id 
    {
        get => this._id;
        set
        {
            if (value < 1) throw new InvalidIdException();
            this._id = value;
        }
    }
    public string Name
    {
        get => this._name;
        set
        {
            if(String.IsNullOrWhiteSpace(value)) this._name = "Name1";
            else this._name = value;
        }
    }
    public string Surname
    {
        get => this._surname;
        set
        {
            if (String.IsNullOrWhiteSpace(value)) this._surname = "Surname1";
            else this._surname = value;
        }
    }
    public string Username
    {
        get => this._username;
        set
        {
            if (String.IsNullOrWhiteSpace(value)) throw new InvalidSizeUserException();
            else this._username = value;
        }
    }
    public string Password
    {
        get => this._password;
        set
        {
            if (String.IsNullOrWhiteSpace(value)) throw new InvalidSizeUserException();
            else this._password = value;
        }
    }
}
