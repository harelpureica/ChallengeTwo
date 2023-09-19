using TMPro;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.Infrastructure.Logging
{
    //this class is resposible for installing the textLogger .
    public class TextLoggerInstaller : MonoInstaller<TextLoggerInstaller>
    {
        //the text ui.
        [SerializeField]
        private TextMeshProUGUI _textMeshProUGUI;

        //binds the needed inputs and outputs for loging .
        public override void InstallBindings()
        {
            Container
                .Bind<TextLogger>()
                .AsSingle();

            Container.Bind<TextMeshProUGUI>()
                .WithId("LogerText")
                .FromInstance(_textMeshProUGUI)
                .AsTransient();

        }
    }
}
