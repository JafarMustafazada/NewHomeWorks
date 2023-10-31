using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_StaticExtension.Extensions;

namespace Task_StaticExtension.Models;

internal class Student
{
    static int _uniqueId = 1;
    string _fullname = "_", _groupNo = "_"; // standart values
    byte _age = 0;

    public string FullName
    {
        get => this._fullname;
        set
        {
            if (value.CheckFullName()) this._fullname = value;
        }
    }
    public int ID { get; }
    public string GroupNo
    {
        get => this._groupNo;
        set
        {
            if (value.CheckGroupNo()) this._groupNo = value;
        }
    }
    public byte Age
    {
        get => this._age;
        set
        {
            if (value > 0) this._age = value;
        }
    }


    public Student(string FullName, string GroupNo, byte Age)
    {
        this.ID = Student._uniqueId++;
        this.FullName = FullName;
        this.Age = Age;
        this.GroupNo = GroupNo;
    }
}
