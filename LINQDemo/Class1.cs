using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{

    public class Student
    {
        public int RollNo { get; set; }
        public string StudName { get; set; }
        public string CourseName { get; set; }


    }

    public class Products
    {
        public int Prodid { get; set; }

        public string Prodname { get; set; }
        public double Price { get; set; }

        public int Categoryid { get; set; }

    }


    public class Customers
    {
        public int Custid { get; set; }
        public string CustName { get; set; }

        public int Age { get; set; }
    }
}
