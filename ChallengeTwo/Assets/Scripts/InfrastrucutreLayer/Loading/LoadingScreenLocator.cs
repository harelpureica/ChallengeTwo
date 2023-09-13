using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;
using System.Linq;
using Infrastructure.SceneManaging;

namespace ChallengeTwo.Infrastructure.Loading
{
    public static class LoadingScreenLocator
    {
        //loads the  loading scene and finds the loadingscreen.
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
