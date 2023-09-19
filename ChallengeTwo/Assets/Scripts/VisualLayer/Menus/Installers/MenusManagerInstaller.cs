using Zenject;
using UnityEngine;

namespace ChallengeTwo.VisualLayer.Menus.Installers
{
    //this class is responsible for installing the menus Manager.

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
