using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DayTemp
{
    public int High, Low;
    public int Average()
    {
        return (High + Low) / 2;
    }
}
