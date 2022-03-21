using System.Diagnostics;

namespace AskKita_Hello_World_Example
{
    internal class AskKita
    {
        private static string interpreter = @"ask_kita/ask_kita.exe";
        private static bool askKitaRunning = false;
        private static Process askKitaProcess;

        public static bool kitaChangeState() {
            if (!askKitaRunning)
            {
                startAskKita();
            }
            else {
                stopAskKita();
            }
            return askKitaRunning;
        }

        public static void stopAskKita()
        {
            Debug.WriteLine("STOP KITA");
            if (askKitaRunning)
            {
                askKitaRunning = false;
                askKitaProcess.Kill();
                askKitaProcess.Close();
            }
        }

        private static void startAskKita()
        {
            Debug.WriteLine("START KITA");
            askKitaRunning = true;
            askKitaProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = interpreter,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                },
                EnableRaisingEvents = true
            };
            askKitaProcess.ErrorDataReceived += Process_OutputDataReceived;
            askKitaProcess.OutputDataReceived += Process_OutputDataReceived;

            askKitaProcess.Start();
            askKitaProcess.BeginErrorReadLine();
            askKitaProcess.BeginOutputReadLine();
        }

        private static async void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            string? data = e.Data;
            if (data == null) return;
            Debug.WriteLine(data);
        }
    }

  
}
