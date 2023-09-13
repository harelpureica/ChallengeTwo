using Cysharp.Threading.Tasks;

namespace ChallengeTwo.Infrastructure.Loading
{
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
