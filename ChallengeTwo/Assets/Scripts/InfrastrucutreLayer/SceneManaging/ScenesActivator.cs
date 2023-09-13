using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChallengeTwo.InfrastrucutreLayer.SceneManaging
{
    public class ScenesActivator:MonoBehaviour
    {
        #region Fields
        //singleton.
        private static ScenesActivator _instance;
        #endregion

        #region Methods
        //subscribe to the event that is called when a scene is loaded  and validate there is only one sceneActivator.

        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            if(_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }else if(_instance!=this)
            {
                Destroy(this.gameObject);
            }
        }

        //removes the static cached ref 
        private void OnApplicationQuit()
        {
            _instance = null;
        }

        //activates the scene immediatly to make sure the elements in the scene will be ready 
        //and that the camera.main/current ref will update currectly
        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
           SceneManager.SetActiveScene(arg0);
        }
        #endregion

    }
}
