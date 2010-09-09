﻿using System;
using System.Collections.Generic;
using NetSpec.Core.Ext;

namespace NetSpec.Core.Infrastructure
{
    public class ConsoleLog
    {
        private readonly int _maxLineSpecLength;

        public ConsoleLog(int maxLineSpecLength)
        {
            _maxLineSpecLength = maxLineSpecLength;
        }

        public void WriteExceptionConsoleLog(IList<Exception> listException)
        {
            if (listException.Count > 0)
            {
                Console.Out.WriteLine("=".Repeat(_maxLineSpecLength + 14));
            }

            for (var i = 0; i < listException.Count; i++)
            {
                Console.Out.WriteLine(string.Format("[{0}] {1}{2}{3}{2}", i + 1, listException[i].Message, Environment.NewLine, listException[i].StackTrace));
            }
        }

        public void WriteLogToLine(LineSpec lineSpec, int exceptionIndex)
        {
            if (lineSpec.IsExecutableLine())
            {
                WriteLogToPendingLine(lineSpec);
                WriteLogToExecutedLine(lineSpec);
                WriteLogToFailLine(lineSpec, exceptionIndex);
            }
            else
            {
                Logger.WriteLine(lineSpec.Text);
            }
        }

        private void WriteLogToPendingLine(LineSpec lineSpec)
        {
            if (lineSpec.GetStatus() == LineSpecStatus.Pending)
            {
                Logger.WriteLine(string.Format("{0} {1}> #Pending", lineSpec.Text, "-".Repeat(_maxLineSpecLength + 2 - lineSpec.Text.Length)));
            }
        }

        private void WriteLogToExecutedLine(LineSpec lineSpec)
        {
            if (lineSpec.GetStatus() == LineSpecStatus.Passed)
            {
                Logger.WriteLine(string.Format(" {0}> #Passed", "-".Repeat(_maxLineSpecLength + 2 - lineSpec.Text.Length)));
            }
        }

        private void WriteLogToFailLine(LineSpec lineSpec, int exceptionIndex)
        {
            if (lineSpec.GetStatus() == LineSpecStatus.Fail)
            {
                Logger.WriteLine(string.Format(" {0}> #Fail [{1}]", "-".Repeat(_maxLineSpecLength + 2 - lineSpec.Text.Length), exceptionIndex));
            }
        }
    }
}
