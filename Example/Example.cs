using Ulogging;

namespace Base
{
    class Program
    {
        static int Func1(int a)
        {
            return a;
        }

        static int Func2(int a)
        {
            return a / 0;
        }

        static int Func3(int a)
        {
            return a / 0;
        }

        static void Main()
        {
            Logger logger = new Logger("logger.log");
            logger.LogHere("TEST");
            logger.LogItLowImportance<int, int>(Func1)(1);
            logger.LogItLowImportance<int, int>(Func2)(1);
            logger.LogItHighImportance<int, int>(Func3)(1);
            logger.File.Close();
        }
    }
}

/*
Output:
1. 04.06.2022 7:54:47 <TEST>
2. 04.06.2022 7:54:47 [ALL OK] <Func1>(1){1} ~NO ERRORS~
3. 04.06.2022 7:54:47 [ERROR (LOW IMPORTANCE)] <Func2>(1) ~ERROR: Attempted to divide by zero.~
4. 04.06.2022 7:54:47 [ERROR (!!!HIGH IMPORTANCE!!!)] <Func3>(1) ~ERROR: Attempted to divide by zero.~
*/