

using Niantic.ARDK.AR.Scanning;

namespace ChallengeTwo.VisualLayer.AR
{
    //this interface  is responsible for manual scanning.
    public interface IManualScanning:IARFeatureBase
    {
        //start Scanning.
        void Scan();

        //stops Scanning.

        void StopScan();

        //start Processing scan result.

        void Process();

        //gets Processing  progress.

        float GetProcessingProgress();

        //the Scanning state.

        IScanner.State MyState { get; }


    }
}
