using System;
using System.Collections.Generic;

namespace ExerciseBuilder
{
    public class CodingObject
    {
        private const string _indent = "  ";
        public CodingObject(string className)
        {
            this._className = className;
        }
        private string _className { get; set; }
        private Dictionary<string, string> _fields = new Dictionary<string, string>();
        public void Add(string fieldName, string fieldValue)
        {
            if (_fields == null) _fields = new Dictionary<string, string>();
            _fields.Add(fieldName, fieldValue);
        }
        public override string ToString()
        {
            string returnString = string.Empty;
            returnString += $"public class {this._className}\n";
            returnString += "{\n";
            foreach(var field in _fields)
            {
                returnString += $"{_indent}public {field.Value} {field.Key};\n";
            }
            returnString += "}";
            return returnString;
        }
    }
    public class CodeBuilder
    {
        CodingObject CodingObject;
        public CodeBuilder(string className)
        {
            CodingObject = new CodingObject(className);
        }
        public override string ToString()
        {
            return CodingObject.ToString();
        }
        public CodeBuilder AddField(string name, string type)
        {
            CodingObject.Add(name, type);
            return this;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Persion").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
            Console.ReadLine();
        }
    }
}
