using System;

namespace Topshelf.DryIoc.Sample
{
    public class SampleLogger : ISampleLogger
    {
        public void Log(string message) 
            => Console.WriteLine(message);
    }
}
