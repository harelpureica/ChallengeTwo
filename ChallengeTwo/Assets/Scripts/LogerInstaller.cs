using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class LogerInstaller : MonoInstaller<LogerInstaller>
{
    //the text ui.
    [SerializeField]
    private TextMeshProUGUI _textMeshProUGUI;

    //binds the needed inputs and outputs for loging .
    public override void InstallBindings()
    {
        Container
            .Bind<Loger>()
            .AsSingle();

        Container.Bind<TextMeshProUGUI>()
            .WithId("LogerText")
            .FromInstance(_textMeshProUGUI)
            .AsTransient();

    }
}
