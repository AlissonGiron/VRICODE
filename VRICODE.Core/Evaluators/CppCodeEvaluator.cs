using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
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
                    RedirectStandardOutput = true,
                };

                int LIdx = 0;
                LBinProcess.OutputDataReceived += (s, e) =>
                {
                    LCodeResult.Output += e.Data;

                    if (String.IsNullOrWhiteSpace(e.Data)) return;

                    if (!String.Equals(e.Data, AExpectedOutputs[LIdx++]))
                    {
                        LCodeResult.Status = EvaluatorStatus.WrongAnswer;
                    }

                    if (LIdx == AInputs.Length)
                    {
                        LIdx++;
                    }
                };

                LBinProcess.Start();
                LBinProcess.BeginOutputReadLine();

                for (int i = 0; i < AInputs.Length; i++)
                {
                    LBinProcess.StandardInput.WriteLine(AInputs[i]);
                    Thread.Sleep(100);
                }

                bool LGracefulExit = LBinProcess.WaitForExit(10000);
                if (!LGracefulExit)
                {
                    LCodeResult.Status = EvaluatorStatus.TimeLimit;
                    LBinProcess.Kill();
                }
                
                while (LGracefulExit && LIdx <= AInputs.Length)
                {
                    Thread.Sleep(10);
                }
            }

            return LCodeResult;
        }
    }
}
