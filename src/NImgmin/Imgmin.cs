using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace NImgmin
{
    public class Imgmin
    {
        public ImgminOptions Options { get; private set; }
        
        
        public Imgmin(ImgminOptions options)
        {
            Options = options;
        }
        
        
        public ImgminResult Minify(string srcPath, string destPath)
        {
            return MinifyAsync(srcPath, destPath).Result;
        }
        
        
        public Task<ImgminResult> MinifyAsync(string srcPath, string destPath)
        {
            if(!File.Exists(srcPath))
            {
                throw new FileNotFoundException("Please make sure the source image exists.", srcPath);
            }
            
            return RunProcessAsync(srcPath, destPath);
        }
        
        
        // http://stackoverflow.com/questions/10788982/is-there-any-async-equivalent-of-process-start
        Task<ImgminResult> RunProcessAsync(string srcPath, string destPath)
        {
            var tcs = new TaskCompletionSource<ImgminResult>();
            
            using(var process = new Process())
            {
                process.StartInfo = Options.GetStartInfo(srcPath, destPath);
                
                try
                {
                    process.Start();
                }
                catch (Win32Exception ex)
                {
                    throw new Exception("Error when trying to start the imgmin process.  Please make sure imgmin is installed, and its path is properly specified in the options.", ex);
                }
                
                process.WaitForExit();
                
                var result = new ImgminResult 
                {
                    ExitCode = process.ExitCode,
                    StandardOutput = process.StandardOutput.ReadToEnd()
                };

                tcs.SetResult(result);
            }
            
            return tcs.Task;
        }
    }
}
