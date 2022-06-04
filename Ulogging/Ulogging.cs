using System;
using System.IO;
using System.Linq;

namespace Ulogging
{
    class LogState // class with log state
    {
        public string Name {get; set;} // name of state
        public string Message {get; set;} // message of state

        public LogState(string name, string message)
        {
            this.Name = name;
            this.Message = message;
        }
    }

    static class LogStates // class with log states
    {
        public static LogState AllOk {get;} = new LogState("ALL OK", "NO ERRORS"); // when all ok
        public static LogState LowImportanceError {get;} = new LogState("ERROR (LOW IMPORTANCE)", "ERROR: {0}"); // low importance error
        public static LogState HighImportanceError {get;} = new LogState("ERROR (!!!HIGH IMPORTANCE!!!)", "ERROR: {0}"); // high importance error
    }

    public class Logger // main class
    {
        public long Step; // log step
        public StreamWriter File {get; set;} // output file
        public string RecFormat = "{0}. {1} [{2}] <{3}>({4}){{{5}}} ~{6}~"; // record format for log_it
        public string ErrRecFormat = "{0}. {1} [{2}] <{3}>({4}) ~{5}~"; // error record format log_it
        public string HereRecFormat = "{0}. {1} <{2}>"; // record format for log_here
        public bool NoPrint = false; // no print

        public Logger(string fileName, 
                      string recFormat = "{0}. {1} [{2}] <{3}>({4}){{{5}}} ~{6}~", 
                      string errRecFormat = "{0}. {1} [{2}] <{3}>({4}) ~{5}~", 
                      string hereRecFormat = "{0}. {1} <{2}>",
                      bool noPrint = false)
        {
            this.Step = 0;
            this.File = new StreamWriter(fileName, true);
            this.RecFormat = recFormat;
            this.ErrRecFormat = errRecFormat;
            this.HereRecFormat = hereRecFormat;
            this.NoPrint = noPrint;
            this.File.WriteLine(String.Concat(Enumerable.Repeat("*", 100)));
            Console.WriteLine(String.Concat(Enumerable.Repeat("*", 100)));
            this.File.WriteLine($"WORKING STARTED: {DateTime.Now}");
            Console.WriteLine($"WORKING STARTED: {DateTime.Now}");            
        }

        // low importance action

