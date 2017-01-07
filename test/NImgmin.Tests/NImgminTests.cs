using System;
using System.IO;
using Xunit;


namespace NImgmin.Tests
{
    public class NImgminTests
    {
        const string FILEARGS = "\"in.jpg\" \"out.jpg\"";
        
        
        [Fact]
        public void VerifyDefaultArgs()
        {
            var opts = new ImgminOptions();
            
            Assert.Equal(FILEARGS, GetTestArgs(opts));
        }
        
        
        [Fact]
        public void VerifyThresholdArgs()
        {
            var opts = new ImgminOptions();
            opts.BeConservative = true;
            
            Assert.Equal($"--conservative {FILEARGS}", GetTestArgs(opts));
            
            opts.BeVeryConservative = true;
            
            Assert.Equal($"--very-conservative {FILEARGS}", GetTestArgs(opts));
            
            opts.ErrorThreshold = 0.2;
            
            Assert.Equal($"--error-threshold {opts.ErrorThreshold} {FILEARGS}", GetTestArgs(opts));
        }
        
        
        [Fact]
        public void MinifyTest()
        {
            var imgmin = new Imgmin(new ImgminOptions());
            var result = imgmin.Minify("DSC_3982.jpg", "min.jpg");
            
            Console.WriteLine($"quality: {result?.StatsBefore?.Quality} -> {result?.StatsAfter?.Quality}");
            Console.WriteLine($"colors: {result?.StatsBefore?.Colors} -> {result?.StatsAfter?.Colors}");
            Console.WriteLine($"size: {result?.StatsBefore?.Size} -> {result?.StatsAfter?.Size}");
            
            Assert.True(File.Exists("min.jpg"));
        }
        
        
        string GetTestArgs(ImgminOptions opts)
        {
            return opts.GetStartInfo("in.jpg", "out.jpg").Arguments;
        }
    }
}
