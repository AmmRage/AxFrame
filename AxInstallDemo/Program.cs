using System.IO;

namespace AxCallExecutableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CopyFileFromNetworkDrive();
        }

        private static void CopyFileFromNetworkDrive()
        {
            File.Copy(
                @"\\10.0.0.42\isd_filesvr\SINGTEL_Production\BCC\Credit Management\Singtel_BCC_CRManagement_2017_Aug_22\CrManagement.xlsx",
                @"C:\TEST\TestFolder_Misc\ax\ax_functions\crmgt.xlsx", true);
        }
    }
}
