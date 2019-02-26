using System;
using static DotNetDesignPatternDemos.Creational.Person;

namespace DotNetDesignPatternDemos.Creational
{
    public class Person
    {
        public string Name;

        public string Position;

        public class Builder : PersonJobBuilder<Builder> { /* degenerate */ }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersonBuilder<SELF>
      where SELF : PersonBuilder<SELF>
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    public class PersonInfoBuilder<T> : PersonBuilder<PersonInfoBuilder<T>>
      where T : PersonInfoBuilder<T>
    {
        public T Called(string name)
        {
            person.Name = name;
            return (T)this;
        }
    }

    public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
      where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }

    public class BuilderInheritanceDemo
    {
        static void Main(string[] args)
        {
            var builder = new Builder();
            var person = builder.WorksAsA("sale").Called("minh").Build();
            //giải nghĩa đoạn trên
            //person = builder. ==> đến đây build chính là new Builder() nến chính là PersonJobBuilder do Builder kế thừa PersonJobBuilder<Builder> 
            // ==> nó gọi được hàm WorksAsA
            //builder.WorksAsA("sale") thì là hàm return T(this) chính là return Build ==> chính là return PersonJobBuilder, mà PersonJobBuilder là PersonInfoBuilder do PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
            // ==> nó gọi được hàm Called
            // .Build() trả về person và in ra


            Console.WriteLine(person);

            var me = Person.New.Called("vinh").WorksAsA("IT").Build();
            //giải nghĩa đoạn này:
            //Person.New chính là property return ra new Builder() sau đó giống đoạn giải nghĩa ở trên
            Console.WriteLine(me);

            Console.ReadLine();
        }
    }
}