        public Action LogItLowImportance(Action func)
        {
            void Logging()
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, "", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, "", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, "", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, "", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1> LogItLowImportance<T1>(Action<T1> func)
        {
            void Logging(T1 Argument1)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2> LogItLowImportance<T1, T2>(Action<T1, T2> func)
        {
            void Logging(T1 Argument1, T2 Argument2)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3> LogItLowImportance<T1, T2, T3>(Action<T1, T2, T3> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4> LogItLowImportance<T1, T2, T3, T4>(Action<T1, T2, T3, T4> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5> LogItLowImportance<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6> LogItLowImportance<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7, T8> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12, T13 Argument13)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12, T13 Argument13, T14 Argument14)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12, T13 Argument13, T14 Argument14, T15 Argument15)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12, T13 Argument13, T14 Argument14, T15 Argument15, T16 Argument16)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}, {Argument16}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}, {Argument16}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}, {Argument16}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}, {Argument16}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        // high importance action

        public Action LogItHighImportance(Action func)
        {
            void Logging()
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, "", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, "", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, "", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, "", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1> LogItHighImportance<T1>(Action<T1> func)
        {
            void Logging(T1 Argument1)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2> LogItHighImportance<T1, T2>(Action<T1, T2> func)
        {
            void Logging(T1 Argument1, T2 Argument2)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3> LogItHighImportance<T1, T2, T3>(Action<T1, T2, T3> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4> LogItHighImportance<T1, T2, T3, T4>(Action<T1, T2, T3, T4> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5> LogItHighImportance<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6> LogItHighImportance<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7, T8> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12, T13 Argument13)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12, T13 Argument13, T14 Argument14)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12, T13 Argument13, T14 Argument14, T15 Argument15)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> func)
        {
            void Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12, T13 Argument13, T14 Argument14, T15 Argument15, T16 Argument16)
            {
                this.Step ++;
                try
                {
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}, {Argument16}", "", LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}, {Argument16}", "", LogStates.AllOk.Message));
                    }
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}, {Argument16}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}, {Argument16}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                }
            }
            return Logging;
        }

        // low importance func

        public Func<TAnsw?> LogItLowImportance<TAnsw>(Func<TAnsw> func)
        {
            TAnsw? Logging()
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func();
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, "", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, "", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, "", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, "", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, TAnsw?> LogItLowImportance<T1, TAnsw>(Func<T1, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, TAnsw?> LogItLowImportance<T1, T2, TAnsw>(Func<T1, T2, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, TAnsw?> LogItLowImportance<T1, T2, T3, TAnsw>(Func<T1, T2, T3, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, TAnsw?> LogItLowImportance<T1, T2, T3, T4, TAnsw>(Func<T1, T2, T3, T4, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, TAnsw?> LogItLowImportance<T1, T2, T3, T4, T5, TAnsw>(Func<T1, T2, T3, T4, T5, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, TAnsw?> LogItLowImportance<T1, T2, T3, T4, T5, T6, TAnsw>(Func<T1, T2, T3, T4, T5, T6, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, TAnsw?> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, T8, TAnsw?> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, T8, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TAnsw?> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8, Argument9);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TAnsw?> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8, Argument9, Argument10);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TAnsw?> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8, Argument9, Argument10, Argument11);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TAnsw?> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8, Argument9, Argument10, Argument11, Argument12);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TAnsw?> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12, T13 Argument13)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8, Argument9, Argument10, Argument11, Argument12, Argument13);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TAnsw?> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12, T13 Argument13, T14 Argument14)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8, Argument9, Argument10, Argument11, Argument12, Argument13, Argument14);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TAnsw?> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12, T13 Argument13, T14 Argument14, T15 Argument15)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8, Argument9, Argument10, Argument11, Argument12, Argument13, Argument14, Argument15);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TAnsw?> LogItLowImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12, T13 Argument13, T14 Argument14, T15 Argument15, T16 Argument16)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8, Argument9, Argument10, Argument11, Argument12, Argument13, Argument14, Argument15, Argument16);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}, {Argument16}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}, {Argument16}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}, {Argument16}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}, {Argument16}", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        // high importance func

        public Func<TAnsw?> LogItHighImportance<TAnsw>(Func<TAnsw> func)
        {
            TAnsw? Logging()
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func();
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, "", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, "", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, "", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.LowImportanceError.Name, func.Method.Name, "", string.Format(LogStates.LowImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }
    
        public Func<T1, TAnsw?> LogItHighImportance<T1, TAnsw>(Func<T1, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }
    
        public Func<T1, T2, TAnsw?> LogItHighImportance<T1, T2, TAnsw>(Func<T1, T2, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, TAnsw?> LogItHighImportance<T1, T2, T3, TAnsw>(Func<T1, T2, T3, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, TAnsw?> LogItHighImportance<T1, T2, T3, T4, TAnsw>(Func<T1, T2, T3, T4, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, TAnsw?> LogItHighImportance<T1, T2, T3, T4, T5, TAnsw>(Func<T1, T2, T3, T4, T5, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, TAnsw?> LogItHighImportance<T1, T2, T3, T4, T5, T6, TAnsw>(Func<T1, T2, T3, T4, T5, T6, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, TAnsw?> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, T8, TAnsw?> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, T8, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TAnsw?> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8, Argument9);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TAnsw?> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8, Argument9, Argument10);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TAnsw?> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8, Argument9, Argument10, Argument11);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TAnsw?> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8, Argument9, Argument10, Argument11, Argument12);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TAnsw?> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12, T13 Argument13)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8, Argument9, Argument10, Argument11, Argument12, Argument13);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TAnsw?> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12, T13 Argument13, T14 Argument14)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8, Argument9, Argument10, Argument11, Argument12, Argument13, Argument14);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TAnsw?> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12, T13 Argument13, T14 Argument14, T15 Argument15)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8, Argument9, Argument10, Argument11, Argument12, Argument13, Argument14, Argument15);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TAnsw?> LogItHighImportance<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TAnsw>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TAnsw> func)
        {
            TAnsw? Logging(T1 Argument1, T2 Argument2, T3 Argument3, T4 Argument4, T5 Argument5, T6 Argument6, T7 Argument7, T8 Argument8, T9 Argument9, T10 Argument10, T11 Argument11, T12 Argument12, T13 Argument13, T14 Argument14, T15 Argument15, T16 Argument16)
            {
                this.Step ++;
                try
                {
                    TAnsw returned = func(Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8, Argument9, Argument10, Argument11, Argument12, Argument13, Argument14, Argument15, Argument16);
                    this.File.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}, {Argument16}", returned, LogStates.AllOk.Message));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.RecFormat, this.Step, DateTime.Now, LogStates.AllOk.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}, {Argument16}", returned, LogStates.AllOk.Message));
                    }
                    return returned;
                }
                catch(Exception err)
                {
                    this.File.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}, {Argument16}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    if (!this.NoPrint)
                    {
                        Console.WriteLine(string.Format(this.ErrRecFormat, this.Step, DateTime.Now, LogStates.HighImportanceError.Name, func.Method.Name, $"{Argument1}, {Argument2}, {Argument3}, {Argument4}, {Argument5}, {Argument6}, {Argument7}, {Argument8}, {Argument9}, {Argument10}, {Argument11}, {Argument12}, {Argument13}, {Argument14}, {Argument15}, {Argument16}", string.Format(LogStates.HighImportanceError.Message, err.Message)));
                    }
                    return default(TAnsw);
                }
            }
            return Logging;
        }

        public void LogHere(string logID)
        {
            this.Step ++;
            this.File.WriteLine(string.Format(this.HereRecFormat, this.Step, DateTime.Now, logID));
            Console.WriteLine(string.Format(this.HereRecFormat, this.Step, DateTime.Now, logID));
        }
    }
}