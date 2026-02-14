using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OOP._05genericList
{
    internal class TestClass05cs
    {
        static void Main04(string[] args)
        {
            course c1 = new course("c#",1000);
            course c2 = new course("c++", 2000);
            course c3 = new course("java", 3000);
            course c4 = new course("python", 4000);
            course c5 = new course("php", 5000);

            //創建List - 方式一
            List<course> list2 = new List<course>();
            list2.Add(c1);
            list2.Add(c2);
            list2.Add(c3);

            //創建List - 方式二
            List<course> list1 = new List<course>() { c1, c2, c3, c4, c5 };

            //轉換 - 將List轉換成數組
            course[] list2Array = list1.ToArray();

            //轉換 - 由數組轉換成LIST
            List<course> array2List = list2Array.ToList();

            //將LIST添加至Array
            array2List.AddRange(list2Array);

            //刪除
            array2List.Remove(c1);
            array2List.RemoveRange(1,2);

            //查詢
            int index = array2List.IndexOf(c1);
        }

        public static void showList(List<course> list)
        {
            list.ForEach(c=>c.showInfo());
        }
    }
}
