using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetSpec.CodeHelper.TestProject
{
    [TestClass]
    public class DynamicSpecTest
    {
        [TestMethod]
        public void Inserindo_Caracteres_Em_Um_Objeto_DynamicSpec_Vazio()
        {
            var spec = new DynamicSpec();
            
            Assert.AreEqual(string.Empty, spec.Text);
            Assert.AreEqual(0, spec.Parameters.Count);

            spec.Insert(0, "a");
            Assert.AreEqual("a", spec.Text);

            spec.Insert(1, "b");
            Assert.AreEqual("ab", spec.Text);

            spec.Insert(2, "c");
            Assert.AreEqual("abc", spec.Text);

            spec.Insert(3, "d");
            Assert.AreEqual("abcd", spec.Text);

            spec.Insert(0, "1");
            Assert.AreEqual("1abcd", spec.Text);
        }

        public void Definindo_Um_Parametro_String()
        {
            var spec = new DynamicSpec();

            Assert.AreEqual(string.Empty, spec.Text);
            Assert.AreEqual(0, spec.Parameters.Count);

            spec.Insert(0, "Diullei de Moura Gomes");
            Assert.AreEqual("Diullei de Moura Gomes", spec.Text);

            spec.DefParameter(11, 5, typeof (string));

            Assert.AreEqual(0, spec.Parameters.Count);
            Assert.AreEqual("Moura", spec.Parameters[0].Value);
            Assert.AreEqual(typeof(string), spec.Parameters[0].ParameterType);
        }

        public void Inserindo_Valor_Antes_De_Um_Parametro()
        {
            var spec = new DynamicSpec();

            Assert.AreEqual(string.Empty, spec.Text);
            Assert.AreEqual(0, spec.Parameters.Count);

            spec.Insert(0, "Diullei de Moura Gomes");
            Assert.AreEqual("Diullei de Moura Gomes", spec.Text);

            spec.DefParameter(11, 5, typeof(string));

            Assert.AreEqual(0, spec.Parameters.Count);
            Assert.AreEqual("Moura", spec.Parameters[0].Value);
            Assert.AreEqual(typeof(string), spec.Parameters[0].ParameterType);

            spec.Insert(0, "a");
            Assert.AreEqual("aDiullei de Moura Gomes", spec.Text);
            Assert.AreEqual(12, spec.Parameters[0].Start);
            Assert.AreEqual(5, spec.Parameters[0].Length);
        }

        public void Inserindo_Valor_Dentro_De_Um_Parametro()
        {
            var spec = new DynamicSpec();

            Assert.AreEqual(string.Empty, spec.Text);
            Assert.AreEqual(0, spec.Parameters.Count);

            spec.Insert(0, "Diullei de Moura Gomes");
            Assert.AreEqual("Diullei de Moura Gomes", spec.Text);

            spec.DefParameter(11, 5, typeof(string));

            Assert.AreEqual(0, spec.Parameters.Count);
            Assert.AreEqual("Moura", spec.Parameters[0].Value);
            Assert.AreEqual(typeof(string), spec.Parameters[0].ParameterType);

            spec.Insert(12, "a");
            Assert.AreEqual("Diullei de Maoura Gomes", spec.Text);
            Assert.AreEqual(11, spec.Parameters[0].Start);
            Assert.AreEqual(6, spec.Parameters[0].Length);
            Assert.AreEqual("Maoura", spec.Parameters[0].Value);
        }

        public void Inserindo_Valor_Depois_De_Um_Parametro()
        {
            var spec = new DynamicSpec();

            Assert.AreEqual(string.Empty, spec.Text);
            Assert.AreEqual(0, spec.Parameters.Count);

            spec.Insert(0, "Diullei de Moura Gomes");
            Assert.AreEqual("Diullei de Moura Gomes", spec.Text);

            spec.DefParameter(11, 5, typeof(string));

            Assert.AreEqual(0, spec.Parameters.Count);
            Assert.AreEqual("Moura", spec.Parameters[0].Value);
            Assert.AreEqual(typeof(string), spec.Parameters[0].ParameterType);

            spec.Insert(17, "a");
            Assert.AreEqual("Diullei de Moura aGomes", spec.Text);
            Assert.AreEqual(11, spec.Parameters[0].Start);
            Assert.AreEqual(5, spec.Parameters[0].Length);
            Assert.AreEqual("Moura", spec.Parameters[0].Value);
        }
    }
}