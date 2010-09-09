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
            var consoleLog = new ConsoleLog(LineSpecCollection.ToList().Select(x => x.Text).ToList().GetLongestString().Length);
            var listException = new List<Exception>();

            LineSpecCollection.ToList().ForEach(line =>
            {
                try
                {
                    instance.GetType().GetMethods().ToList().ForEach(m => line.TryExecute(m, instance));
                }
                catch (Exception ex)
                {
                    listException.Add(ex.InnerException ?? ex);
                }

                consoleLog.WriteLogToLine(line, listException.Count);
            });

            consoleLog.WriteExceptionConsoleLog(listException);
            AssertTest();

            return new Report();
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
