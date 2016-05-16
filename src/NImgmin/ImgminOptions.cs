using System.Text;
using System.Diagnostics;


namespace NImgmin
{
    public class ImgminOptions
    {
        public string ImgminPath { get; set; }
        
        
        public ImgminOptions()
        {
            ImgminPath = "imgmin";
        }
        
        
        public ProcessStartInfo GetStartInfo(string srcFile, string destFile)
        {
            var psi = new ProcessStartInfo();
            
            psi.FileName = ImgminPath;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.Arguments = $"{EscapeFilename(srcFile)} {EscapeFilename(destFile)}";
            
            return psi;
        }
        
        
        string EscapeFilename(string file)
        {
            return $"\"{file}\"";
        }
    }
}
