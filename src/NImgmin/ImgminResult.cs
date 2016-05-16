using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace NImgmin
{
    public class ImgminResult
    {
        readonly Regex _regexBefore = new Regex(@"Before quality:(\d+) colors:(\d+) size:(\d+\.\d+)kB", RegexOptions.IgnoreCase);
        readonly Regex _regexAfter =  new Regex(@"After  quality:(\d+) colors:(\d+) size:(\d+\.\d+)kB", RegexOptions.IgnoreCase);
        
        
        ImageStats _statsBefore;
        ImageStats _statsAfter;
        
        
        public int ExitCode { get; set; }
        public string StandardOutput { get; set; }
        
        
        public ImageStats StatsBefore
        { 
            get
            {
                if(_statsBefore == null)
                {
                    ParseResult();
                }
                
                return _statsBefore;
            }
        }
        
        
        public ImageStats StatsAfter 
        { 
            get
            {
                if(_statsAfter == null)
                {
                    ParseResult();
                }
                
                return _statsAfter;
            } 
        }
        
        
        void ParseResult()
        {
            using(var sr = new StreamReader(StreamFromString(StandardOutput)))
            {
                while(sr.Peek() >= 0)
                {
                    var line = sr.ReadLine();
                    
                    var matches = _regexBefore.Matches(line);
                    
                    if(matches.Count > 0)
                    {
                        _statsBefore = BuildStats(matches[0]);
                        continue;
                    }
                    
                    matches = _regexAfter.Matches(line);
                    
                    if(matches.Count > 0)
                    {
                        _statsAfter = BuildStats(matches[0]);
                        continue;
                    }
                }
            }
        }
        
        
        ImageStats BuildStats(Match match)
        {
            return new ImageStats 
            {
                Quality = Convert.ToInt32(match.Groups[1].Value),
                Colors = Convert.ToInt32(match.Groups[2].Value),
                Size = Convert.ToSingle(match.Groups[3].Value)
            };
        }
        
        
        Stream StreamFromString(string val)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(val ?? ""));
        }
    }
}
