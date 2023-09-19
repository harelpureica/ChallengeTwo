using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.Menus.Installers
{
    //this class is responsible for installing the menus ui panel.

    public abstract class MenuBaseInstaller:MonoInstaller<MenuBaseInstaller>
    {
        //the main parent panel of the menu.
        [SerializeField]
        protected RectTransform _menuPanel;

        //binds the panel.
        public override void InstallBindings()
        {
            Container
                .Bind<RectTransform>()
                .WithId("Panel")
                .FromInstance(_menuPanel)
                .AsTransient();
        }
    }
}
