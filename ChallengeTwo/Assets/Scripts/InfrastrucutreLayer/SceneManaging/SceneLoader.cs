using ChallengeTwo.Infrastructure.Loading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Infrastructure.SceneManaging
{
    public static class SceneLoader
    {
        // A flag to validate that nobody will load twice.
        private static bool isLoading;

        // A flag to validate that nobody will unload twice.

        private static bool isUnLoading;

        #region Methods
        //Loads a scene  async with loading screen and unloads the open scene.
        public static async UniTask LoadSceneWithLoadingScreenAsync(string sceneToLoad, string sceneToUnload)
        {

            if (isLoading)
            {
                Debug.Log("IsLoadingAlready");
                return;
            }
            if (IsSceneActive(sceneToLoad))
            {
                Debug.Log($"{sceneToLoad}scene is allreadyLoaded");
                return;
            }
            var loadingScreen = await LoadingScreenLocator.GetLoadingScreen();
            await loadingScreen.FadeIn();
            await SceneManager.UnloadSceneAsync(sceneToUnload);
            isLoading = true;           
            var asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
            asyncOperation.allowSceneActivation = false;
            while (!asyncOperation.isDone)
            {
                if (asyncOperation.progress >= 0.9f)
                {
                    loadingScreen.UpdateProgress(asyncOperation.progress);
                    asyncOperation.allowSceneActivation = true;
                }
                await UniTask.Yield();
            }
            loadingScreen.UpdateProgress(1f);
            await loadingScreen.FadeOut();
            await LoadingScreenLocator.UnloadLoadingScreen();

            isLoading = false;

        }

        //Loads a scene  async .
        public static async UniTask LoadSceneAsync(string sceneName)
        {
            
            if(isLoading)
            {
                Debug.Log("IsLoadingAlready");
                return;
            }

            if (IsSceneActive(sceneName))
            {
                Debug.Log($"{sceneName}scene is allreadyLoaded");
                return;
            }
            isLoading = true;
            var asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            asyncOperation.allowSceneActivation = false;
            while (!asyncOperation.isDone)
            {
                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                }
                await UniTask.Yield();
            }
            isLoading = false;

        }

        //Unloads a scene  async .

        public static async UniTask UnloadSceneAsync(string sceneName)
        {
            if(isUnLoading)
            {
                Debug.Log($"AllreadyUnloading");
                return;
            }
            isUnLoading = true;
            var asyncOperation = SceneManager.UnloadSceneAsync(sceneName);
            asyncOperation.allowSceneActivation = false;
            while(!asyncOperation.isDone)
            {
                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                }
                await UniTask.Yield();
            }
            isUnLoading = false;
        }

        //checks if the scene with the given name is active.
        public static bool IsSceneActive(string sceneName)
        {
            return SceneManager.GetSceneByName(sceneName).isLoaded;
        }
        #endregion
    }
}
