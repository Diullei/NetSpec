namespace NetSpec.Core.Infrastructure
{
    using System.IO;
    using System.Reflection;

    // TODO: Esta classe precisa ser reformulada.
    public class Report
    {
        public void PrintOutPut(MethodBase methodBase)
        {
            var fileName = string.Format("out - {0}.txt", methodBase.Name);

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            TextWriter tw = new StreamWriter(fileName);
            tw.WriteLine(Logger.Instance.GetOutPut());
            tw.Close();

            Logger.Instance.Clear();
        }
    }
}
