using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ChallengeTwo.VisualLayer.Menus
{
    public interface IMenusManager
    {
        //hides al active menus.
        UniTask HideMenus();

        //shows a menu by name
        UniTask ShowMenu(string menuName);

        //adds dynamicly a menu to  menusManager list of menus.
        void AddMenu(MenuBase menu);

        //removes dynamicly a menu from  menusManager list of menus.

        void RemoveMenu(MenuBase menu);

    }
}
