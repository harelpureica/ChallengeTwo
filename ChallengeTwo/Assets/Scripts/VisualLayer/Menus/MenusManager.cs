using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.Menus
{
    //this class is responsible for managing the menus.

    public class MenusManager:IMenusManager
    {
        #region Fields
        // holds a list of all the menus.
        private List<MenuBase> _menus= new List<MenuBase>();

        //the active menu.
        private MenuBase _activeMenu;
        #endregion

        #region Methods
        //adds a menu dynamicly.
        public void AddMenu(MenuBase menu)
        {
            if(menu == null||_menus.Contains(menu))
            {
                return;
            }            
            _menus.Add(menu);
        }
        //removes a menu dynamicly.
        public void RemoveMenu(MenuBase menu)
        {
            if (menu == null || !_menus.Contains(menu))
            {
                return;
            }
            _menus.Remove(menu);
        }
      
        //hides all menus on by one.
        public async UniTask HideMenus()
        {
            for (int i = 0; i < _menus.Count; i++)
            {
                if (_menus[i].IsVisible)
                {
                    await _menus[i].HideAsync(1);
                }
            }
            _activeMenu = null;
        }
        //show a menu with the given name.
        public async UniTask ShowMenu(string menuName)
        {

            for (int i = 0; i < _menus.Count; i++)
            {
                if (_menus[i].IsVisible && _menus[i]!=_activeMenu)
                {
                    await _menus[i].HideAsync(1);
                }
            }

            for (int i = 0; i < _menus.Count; i++)
            {
                if (menuName == _menus[i].MenuName && _menus[i] != _activeMenu)
                {
                    Debug.Log("showMenu");

                    await _menus[i].ShowAsync(1);
                    _activeMenu = _menus[i];
                }
            }

        }
        #endregion
    }
}
