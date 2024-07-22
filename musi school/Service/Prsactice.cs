using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace musi_school.Model
{
    internal class Prsactice
    {
        //כתבו פונקציה שמקבלת list<string ומחזירה bool - האם אחד מהאיברים מתחיל באות a
        //1
        public static Func<List<string>, bool> ItIsInA = (s) => 
         s.Any(s  => s.StartsWith("a"));

        //כתבו פונקציה שמקבלת list<string ומחזירה boll - האם קיים string ריק ברשימה
        //2
        public static Func<List<string>, bool> StrIsEmpty = (list) =>
            list.Any(s => s == "");

        //כתבו פונקציה שמקבלת list<string ומחזירה bool - האם כל האיברים מכילים את האות a
        //3
        public static Func<List<string>, bool> IfTheyAllHaveAnA = (list) =>
        list.All(s => s.Contains("A"));

      // כתבו פונקציה שמקבלת list<string ומחזירה list<string שכל איבר יהיה upper case
      //4

        public static Func<List<string>, List<string>> convertToUppercase = (list) =>
        list.Select(s => s.ToUpper()).ToList();

        //כתבו פונקציה כמו 4. רק עם Linq query
        //5

        public static Func<List<string>, List<string>> convertToUppercase2 = (list) =>      

        (from s in list  select s.ToUpper()).ToList();

        //כתבו פונקציה שמקבלת list<string ומחזירה list<string רק עם האיברים שאורכם גדול מ3
        //6

        public static Func<List<string>, List<string>> ifGreaterThanThree = (list) =>
        list.Where(s => s.Length > 3).ToList();

        //כתבו פונקציה כמו 6. רק עם Linq query
        //7

        public static Func<List<string>, List<string>> ifGreaterThanThree2 = (list) =>
        (from s in list where s.Length > 3 select s ).ToList();

        //כתבו פונקציה שמקבלת list<string שמחברת את כל האיברים לסטרינג אחד עם רווח בינהם
        //8
        public static Func<List<string>, string> TurnEverythingIntoOneText = (list) =>
        list.Aggregate("",(str, lis) => str + " " + lis);

        //כתבו פונקציה שמקבלת list<string ומחברת את כולם ל int באמצעות האורך של כל איבר
        //9
        public static Func<List<string>, int> TurnEverythingIntoOneLEnInt = (list) =>
        list.Aggregate(0, (num, lis) => num + lis.Length);

        //כתבו פונקציה שמקבלת list<string ומחזירה list<string רק עם האיברים שאורכם גדול מ3 Aggregate
        //10

        public static Func<List<string>, List<string>> ifGreaterThanThreeAggregate = (list) =>
        list.Aggregate(new List<string>(), (list1, str) => str.Length > 3 ? [.. list1, str] : list1);



        public static Func<List<string>, List<int>> selectLengths = (list) =>
        list.Aggregate(new List<int>(), (acc, n) => [.. acc, n.Length]);


    }
}
