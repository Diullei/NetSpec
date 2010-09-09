namespace NetSpec.Core
{
    /// <summary>
    /// Identifica o tipo de uma linha de especificação.
    /// </summary>
    public enum LineType
    {
        /// <summary>
        /// Utilizado para identificar a linha como uma linha neutra.
        /// </summary>
        Indifferent,

        /// <summary>
        /// identifica uma linha como executável.
        /// </summary>
        Executable,

        BreakLine
    }
}
