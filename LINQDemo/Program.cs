
//using System.Security.Cryptography.X509Certificates;

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



            EagerLoadingWithToListToArrayCountAny();

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