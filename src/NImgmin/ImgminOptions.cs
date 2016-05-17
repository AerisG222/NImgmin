using System.Collections.Generic;
using System.Diagnostics;


namespace NImgmin
{
    public class ImgminOptions
    {
        public string ImgminPath { get; set; }
        public bool BeConservative { get; set; }
        public bool BeVeryConservative { get; set; }
        public double? ErrorThreshold { get; set; }
        public double? ColorDensityRatio { get; set; }
        public uint? MinUniqueColors { get; set; }
        public uint? QualityOutMax { get; set; }
        public uint? QualityOutMin { get; set; }
        public uint? QualityInMin { get; set; }
        public uint? MaxSteps { get; set; }
        
        
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
            
            var args = new List<string>();
            
            if(ErrorThreshold != null)
            {
                args.Add($"--error-threshold {ErrorThreshold}");
            }
            else
            {
                if(BeVeryConservative)
                {
                    args.Add("--very-conservative");
                }
                else if(BeConservative)
                {
                    args.Add("--conservative");
                }
            }
            
            if(ColorDensityRatio != null)
            {
                args.Add($"--color-density-ratio {ColorDensityRatio}");
            }
            
            if(MinUniqueColors != null)
            {
                args.Add($"--min-unique-colors {MinUniqueColors}");
            }
            
            if(QualityOutMax != null)
            {
                args.Add($"--quality-out-max {QualityOutMax}");
            }
            
            if(QualityOutMin != null)
            {
                args.Add($"--quality-out-min {QualityOutMin}");
            }
            
            if(QualityInMin != null)
            {
                args.Add($"--quality-in-min {QualityInMin}");
            }
            
            if(MaxSteps != null)
            {
                args.Add($"--max-steps {MaxSteps}");
            }
            
            args.Add(EscapeFilename(srcFile));
            args.Add(EscapeFilename(destFile));
              
            psi.Arguments = string.Join(" ", args);
            
            return psi;
        }
        
        
        string EscapeFilename(string file)
        {
            return $"\"{file}\"";
        }
    }
}
