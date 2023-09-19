using Cysharp.Threading.Tasks;

namespace ChallengeTwo.Infrastructure.Loading
{
    //this interface is responsible for showing loading ui and  loading Progress.
    public interface ILoadingScreen
    {
        //updates the ui  that shows the loading progress.
        void UpdateProgress(float progress);

        //showing the loading screen Ui.
        UniTask FadeIn();

        //Hiding the loading screen Ui.
        UniTask FadeOut();

    }
}
