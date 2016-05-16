using System;
using System.IO;
using NImgmin;
using Xunit;


namespace NImgmin.Tests
{
    public class NImgminTests
    {
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
    }
}
