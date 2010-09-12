namespace NetSpec.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Ext;
    using Infrastructure;

    /// <summary>
    /// Representa uma especificação textual.
    /// </summary>
    public class Specification
    {
        #region " private Fields "

        private ConsoleLog _consoleLog;
        
        #endregion        

        #region " Properties "
        
        /// <summary>
        /// Uma coleção de linhas de especificação.
        /// </summary>
        public IList<LineSpec> LineSpecCollection { get; set; }

        #endregion

        #region " Methods "

        /// <summary>
        /// Tenta executar a especificação.
        /// </summary>
        /// <param name="instance"></param>
        public Report TryExecute(object instance)
        {
            RealTimeConsoleLogInitialize();

            LineSpecCollection.ToList().ForEach(line =>
            {
                try
                {
                    TryExecuteLine(instance, line);
                }
                catch (Exception ex)
                {
                    _consoleLog.AddException(ex.InnerException);
                }

                _consoleLog.WriteLogToLine(line);
            });

            _consoleLog.WriteExceptionConsoleLog();
            AssertTest();

            return new Report();
        }

        private void RealTimeConsoleLogInitialize()
        {
            _consoleLog = new ConsoleLog(LineSpecCollection);
        }

        private void TryExecuteLine(object instance, LineSpec line)
        {
            instance.GetType().GetMethods().ToList().ForEach(m => line.TryExecute(m, instance));
        }

        private void AssertTest()
        {
            var tFramework = TestFrameworkLoader.Load();

            LineSpecCollection.ToList().Any(line => line.GetStatus() == LineSpecStatus.Fail).ExecuteIfIsTrue(tFramework.Fail);
            LineSpecCollection.ToList().Any(line => line.GetStatus() == LineSpecStatus.Pending && line.IsExecutableLine()).ExecuteIfIsTrue(tFramework.Inconclusive);
        }

        #endregion
    }
}
