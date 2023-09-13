using Zenject;
using UnityEngine;

namespace ChallengeTwo.VisualLayer.Menus.Installers
{
    public class MenusManagerInstaller:MonoInstaller<MenusManagerInstaller>
    {
        //binds the IMenusManager interface to  menusManager class .
        public override void InstallBindings()
        {
            Container
                .Bind<IMenusManager>()
                .To<MenusManager>()
                .AsSingle();
        }
    }
}
