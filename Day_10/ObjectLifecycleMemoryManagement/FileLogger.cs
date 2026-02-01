using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectLifecycleMemoryManagement
{
    internal class FileLoggern : IDisposable 
    {
        StreamWriter LogWriter;
        bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the FileLoggern class that writes log entries to the specified file.
        /// </summary>
       
        public FileLoggern(string filePath) 
        {
             LogWriter = new StreamWriter(filePath,append:true);
        }


        public void Log(string msg)
        {
            if (_disposed) throw new ObjectDisposedException("FilerLogger");

            LogWriter.WriteLine($"{DateTime.Now}:{msg}");
        }

        // IDisposible implemenation.. 
        public void Dispose() { 
           
            Dispose(true); 
           GC.SuppressFinalize(this);
        }

        // Cheking _disposed is true or not and if it is not true then it close and dispose Logwriter 
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (LogWriter != null)
                    {
                        LogWriter.Close();
                        LogWriter.Dispose();
                    }
                }
            }
        }
    }
}
