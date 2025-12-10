using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    internal class Emp
    {
      public static  Action<string> printname = name => Console.WriteLine(name);
       

        //Print the length of string using Action
      public  static Action<string> strlength = name => Console.WriteLine(name.Length);
       

    public    Action<string> PrintLength = (s) =>
        {
            int len = s.Length;
            Console.WriteLine(len);
        };
    }
}
