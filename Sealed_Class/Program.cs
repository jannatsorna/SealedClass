using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sealed_Class   //can not inherit it, olny it can be a child class
{
    class Program
    {
        //passing value by constructor
        public sealed class Student
        {
            public int id { get; set; }
            public string name { get; set; }

            public Student() 
            {
                id = 2;
                name = "Professor";
            }
            public void Student_Info()
            {
                Console.WriteLine("Student Id : {0}  Student Name : {1}", id, name);
            }
        }

        //child class is sealed with using sealed method
        public class Teacher1
        {
            public int id = 78;
            public string name = "Ovi";

            public virtual void Teacher_Info()
            {
                Console.WriteLine("ID : {0}", id);
                Console.WriteLine("Name : {0}", name);
            }
        }
        public sealed class Teacher2 : Teacher1 //inherite a normal class into a sealed class
        {
            public double salary = 5500;
            public sealed override void Teacher_Info() //sealed method
            {
                Console.WriteLine("ID : {0}", id);
                Console.WriteLine("Name : {0}", name);
                Console.WriteLine("Salary : {0}", salary);
            }
        }

        //Employee cls is sealed which contain static list<person> type method 
        public class Person
        {
            public int NID { get; set; }
            public string Name { get; set; }

            public Person(int id, string name)
            {
                NID = id;
                Name = name;
            }
        }
        public sealed class Employee
        {
            public static List<Person> per = new List<Person>(new[]
            {
                new Person (1, "Tokyo"),
                new Person (2, "Rio"),
                new Person(3, "Berllin"),
                new Person(4, "Denver"),
            });
            public static List<Person> Get_Person_Details()
            {
                return per;
            }
        }







        static void Main(string[] args)
        {
            Student _std = new Student();
            _std.Student_Info();

            //   Teacher1 t_1 = new Teacher1();
            Teacher1 t_1 = new Teacher2(); //another advantage of inheritance of class
            t_1.Teacher_Info();//show info of Teacher2 class

            //   Teacher2 t_2 = new Teacher2();
            //   t_2.Teacher_Info();

            List<Person> ppp = new List<Person>();//for catch the value of the above list
            ppp = Employee.Get_Person_Details();
            foreach (Person data in ppp)
            {
                Console.WriteLine("Employee Id : {0},Employee Name : {1}", data.NID, data.Name);
            }
            Console.ReadLine();
        }
    }
}
