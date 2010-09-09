using System.Text;

namespace NetSpec.Core
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Ex;
    using Ext;
    using Infrastructure;

    public enum LineSpecStatus
    {
        Pending,
        Fail,
        Passed
    }

    /// <summary>
    /// Representa uma linha de uma especificação.
    /// </summary>
    public class LineSpec
    {
        #region " Private Fields "
        
        private string _anSpecificationLine;
        private bool _wasExecuted;
        private bool _wasAccepted;
        private readonly string _text;
        private static StringBuilder _joinBuffer;

        #endregion

        #region " Constructors "
        
        /// <summary>
        /// Este construtor deve receber por parâmetro a linha da especificação 
        /// a qual deverá referenciar.
        /// </summary>
        /// <param name="anSpecificationLine">
        /// Uma linha da especificação que está sendo tratada pelo sistema.
        /// </param>
        public LineSpec(string anSpecificationLine)
        {
            if (anSpecificationLine == null) 
                throw new NullSpecificationLineException();

            _anSpecificationLine = anSpecificationLine;

            _text = _anSpecificationLine;
            _joinBuffer = new StringBuilder();
        }

        #endregion

        #region " Properties "
        
        /// <summary>
        /// Retornando a string numa forma normalizada.
        /// </summary>
        private string AnNormalizedSpecificationLine
        {
            get { return _anSpecificationLine.Trim(); }
        }

        public string Text
        {
            get { return _text; }
        }

        #endregion

        #region " Methods "

        public LineSpecStatus GetStatus()
        {
            if (!WasAccepted() && !WasExecuted())
            {
                return LineSpecStatus.Pending;
            }

            if (WasAccepted() && WasExecuted())
            {
                return LineSpecStatus.Passed;
            }

            if (WasAccepted() && !WasExecuted())
            {
                return LineSpecStatus.Fail;
            }

            throw new Exception("Não foi possível recuperar o status da linha: " + Text);
        }

        public bool IsIndifferentLine()
        {
            return GetLineType() == LineType.Indifferent;
        }

        public bool IsExecutableLine()
        {
            return GetLineType() == LineType.Executable;
        }

        /// <summary>
        /// indica se o método já foi executado.
        /// </summary>
        /// <returns></returns>
        public bool WasExecuted()
        {
            return _wasExecuted;
        }

        public bool WasAccepted()
        {
            return _wasAccepted;
        }

        /// <summary>
        /// Indica o tipo da linha que está sendo processada.
        /// </summary>
        public LineType GetLineType()
        {
            if (_anSpecificationLine.Trim().StartsWith(">"))
                return LineType.BreakLine;

            return _anSpecificationLine.StartWithTabOrWhiteSpace() 
                ? LineType.Executable 
                : LineType.Indifferent;
        }

        /// <summary>
        /// Recebe um MethodInfo e retorna um valor indocando se o método atende 
        /// ou não á especificação representada por esta linha.
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        public bool Accept(MethodInfo methodInfo)
        {
            return IsExecutableLine() && AnNormalizedSpecificationLine.IsMatch(methodInfo);
        }

        /// <summary>
        /// Tenta executar o método caso atenda a especificação exigida.
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="instance"></param>
        public void TryExecute(MethodInfo methodInfo, object instance)
        {
            if (Accept(methodInfo))
            {
                _wasAccepted = true;
                Logger.Write(Text);
                methodInfo.Invoke(instance, GetParameters(methodInfo).ToArray());
                _wasExecuted = true;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos representando os parâmetros 
        /// do método caso o mesmo seja aceito.
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        public List<object> GetParameters(MethodInfo methodInfo)
        {
            return Accept(methodInfo)
                ? _anSpecificationLine.ExtractParameters(new MethodSpec(methodInfo))
                : new List<object>();
        }

        #endregion

        public void PrepareJoinNext()
        {
            if(_joinBuffer.ToString() == "")
                _joinBuffer.Append(" ");

            _joinBuffer.Append(RemoveBreakSymbol(_anSpecificationLine));
            _anSpecificationLine = "-" + _anSpecificationLine;
        }

        private string RemoveBreakSymbol(string str)
        {
            return str.Trim().StartsWith(">")
                       ? str.Trim().Substring(1)
                       : str.Trim();
        }

        public void JoinLine()
        {
            _anSpecificationLine = _joinBuffer.ToString() + RemoveBreakSymbol(_anSpecificationLine);
            _joinBuffer.Clear();
        }
    }
}
