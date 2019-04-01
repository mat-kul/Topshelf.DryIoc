namespace Topshelf.DryIoc.Sample
{
    public class SampleService : ISampleService
    {
        private readonly ISampleLogger _sampleLogger;

        public SampleService(ISampleLogger sampleLogger) 
            => _sampleLogger = sampleLogger;

        public void Start() 
            => _sampleLogger.Log("SampleService started!");

        public void Stop() 
            => _sampleLogger.Log("SampleService stopped!");
    }
}
