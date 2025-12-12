
//using System.Security.Cryptography.X509Certificates;

using System.Data;
using System.Net.Http.Headers;

namespace LINQDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //void--Action----takes a parameter---type(int)---action name(action)---name of parameter i--->go inside method (lambda=>)
            //Action<int> action = i => Console.WriteLine(i);
            //action(10);

            //Print name(String) using the Action



            //Emp.printname("Harish");
            //Emp.strlength("hello");

            //Emp e = new Emp();
            //e.PrintLength("hello");


            //Action<string, string> concatstrings = (s1, s2) => 
            //{ 
            //  string s3=string.Conc
            //  at(s1, s2);
            //    Console.WriteLine(s3);
            //    Console.WriteLine(s3.ToLower());
            //    Console.WriteLine(s3.ToUpper());

            //};

            //concatstrings("John", "Doe");

            //  Func<string, string, string> f1 = (s1, s2) => 
            //  {
            //      string s3 = string.Concat(s1, s2);

            //          Console.WriteLine(s3.ToLower());
            //          Console.WriteLine(s3.ToUpper());
            //      return s3;

            //  };
            //  string output=f1("John", "King");
            //  Console.WriteLine(output);


            //  Func<string, string, bool> addnos = (i, j) => 
            //  {
            //      int no1 = Convert.ToInt32(i);
            //      int no2 = Convert.ToInt32(j);
            //      int no3 = no1 + no2;
            //      if (no3 % 2 == 0)
            //          return true;
            //      else
            //          return false;

            //  };

            //  bool ans=addnos("10", "20");
            //  Console.WriteLine(ans);

            //  //input parameters--float,double and int is output parameter
            //  //  Func<float, double, bool> f2 = (i, j) => { };

            //  Predicate<int> isEven = (i) => 
            //  { 
            //  if(i%2==0) 
            //          return true;
            //      else

            //          return false;


            //  };

            //  int i = 11, j = 12;
            //  bool isnumberEven=isEven(i);
            //  Console.WriteLine($"{i} {isnumberEven}");
            //isnumberEven=isEven(j);
            //  Console.WriteLine($"{j} {isnumberEven}");
            //
            //

            //WorkingWithLINQArray();

            //WorkingWithList();



            // EagerLoadingWithToListToArrayCountAny();

            //groupBy();

            //SelectNew();


            //AggregateFunctionsDemo();



            //InnerJoinExample1();



            //InnerJoinExample2();


            //  LeftJoinExample();


            // RightJoinExample();



            //FullJoinExample();



            //SelectAndSelectMany();

            //OrderByThenBy();


            //CrossJoinsUsingAnonymousTypes();





            CrossJoinExample2();

        }

        private static void CrossJoinExample2()
        {
            Skills[] skills = new Skills[] {
            new Skills{SkillName="Azure" },
            new Skills { SkillName="AWS"},
            new Skills{SkillName="GCP" },
            new Skills{ SkillName="LowCode"},
            new Skills{ SkillName="NoCode" },
            new Skills{ SkillName="PowerBI"},

            };

            Stud[] studs = new Stud[2] {
            new Stud{Name="John" },
            new Stud{Name="Gauri" }
            };

            var cross = studs.SelectMany(s => skills, (s, sk) => new { studname = s.Name, skilldata = sk.SkillName });

            foreach (var item in cross)
            {
                Console.WriteLine(item.studname + "  " + item.skilldata);


            }
        }

        private static void CrossJoinsUsingAnonymousTypes()
        {
            var skills = new[] {
            new {SkillNames="AWS,Azure,GCP" },
            new {SkillNames="PowerBI,LowCode,NoCode" }
            };

            var students = new[] {

                new {Name="John",SkillsPossessed=skills[0] },
                new {Name="Gauri",SkillsPossessed=skills[1] }
            };

            var crossjoin = students.SelectMany(s => skills, (s, sk) => new { studname = s.Name, studdataSkills = sk.SkillNames }).ToList();

            foreach (var item in crossjoin)
            {
                Console.WriteLine(item.studname);
                Console.WriteLine(item.studdataSkills);
                Console.WriteLine();
            }
        }

        private static void OrderByThenBy()
        {
            List<Employee> emplist = new List<Employee>
            {
            new Employee{Employeeid=11,Empname="Anish",Deptno=10 },
            new Employee{Employeeid=2,Empname="Binita",Deptno=10 },
            new Employee{Employeeid=13,Empname="Sima",Deptno=20 },
            new Employee{Employeeid=41,Empname="Rima",Deptno=30 },
            new Employee{Employeeid=14,Empname="Tina",Deptno=30 },
              new Employee{Employeeid=5,Empname="Elina",Deptno=20 },

            };
            //primary                       //secondary
            //var orderedData = emplist.OrderBy(d => d.Deptno).ThenBy(e => e.Employeeid);

            var orderedData = from e in emplist
                              orderby e.Deptno, e.Employeeid
                              select e;

            foreach (var item in orderedData)
            {
                Console.WriteLine(item.Employeeid + " " + item.Empname + item.Deptno);
            }

            Console.WriteLine("------------------------");
            var orderedList = (from e in emplist
                               orderby e.Deptno, e.Employeeid
                               select e).ToList();

            orderedList.Reverse();
            foreach (var item in orderedList)
            {
                Console.WriteLine(item.Employeeid + " " + item.Empname + item.Deptno);
            }
            Console.WriteLine("=======================");


            var DescendingorderedList = (from e in emplist
                                         orderby e.Deptno, e.Employeeid descending
                                         select e).ToList();

            foreach (var item in DescendingorderedList)
            {
                Console.WriteLine(item.Employeeid + " " + item.Empname + item.Deptno);
            }

            Console.WriteLine("---------");
            Console.WriteLine("Method Syntax");
            Console.WriteLine();
            var methodSyntaxOrdering = emplist.OrderBy(d => d.Deptno).ThenByDescending(d1 => d1.Employeeid);

            foreach (var item in methodSyntaxOrdering)
            {
                Console.WriteLine(item.Employeeid + " " + item.Empname + item.Deptno);
            }
        }

        private static void SelectAndSelectMany()
        {
            var empSkills = new[]
            {
                new { EmpName="John",Skills=new[] {
                    "C","C++","C#" } },
                new { EmpName="Gill",Skills=new[] {"Angular","JS","React" } },
                new { EmpName="Jim",Skills=new[] {"HTML","CSS","SQL" } },
            };

            //Non flattened data
            var data = empSkills.Select(e => e.Skills);
            foreach (var item in data)
            {
                //   Console.WriteLine(item);
                foreach (var item1 in item)
                {
                    Console.WriteLine(item1);
                }
            }
            Console.WriteLine("==========");
            //flattend data
            var selectManyData = empSkills.SelectMany(s => s.Skills);
            foreach (var item in selectManyData)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("---------");


            var skills = new[] {
            new {SkillNames="AWS,Azure,GCP" },
            new {SkillNames="PowerBI,LowCode,NoCode" }
            };

            var students = new[] {

                new {Name="John",SkillsPossessed=skills[0] },
                new {Name="Gauri",SkillsPossessed=skills[1] }
            };
            var selectManyExample = students.SelectMany(s => s.SkillsPossessed.SkillNames.Split(","));

            foreach (var item in selectManyExample)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("-----");
            var selectExample = students.Select(s => s.SkillsPossessed.SkillNames.Split(","));
            foreach (var item in selectExample)
            {
                //Console.WriteLine(item);//[]
                foreach (var item1 in item)
                {
                    Console.WriteLine(item1);
                }
            }
        }

        private static void FullJoinExample()
        {
            List<Dept> deptlist = new List<Dept>()
            {
            new Dept{ Deptid=10,Deptname="HR"},
            new Dept{ Deptid=20,Deptname="Training"},
            };

            List<Employee> emplist = new List<Employee>
            {
            new Employee{Employeeid=1,Empname="A",Deptno=10 },
            new Employee{Employeeid=2,Empname="B",Deptno=10 },
            new Employee{Employeeid=3,Empname="C",Deptno=10 },
            new Employee{Employeeid=4,Empname="D",Deptno=10 },
              new Employee{Employeeid=5,Empname="E",Deptno=null },

            };

            var leftjoinresult = from e in emplist
                                 join d in deptlist
                               on e.Deptno equals d.Deptid into deptGroup
                                 from d in deptGroup.DefaultIfEmpty()
                                 select new { EmpName = e.Empname, Dept = d?.Deptname };


            //                     //LHS =deptlist                RHS=emplist
            var rightjoinresult = from d in deptlist
                                  join e in emplist
                                on d.Deptid equals e.Deptno into empGroup
                                  from e in empGroup.DefaultIfEmpty()
                                  select new { EmpName = e?.Empname, Dept = d?.Deptname };

            var fulljoinresult = leftjoinresult.Union(rightjoinresult);

            foreach (var item in fulljoinresult)
            {
                Console.WriteLine(item.Dept + " " + item.EmpName);
            }
        }

        private static void RightJoinExample()
        {
            List<Dept> deptlist = new List<Dept>()
            {
            new Dept{ Deptid=10,Deptname="HR"},
            new Dept{ Deptid=20,Deptname="Training"},
            };

            List<Employee> emplist = new List<Employee>
            {
            new Employee{Employeeid=1,Empname="A",Deptno=10 },
            new Employee{Employeeid=2,Empname="B",Deptno=10 },
            new Employee{Employeeid=3,Empname="C",Deptno=10 },
            new Employee{Employeeid=4,Empname="D",Deptno=10 },
              new Employee{Employeeid=5,Empname="E",Deptno=null },

            };


            //                     //LHS =deptlist                RHS=emplist
            var rightjoinresult = from d in deptlist
                                  join e in emplist
                                on d.Deptid equals e.Deptno into deptGroup
                                  from e in deptGroup.DefaultIfEmpty()
                                  select new { EmpName = e?.Empname ?? "No Employees in this Dept yet!!", Dept = d?.Deptname };

            foreach (var item in rightjoinresult)
            {
                Console.WriteLine(item.EmpName + " " + item.Dept);
            }
        }

        private static void LeftJoinExample()
        {
            List<Dept> deptlist = new List<Dept>()
            {
            new Dept{ Deptid=10,Deptname="HR"},
            new Dept{ Deptid=20,Deptname="Training"},
            };

            List<Employee> emplist = new List<Employee>
            {
            new Employee{Employeeid=1,Empname="A",Deptno=10 },
            new Employee{Employeeid=2,Empname="B",Deptno=10 },
            new Employee{Employeeid=3,Empname="C",Deptno=10 },
            new Employee{Employeeid=4,Empname="D",Deptno=10 },
              new Employee{Employeeid=5,Empname="E",Deptno=null },

            };


            //                     //LHS =emplist                RHS=deptlist
            //var leftjoinresult = from e in emplist
            //                     join d in deptlist
            //                   on e.Deptno equals d.Deptid into deptGroup
            //                     from d in deptGroup.DefaultIfEmpty()
            //                     select new {e.Empname,Dept=d?.Deptname ?? "No Deparment" };

            //foreach (var item in leftjoinresult)
            //{

            //    Console.WriteLine(item.Empname + " " + item.Dept);
            //}


            //To work with left join in method syntax---use Group Join
            var methodSyntaxLeftJoinResult = emplist.GroupJoin(deptlist, e => e.Deptno, d => d.Deptid,
                (e, deptGroup) => new { e, deptGroup }).SelectMany(x => x.deptGroup.DefaultIfEmpty(),
                (x, d) => new { employeeName = x.e.Empname, DepartmentName = d?.Deptname ?? "No deparment-" });

            foreach (var item in methodSyntaxLeftJoinResult)
            {

                Console.WriteLine(item.employeeName + " " + item.DepartmentName);
            }
        }

        private static void InnerJoinExample2()
        {
            List<Dept> deptlist = new List<Dept>()
            {
            new Dept{ Deptid=10,Deptname="HR"},
            new Dept{ Deptid=20,Deptname="Training"},
            };

            List<Employee> emplist = new List<Employee>
            {
            new Employee{Employeeid=1,Empname="A",Deptno=10 },
            new Employee{Employeeid=2,Empname="B",Deptno=10 },
            new Employee{Employeeid=3,Empname="C",Deptno=10 },
            new Employee{Employeeid=4,Empname="D",Deptno=10 },
              new Employee{Employeeid=4,Empname="E",Deptno=null },

            };
            //Inner Join

            var empDeptlist = deptlist.Join(emplist,
                d => d.Deptid,
                e => e.Deptno,
                (d, e) => new { Empno = e.Employeeid, EmployeeName = e.Empname, EmpSalary = e.Salary, DepartmentName = d.Deptname, DepartmentID = d.Deptid });

            foreach (var item in empDeptlist)
            {
                Console.WriteLine(item.DepartmentID + " " + item.DepartmentName + "   " + item.Empno + " " + item.EmployeeName + "  " + item.EmpSalary);
            }
        }

        private static void InnerJoinExample1()
        {
            //1 Category---M Products

            List<Category> categories = new List<Category>()
            {
                new Category {Categoryid=1,CategoryName="Beverages" } ,
                new Category {Categoryid=2,CategoryName="Snacks" }
            };
            List<Products> products = new List<Products>()
            {
            new Products{Prodid=1,Prodname="Tea",Price=10,Categoryid=1 },
            new Products{Prodid=2,Prodname="Coffee",Price=20,Categoryid=1 },
            new Products{Prodid=3,Prodname="Idli",Price=50,Categoryid=2 },
            new Products{Prodid=4,Prodname="Poha",Price=10,Categoryid=2 },
            new Products{Prodid=5,Prodname="ABC",Price=10,Categoryid=null },

              };

            //Inner Join
            var joinedResult = categories.Join(products,
                c => c.Categoryid,
                p => p.Categoryid,
                (c, p) => new { Name = c.CategoryName, Product = p.Prodname });


            foreach (var item in joinedResult)
            {
                //  Console.WriteLine(item.Name +  "----" + item.Product);
                Console.WriteLine($"{item.Product} is in category = {item.Name}");

            }
        }

        private static void AggregateFunctionsDemo()
        {
            List<Student> students = new List<Student>() {

            new Student{RollNo=1,StudName="Anish",CourseName="C",Fees=10000},
            new Student{RollNo=2,StudName="Manish",CourseName="C",Fees=10000},
            new Student{RollNo=3,StudName="Ana",CourseName="C++",Fees=30000},
            new Student{RollNo=4,StudName="Mina",CourseName="C#",Fees=40000},
            new Student{RollNo=5,StudName="Rina",CourseName="C",Fees=10000},
            new Student{RollNo=6,StudName="Amrit",CourseName="C++",Fees=30000},
            new Student{RollNo=7,StudName="Anisha",CourseName="C#",Fees=40000},
            new Student{RollNo=8,StudName="Niharika",CourseName="C",Fees=10000}
                  };

            var groupedresult = from s in students
                                group s by s.CourseName into g
                                select new { CrsName = g.Key, totalfees = g.Sum(s1 => s1.Fees), studentCnt = g.Count(), minfees = g.Min(m => m.Fees) };
            foreach (var item in groupedresult)
            {
                Console.WriteLine("CourseName= " + item.CrsName);
                Console.WriteLine(item.totalfees);
                Console.WriteLine(item.studentCnt);
                Console.WriteLine("Min fees=" + item.minfees);

            }

            Console.WriteLine("------------");

            var minimumfees = (from s in students
                               select s.Fees).Min();
            Console.WriteLine(minimumfees);
        }

        private static void SelectNew()
        {
            List<Student> students = new List<Student>() {

            new Student{RollNo=1,StudName="Anish",CourseName="C",Age=21},
            new Student{RollNo=2,StudName="Manish",CourseName="C",Age=22},
            new Student{RollNo=3,StudName="Ana",CourseName="C++",Age=21},
            new Student{RollNo=4,StudName="Mina",CourseName="C#",Age=23},
            new Student{RollNo=5,StudName="Rina",CourseName="C",Age=20},
            new Student{RollNo=6,StudName="Amrit",CourseName="C++",Age=21},
            new Student{RollNo=7,StudName="Anisha",CourseName="C#",Age=23},
            new Student{RollNo=8,StudName="Niharika",CourseName="C",Age=19},
                  };

            var alldata = from s in students
                          select new { ID = s.RollNo, ParticipantName = s.StudName };

            foreach (var item in alldata)
            {
                Console.WriteLine(item.ID + "  " + item.ParticipantName);
            }
        }

        private static void groupBy()
        {
            List<Student> students = new List<Student>() {

            new Student{RollNo=1,StudName="Anish",CourseName="C"},
            new Student{RollNo=2,StudName="Manish",CourseName="C"},
            new Student{RollNo=3,StudName="Ana",CourseName="C++"},
            new Student{RollNo=4,StudName="Mina",CourseName="C#"},
            new Student{RollNo=5,StudName="Rina",CourseName="C"},
            new Student{RollNo=6,StudName="Amrit",CourseName="C++"},
            new Student{RollNo=7,StudName="Anisha",CourseName="C#"},
            new Student{RollNo=8,StudName="Niharika",CourseName="C"},
                  };

            var studentsByCourseName = from s in students
                                       orderby s.CourseName
                                       group s by s.CourseName into Courses
                                       select Courses;
            foreach (var item in studentsByCourseName)
            {
                Console.WriteLine("Course =" + item.Key);
                foreach (var item1 in item)
                {
                    Console.WriteLine(item1.RollNo + " " + item1.StudName);
                }
            }

            Console.WriteLine("==================");
            Console.WriteLine("Method Syntax");
            Console.WriteLine();
            var groupedCrs = students.GroupBy(s => s.CourseName).OrderBy(g => g.Key).ToList();
            foreach (var item in groupedCrs)
            {
                Console.WriteLine("Course =" + item.Key);
                foreach (var item1 in item)
                {
                    Console.WriteLine(item1.RollNo + " " + item1.StudName);
                }
            }


            Console.WriteLine("==================");


            List<Products> products = new List<Products>();
            products.Add(new Products { Prodid = 1, Prodname = "Chai", Price = 10, Categoryid = 1 });
            products.Add(new Products { Prodid = 12, Prodname = "Coffe", Price = 20, Categoryid = 1 });

            products.Add(new Products { Prodid = 31, Prodname = "Dosa", Price = 50, Categoryid = 3 });
            products.Add(new Products { Prodid = 14, Prodname = "Idli", Price = 60, Categoryid = 3 });

            products.Add(new Products { Prodid = 15, Prodname = "Icecream", Price = 40, Categoryid = 2 });

            var groupByCategory = from p in products
                                  orderby p.Categoryid
                                  group p by p.Categoryid into CategoryGroup
                                  select CategoryGroup;

            foreach (var item in groupByCategory)
            {
                Console.WriteLine("CAtegory id=" + item.Key);
                foreach (var item1 in item)
                {
                    Console.WriteLine(item1.Prodid + " " + item1.Prodname);
                }
            }
        }

        private static void EagerLoadingWithToListToArrayCountAny()
        {
            List<Customers> custlist = new List<Customers>() {
            new Customers{Custid=1,CustName="Anand",Age=20 },
            new Customers{Custid=2,CustName="Jack",Age=20 },
            new Customers{ Custid=3,CustName="Sumit",Age=20},
            new Customers{ Custid=4,CustName="Akshay",Age=20},
            new Customers{ Custid=5,CustName="Kant",Age =20}
             };

            //Eager Loading--Tolist(),count(),ToArray(),Any()
            var d1 = (from c in custlist
                      select c).Count();//5 newly added record after query will not be considerd

            var d2 = (from c in custlist
                      select c).ToList();
            foreach (var item in d2)
            {
                Console.WriteLine(item.Custid);
            }


            var Allcustdata = ((from c in custlist
                                select c).Any(c => c.Age == 30));


            Console.WriteLine(Allcustdata);//false
            var isage30 = custlist.Any(c => c.Age == 30);
            Console.WriteLine(isage30);//false

            custlist.Add(new Customers { Custid = 6, CustName = "Raj", Age = 30 });
            Console.WriteLine(Allcustdata);//false
            isage30 = custlist.Any(c => c.Age == 30);//true



            var custArray = (from c in custlist
                             select c).ToArray();

            custlist.Add(new Customers { Custid = 7, CustName = "Gauri", Age = 30 });

            foreach (var item in custArray)
            {
                Console.WriteLine(item.Custid + " " + item.CustName + "  " + item.Age);
            }
        }

        private static void WorkingWithList()
        {
            List<Products> products = new List<Products>();
            products.Add(new Products { Prodid = 1, Prodname = "Chai", Price = 10, Categoryid = 1 });
            products.Add(new Products { Prodid = 12, Prodname = "Coffe", Price = 20, Categoryid = 1 });

            products.Add(new Products { Prodid = 31, Prodname = "Dosa", Price = 50, Categoryid = 3 });
            products.Add(new Products { Prodid = 14, Prodname = "Idli", Price = 60, Categoryid = 3 });

            products.Add(new Products { Prodid = 15, Prodname = "Icecream", Price = 40, Categoryid = 2 });







            var productsPriceMoreThan30 = from p in products
                                          orderby p.Prodid descending
                                          where p.Price > 30
                                          select p;




            var productsPriceMoreThan30_Methodway = products.Where(p => p.Price > 30).OrderByDescending(p => p.Prodid);


            products.Add(new Products { Prodid = 16, Prodname = "chips", Price = 40, Categoryid = 3 });
            //Eager loading
            var cntofProducts = (from p in products
                                 select p).Count();

            Console.WriteLine(cntofProducts);

            foreach (var product in productsPriceMoreThan30)
            {
                Console.WriteLine($"{product.Prodid} | {product.Prodname} | {product.Price} {product.Categoryid}|");
            }

            Console.WriteLine("============");

            foreach (var product in productsPriceMoreThan30_Methodway)
            {
                Console.WriteLine($"{product.Prodid} | {product.Prodname} | {product.Price} {product.Categoryid}|");
            }
        }

        private static void WorkingWithLINQArray()
        {
            int[] arr = new int[10] { 10, 1, 3, 45, 672, 98, 909, 72, 11, 113 };

            //a(int) auto declared and auto disposed ---range variable---will be of the type of array(int)
            //IEnumerable---means loop can work on it(IEnumerable is a interface under System.Collections) that can hold multiple values
            var EvenElements = from a in arr
                               where a % 2 == 0
                               select a;
            arr[1] = 60;
            arr[0] = 109;
            //latebinding---query is evaluated when the loop executes
            foreach (int ele in EvenElements)
            {
                Console.WriteLine(ele);
            }
            Console.WriteLine("Method syntax...");
            var data = arr.Where(a => a % 2 == 0);
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------");
            string[] names = new string[5] { "Ria", "Sia", "Simram", "Prakash", "Mitesh" };
            names[0] = "Sham";
            // names[4] = "Shamsundar";
            var strStartsWith = names.Where(s => s.EndsWith("h"));
            foreach (var item in strStartsWith)
            {
                Console.WriteLine(item);

            }
        }
    }
}