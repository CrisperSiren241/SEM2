using System.Xml.Serialization;
namespace Lab_2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Organization org = new Organization();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}