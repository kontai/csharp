using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH7
{
    internal class IndexExampl
    {
    }

    class Employee
    {
        public string LastName; //调用字段0
        public string FirstName; //调用字段1
        public string CityOfBirth; //调用字段2

        public string this[int index] //索引器声明
        {
            set //set 访问器声明
            {
                switch (index)
                {
                    case 0:
                        LastName = value;
                        break;
                    case 1:
                        FirstName = value;
                        break;
                    case 2:
                        CityOfBirth = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("index");
                }
            }
            get             //get访问器声明
            {
                switch (index)
                {
                    case 0: return LastName;
                    case 1: return FirstName;
                    case 2: return CityOfBirth;
                    default:
                        throw new ArgumentOutOfRangeException("index");         //(第23章中的异常)
                }
            }
        }
    }
}
