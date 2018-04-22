using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Redis.Business;
using Vueling.Redis.Common;

namespace Vueling.Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentBL stBl = new StudentBL();
            Student studenttest = new Student(1, "Nom", 50);
            Student studenttest2 = new Student(2, "Nom2", 5);

            List<Student> stlist = new List<Student>();

            stlist.Add(studenttest);
            stlist.Add(studenttest2);

            stBl.Add<Student>("test1", studenttest);
            stBl.Add<Student>("test1", studenttest2);

            stBl.Add<List<Student>>("test2", stlist);

            Console.WriteLine(stBl.Read<Student>("test1").Name);
            Console.ReadKey();
        }
    }
}
