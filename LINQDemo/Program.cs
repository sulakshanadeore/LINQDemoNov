using LINQDemo;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        //void--Action----takes a parameter---type(int)---action name(action)---name of parameter i--->go inside method (lambda=>)
        Action<int> action = i => Console.WriteLine(i);
        action(10);

        //Print name(String) using the Action



        //Emp.printname("Harish");
        //Emp.strlength("hello");

        //Emp e = new Emp();
        //e.PrintLength("hello");


        //Action<string, string> concatstrings = (s1, s2) => 
        //{ 
        //  string s3=string.Concat(s1, s2);
        //    Console.WriteLine(s3);
        //    Console.WriteLine(s3.ToLower());
        //    Console.WriteLine(s3.ToUpper());

        //};

        //concatstrings("John", "Doe");

        Func<string, string, string> f1 = (s1, s2) => 
        {
            string s3 = string.Concat(s1, s2);
            
                Console.WriteLine(s3.ToLower());
                Console.WriteLine(s3.ToUpper());
            return s3;

        };
        string output=f1("John", "King");
        Console.WriteLine(output);


        Func<string, string, bool> addnos = (i, j) => 
        {
            int no1 = Convert.ToInt32(i);
            int no2 = Convert.ToInt32(j);
            int no3 = no1 + no2;
            if (no3 % 2 == 0)
                return true;
            else
                return false;
        
        };

        bool ans=addnos("10", "20");
        Console.WriteLine(ans);

        //input parameters--float,double and int is output parameter
        //  Func<float, double, bool> f2 = (i, j) => { };

        Predicate<int> isEven = (i) => 
        { 
        if(i%2==0) 
                return true;
            else
            
                return false;
            
        
        };

        int i = 11, j = 12;
        bool isnumberEven=isEven(i);
        Console.WriteLine($"{i} {isnumberEven}");
      isnumberEven=isEven(j);
        Console.WriteLine($"{j} {isnumberEven}");






    }
}