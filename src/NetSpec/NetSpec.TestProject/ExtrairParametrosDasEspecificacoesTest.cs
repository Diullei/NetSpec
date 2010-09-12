namespace NetSpec.TestProject
{
    using System;
    using Core;
    using Core.Infrastructure;
    using Core.Infrastructure.ParameterConvert;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExtrairParametrosDasEspecificacoesTest
    {
        #region " Especificação "

        private string _especificação = @"
Parâmetros numéricos:
    extraindo um parâmetro int32 -100000
    extraindo um parâmetro s byte 127
    extraindo um parâmetro byte 255
    extraindo um parâmetro int16 32767
    extraindo um parâmetro u int32 4294967295
    extraindo um parâmetro int64 1000000000
    extraindo um parâmetro single 1000000000
    extraindo um parâmetro double 1000.543
    extraindo um parâmetro decimal 1000.543

Parâmetros de texto:
    extraindo um parâmetro char #
    extraindo um parâmetro string uma string de teste

Parâmetros lógicos:
    extraindo um parâmetro bool true
- ainda parâmetros lógicos 
- só que utilizando conversores customizados
    extraindo um parâmetro bool positivo
    extraindo um parâmetro bool negativo
    extraindo um parâmetro bool 1

Parâmetros de data
    extraindo um parâmetro de data 02/09/2010
";

        #endregion

        [TestMethod]
        public void ExecutaEspecificação()
        {
            SpecificationBuilder.Builder(_especificação).TryExecute(this);
        }

        #region " Parâmetros Numéricos "

        public void ExtraindoUmParâmetroInt32_(int val)
        {
        }

        public void ExtraindoUmParâmetroSByte_(sbyte val)
        {
        }

        public void ExtraindoUmParâmetroByte_(byte val)
        {
        }

        public void ExtraindoUmParâmetroInt16_(Int16 val)
        {
        }

        public void ExtraindoUmParâmetroUInt32_(UInt32 val)
        {
        }

        public void ExtraindoUmParâmetroInt64_(Int64 val)
        {
        }

        public void ExtraindoUmParâmetroSingle_(Single val)
        {
        }

        public void ExtraindoUmParâmetroDouble_(double val)
        {
            Assert.AreEqual(1000.543, val);
        }

        public void ExtraindoUmParâmetroDecimal_(decimal val)
        {
            Assert.AreEqual((decimal)1000.543, val);
        }

        #endregion

        #region " Parâmetros de texto "

        public void ExtraindoUmParâmetroChar_(char val)
        {
        }

        public void ExtraindoUmParâmetroString_(string val)
        {
            Assert.AreEqual("uma string de teste", val);
        }

        #endregion

        #region " Parâmetros lógicos "

        [ParameterConvert(typeof(bool), typeof(CustomPositivoNegativoConvert))]
        [ParameterConvert(typeof(bool), typeof(CustomZeroUmConvert))]
        public void ExtraindoUmParâmetroBool_(bool val)
        {
        }

        #endregion

        #region " Parâmetros de data "

        public void ExtraindoUmParâmetroDeData_(DateTime val)
        {
        }

        #endregion
    }

    #region " Classes para conversões customizadas "

    public class CustomPositivoNegativoConvert : IParameterConvert
    {
        public bool Accept(Parameter parameter)
        {
            return parameter.ParameterInfo.ParameterType == typeof(bool)
                && (parameter.Value.ToUpper() == "POSITIVO" || parameter.Value.ToUpper() == "NEGATIVO");
        }

        public object Convert(Parameter parameter)
        {
            if (parameter.Value.ToUpper() == "POSITIVO")
                return true;

            if (parameter.Value.ToUpper() == "NEGATIVO")
                return false;

            throw new Exception();
        }
    }

    public class CustomZeroUmConvert : IParameterConvert
    {
        public bool Accept(Parameter parameter)
        {
            return parameter.ParameterInfo.ParameterType == typeof(bool)
                && (parameter.Value == "1" || parameter.Value == "0");
        }

        public object Convert(Parameter parameter)
        {
            if (parameter.Value == "1")
                return true;

            if (parameter.Value == "0")
                return false;

            throw new Exception();
        }
    }

    #endregion
}