namespace NetSpec.Core.Ex
{
    using System;

    /// <summary>
    /// Invocado sempre que uma linha de especificação não puder 
    /// ser executada por algum motivo ao ser invocada.
    /// </summary>
    public class CantExecuteSpecificationLineException : Exception
    {
        public LineSpec LineSpec { get; set; }

        public CantExecuteSpecificationLineException(LineSpec lineSpec)
        {
            LineSpec = lineSpec;
        }
    }
}