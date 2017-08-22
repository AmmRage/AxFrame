//using System;
//using System.Runtime.InteropServices;
//using System.Windows.Forms;

//namespace AxDemo
//{
//    //380549D8-95EB-4AC4-8A17-08020081CF41
//    [InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("380549D8-95EB-4AC4-8A17-08020081CF41")]
//    public interface ILauncher
//    {
//        void launch();
//        string SayHello();
//        void RunForm();
//    }

//    //827292A9-0DDC-4396-A01A-624454A55677
//    [ClassInterface(ClassInterfaceType.None), Guid("827292A9-0DDC-4396-A01A-624454A55677"), ProgId("Launcher.Launcher")]
//    public class Launcher : ILauncher
//    {
//        private string path = null;

//        public void launch()
//        {
//            Console.WriteLine("I launch scripts for a living.");
//        }

//        public string SayHello()
//        {
//            return "Hello World!";
//        }

//        public void RunForm()
//        {
//            Application.Run(new FormInBrowser());
//        }
//    }
//}