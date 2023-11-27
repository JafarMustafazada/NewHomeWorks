using Core1.Exceptions;

namespace Core1.Models;

public class Blogs
{
    int _id, _userId;
    string _title, _describtion;

    public int Id
    {
        get => this._id;
        set
        {
            if (value < 1) throw new InvalidIdException();
            this._id = value;
        }
    }
    public int UserId
    {
        get => this._userId;
        set
        {
            if (value < 1) throw new InvalidIdException();
            this._userId = value;
        }
    }
    public string Title
    {
        get => this._title;
        set
        {
            if (String.IsNullOrWhiteSpace(value)) this._title = "Title1";
            else this._title = value;
        }
    }
    public string Describtion
    {
        get => this._describtion;
        set
        {
            if (String.IsNullOrWhiteSpace(value)) this._describtion = "Description1";
            else this._describtion = value;
        }
    }
}
