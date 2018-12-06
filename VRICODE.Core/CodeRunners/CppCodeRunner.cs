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
        public static CodeRunnerOutput Run(string ACode, string AInput)
        {
            CodeRunnerOutput LOutput = new CodeRunnerOutput
            {
                Status = CodeRunnerStatus.Success
            };

            string LFileName = $"CppRun{DateTime.Now.Ticks}";

            string LDestCodeFileName = $"{LFileName}.cpp";
            string LDestBinFileName = $"{LFileName}.exe";

            File.WriteAllText(LDestCodeFileName, ACode);

            using (Process LGccProcess = Process.Start("gcc", $"--pass-exit-codes -c {LDestCodeFileName} -o {LDestBinFileName}"))
            {
                LGccProcess.WaitForExit();

                if (LGccProcess.ExitCode > 0)
                {
                    LOutput.Status = CodeRunnerStatus.CompilerError;
                    LOutput.Output = LGccProcess.StandardOutput.ReadToEnd();

                    return LOutput;
                }
            }

            using (Process LBinProcess = Process.Start(LDestBinFileName))
            {
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

                LOutput.Output = LBinProcess.StandardOutput.ReadToEnd();
            }

            return LOutput;
        }
    }
}
