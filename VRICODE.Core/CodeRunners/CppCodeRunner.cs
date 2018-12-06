using System;
using System.Diagnostics;
using System.IO;
using VRICODE.Interfaces.Core;
using VRICODE.Models;
using VRICODE.Models.ViewModels;

namespace VRICODE.Core.CodeRunners
{
    public static class CppCodeRunner
    {
        private static readonly string FRootFolder = "C:\\Temp\\Cpp";

        static CppCodeRunner()
        {
            Directory.CreateDirectory(FRootFolder);
        }

        public static CodeRunnerOutput Run(string ACode, string AInput)
        {
            CodeRunnerOutput LOutput = new CodeRunnerOutput
            {
                Status = CodeRunnerStatus.Success
            };

            string LFileName = $"{FRootFolder}\\CppRun{DateTime.Now.Ticks}";

            string LDestCodeFileName = $"{LFileName}.cpp";
            string LDestBinFileName = $"{LFileName}.exe";

            File.WriteAllText(LDestCodeFileName, ACode);

            using (Process LGccProcess = Process.Start("gcc", $"{LDestCodeFileName} -o {LDestBinFileName} --pass-exit-codes"))
            {
                LGccProcess.WaitForExit();

                if (LGccProcess.ExitCode > 0)
                {
                    LOutput.Status = CodeRunnerStatus.CompilerError;
                    LOutput.Output = LGccProcess.StandardOutput.ReadToEnd();

                    return LOutput;
                }
            }

            using (Process LBinProcess = new Process())
            {
                LBinProcess.StartInfo = new ProcessStartInfo
                {
                    FileName = LDestBinFileName,
                    RedirectStandardOutput = true
                };

                LBinProcess.OutputDataReceived += (s, e) => LOutput.Output += e.Data;

                LBinProcess.Start();
                LBinProcess.BeginOutputReadLine();

                foreach (char LCharacter in AInput)
                {
                    LBinProcess.StandardInput.Write(LCharacter);
                }

                bool LProcessedInTime = LBinProcess.WaitForExit(1000);

                if (!LProcessedInTime)
                {
                    LOutput.Status = CodeRunnerStatus.TimeLimit;
                    return LOutput;
                }
            }

            return LOutput;
        }
    }
}
