public static class Program
{
    delegate void Message(int x);
    public static void Main ()
    {
       Counter counter = new Counter();
       Handler1 handler1 = new Handler1();
       Handler2 handler2 = new Handler2();

        counter.AlarmNum += handler1.Message;
        counter.AlarmNum += handler2.Message;

        counter.Count();
    }

   

}
