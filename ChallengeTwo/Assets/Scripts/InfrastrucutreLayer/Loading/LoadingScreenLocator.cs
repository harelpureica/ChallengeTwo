using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;
using System.Linq;
using Infrastructure.SceneManaging;

namespace ChallengeTwo.Infrastructure.Loading
{
    //this class is responsible for loading/unloading the loading  scene and  finding the loadingScreen
    public static class LoadingScreenLocator
    {
        //loads the loading scene and finds the loadingscreen.
        public static async UniTask<ILoadingScreen> GetLoadingScreen()
        {
            await SceneLoader. LoadSceneAsync("Loading");
            var service = Object.FindObjectsOfType<MonoBehaviour>().OfType<ILoadingScreen>().FirstOrDefault();
            return service;
        }

        //unloads the loading scene.
        public static async UniTask UnloadLoadingScreen()
        {
           await SceneLoader.UnloadSceneAsync("Loading");

        }       
    }
}
