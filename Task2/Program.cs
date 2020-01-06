using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using Task2.Enums;
using Task2.Method;
using Task2.Model;

namespace Task2
{

    class Program
    {
        static void Main(string[] args)
        {   
            BERCoder ber = new BERCoder();

            //ber.Code("var127", "OBJECT_IDENTIFIER", "1.3.6.4.1");
            //ber.CodeViaOID("1.3.6.1.2.1.2.2.1", "123"); //ifEntry
            //ber.CodeViaOID("1.3.6.1.2.1.1.7", "140");
            
            //code simple datatype
            ber.Code("var127", "INTEGER", "127");
            ber.Code("var128", "INTEGER", "128");
            ber.Code("age", "INTEGER", "45");
            ber.Code("obj_id", "OBJECT_IDENTIFIER", "1.3.6.4.1");
            ber.Code("var_null", "NULL");

            //create schema
            ber.CreateSchema("TwoInt", "SEQUENCE", "age:INTEGER");
            ber.CreateSchema("MySequence", "SEQUENCE", "age:INTEGER,name:BIT STRING");

            //code schema
            ber.Code("seq", "TwoInt", "127,128");
            ber.Code("seq2", "MySequence", "98,G");

            //code OID
            ber.CodeViaOID("1.3.6.1.2.1.2.2.1.10", "123");
            ber.CodeViaOID("1.3.6.1.2.1.1.7", "1");
            
            //code with Restricion exception
            ber.CodeViaOID("1.3.6.1.2.1.1.7", "140");

            //code with visibility
            ber.Code("B", "INTEGER", "5", "IMPLICIT");
            ber.Code("C", "INTEGER", "5", "IMPLICIT", "4");
            ber.Code("D", "INTEGER", "5", "EXPLICIT");


            Console.ReadKey();
        }
    }
}
