using System;
using System.Diagnostics;
using System.IO;
using VRICODE.Models;
using VRICODE.Models.ViewModels;

namespace VRICODE.Core.Evaluators
{
    public static class CppCodeEvaluator
    {
        private static readonly string FRootFolder = "C:\\Temp\\Cpp";

        static CppCodeEvaluator()
        {
            Directory.CreateDirectory(FRootFolder);
        }

        public static EvaluatorOutput Evaluate(string ACode, string[] AInputs, string[] AExpectedOutputs)
        {
            EvaluatorOutput LCodeResult = new EvaluatorOutput
            {
                Status = EvaluatorStatus.Success
            };

            string LFileName = $"{FRootFolder}\\CppRun{DateTime.Now.Ticks}";

            string LDestCodeFileName = $"{LFileName}.cpp";
            string LDestBinFileName = $"{LFileName}.exe";

            File.WriteAllText(LDestCodeFileName, ACode);

            using (Process LGccProcess = new Process())
            {
                LGccProcess.StartInfo = new ProcessStartInfo
                {
                    FileName = "gcc",
                    Arguments = $"{LDestCodeFileName} -o {LDestBinFileName} --pass-exit-codes",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                LGccProcess.Start();

                LGccProcess.WaitForExit();

                if (LGccProcess.ExitCode > 0)
                {
                    LCodeResult.Status = EvaluatorStatus.CompilerError;
                    return LCodeResult;
                }
            }

            using (Process LBinProcess = new Process())
            {
                LBinProcess.StartInfo = new ProcessStartInfo
                {
                    FileName = LDestBinFileName,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                };

                LBinProcess.Start();

                for (int i = 0; i < AInputs.Length; i++)
                {
                    LBinProcess.StandardInput.Write(AInputs[0]);
                    string LOutput = "";

                    while (LBinProcess.StandardOutput.Peek() > -1)
                    {
                        LOutput += LBinProcess.StandardOutput.Read();
                    }

                    LCodeResult.Output += LOutput;

                    if (!String.Equals(LOutput, AExpectedOutputs[i]))
                    {
                        LCodeResult.Status = EvaluatorStatus.WrongAnswer;
                        return LCodeResult;
                    }
                }
            }

            return LCodeResult;
        }
    }
}
