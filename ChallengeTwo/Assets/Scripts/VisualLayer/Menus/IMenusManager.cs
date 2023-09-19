using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ChallengeTwo.VisualLayer.Menus
{
    //this interface is responsible for managing the menus.

    public interface IMenusManager
    {
        //hides all active menus.
        UniTask HideMenus();

        //shows a menu by name.
        UniTask ShowMenu(string menuName);

        //adds  a menu dynamicly  to the menusManager list of menus.
        void AddMenu(MenuBase menu);

        //removes dynamicly a menu from  menusManager list of menus.

        void RemoveMenu(MenuBase menu);

    }
}
