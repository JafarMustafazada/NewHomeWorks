using System.Runtime.Serialization;

namespace Task_ListCompanyEmployeeApp.Exceptions
{
    internal class EmployeeExceptions : Exception
    {
        public const string NotFounded = "Employee not founded.";

        public EmployeeExceptions() { }
        public EmployeeExceptions(string? message) : base(message) { }
    }
}