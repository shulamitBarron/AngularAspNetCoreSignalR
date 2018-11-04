using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace AngularAspNetCoreSignalR
{
    public class ChatHub : Hub
    {
        public void SendToAll(string name, string message)
        {
            Clients.All.InvokeAsync("sendToAll", name, message);
        }
        public void RunDeleteProgram(string result)
        {

            var process = Process.Start("../../Release/DeleteDoubleFiles.exe");
            if (process == null) // failed to start../
            {
                Clients.All.InvokeAsync("runDeleteProgram", "Fail");
            }
            else // Started, wait for it to finish
            {
                process.WaitForExit();
                Clients.All.InvokeAsync("runDeleteProgram", "Ok");
            }
        }
    }
}