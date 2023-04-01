using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Counter
{
    public delegate void AlarmClock(int num);
    public event AlarmClock AlarmNum;
    int alarmNum = 77;
    public void Count()
    {
        for (int i = 0; i < 100; i++)
        {
          if (i == alarmNum)
            {
                AlarmNum?.Invoke (alarmNum);
            }
        }
    }
}


