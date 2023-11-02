using System.Text.RegularExpressions;
using Task_ExceptionReflection.Exceptions;
namespace Task_ExceptionReflection.Models;

public class User
{
    static int _uniqueId = 1;
    string _name, _phonenumber, _password;
    byte _age;


    public User()
    {
        this.ID = User._uniqueId++;
    }


    //public readonly int ID;
    public int ID { get; }
    public string Name
    {
        get => _name; 
        set
        {
            if (value.Length < 2 || value.Length > 30)
            {
                throw new InvalidNameException(ExceptionMessages.InvalidName);
            }
            this._name = value;
        }
    }  
    public byte Age
    {
        get => _age;
        set
        {
            if (value < 1)
            {
                throw new InvalidAgeException(ExceptionMessages.InvalidAge);
            }
            this._age = value;
        }
    }
    public string PhoneNumber
    {
        get => _phonenumber;
        set
        {
            string PatternAz = "(?:0|\\+994)[\\W]{0,1}(?:12|51|50|55|70|77)[\\W]{0,1}[2-9][0-9]{2}[\\W]{0,1}[0-9]{2}[\\W]{0,1}[0-9]{2}";
            if (Regex.IsMatch(value, PatternAz)) 
            {
                this._phonenumber = value;
                return;
            }
            throw new InvalidPhoneNumberException(ExceptionMessages.InvalidPhoneNumber);
        }
    }
    public string Password
    {
        get => _password;
        set
        {
            if (value.Length >= 8)
            {
                byte flags = 0;
                //001 = 1 uppercase
                //010 = 2 digit
                //011 = 3
                for (int i = 0; i < value.Length; i++)
                {
                    if ((flags & 1) == 0 && Char.IsUpper(value[i]))
                    {
                        flags |= 1;
                    }
                    else if ((flags & 2) == 0 && Char.IsDigit(value[i]))
                    {
                        flags |= 2;
                    }
                    else if(flags == 3)
                    {
                        this._password = value;
                        return;
                    }
                }
            }
            throw new InvalidPasswordException(ExceptionMessages.InvalidPassword);
        }
    }

    static void ChangeUniqueId(int newId)
    {
        User._uniqueId = newId;
    }
}
