using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_ExceptionReflection.Exceptions
{
    public abstract class UserExceeptions : Exception
    {
        public UserExceeptions() { }
        public UserExceeptions(string msg) : base(msg) { }
    }

    internal static class ExceptionMessages
    {
        public const string InvalidName = "Name should be min 2, max 30 characters.";
        public const string InvalidAge = "Age should beat least 1";
        public const string InvalidPhoneNumber = "Incorrect phonenumber";
        public const string InvalidPassword = "Password should be 8 characters where at least one capital and one digit.";
    }
}
