namespace NetSpec.Core.Infrastructure
{
    using System;
    using System.Text;

    // TODO: Esta classe precisa ser reformulada.
    public class Logger
    {
        private static Logger _instance;
        private StringBuilder _textLog = new StringBuilder();

        private Logger()
        {
        }

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }

                return _instance;
            }
        }

        public string GetOutPut()
        {
            return _textLog.ToString();
        }

        private void LogWrite(string log)
        {
            _textLog.Append(log);
        }

        private void LogWriteLine(string log)
        {
            _textLog.AppendLine(log);
        }

        public static void Write(string log)
        {
            Logger.Instance.LogWrite(log);
            Console.Out.Write(log);
        }

        public static void WriteLine(string log)
        {
            Logger.Instance.LogWriteLine(log);
            Console.Out.WriteLine(log);
        }

        public void Clear()
        {
            _textLog.Clear();
        }
    }
}
