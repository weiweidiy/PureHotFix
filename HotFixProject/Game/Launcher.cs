using System;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Game
{
    public interface ITransition
    {
        /// <summary>
        /// 开始转出：比如逐步黑屏等
        /// </summary>
        Task BeginOut();

        /// <summary>
        /// 开始转入
        /// </summary>
        Task BeginIn();
    }

    public class FadeTransition : ITransition
    {
        public Task BeginIn()
        {

        }

        public Task BeginOut()
        {

        }
    }

    public class GameSceneManager
    {
        public async void LoadSceneAsync(string sceneName, LoadSceneMode mode, ITransition transition = null)
        {
            if (transition != null)
            {
                await transition.BeginOut();
                Debug.Log("BeginOut Complete");
            }

            await Addressables.LoadSceneAsync(sceneName, mode).Task;

            Debug.Log("Load Scene Complete " + sceneName);

            if (transition != null)
            {
                await transition.BeginIn();
                Debug.Log("BeginIn Complete");
            }
        }

        public AsyncOperation LoadSceneAsync(string sceneName, ITransition transition = null)
        {
            return SceneManager.LoadSceneAsync(sceneName);
        }
    }
    public class Launcher
    {
        public void Launch()
        {
            Debug.Log("Launcher is Running");
            //return null;
            //加载核心程序集
            //TextAsset asset = Addressables.LoadAssetAsync<TextAsset>("ObjectPool_dll").WaitForCompletion();
            //return Assembly.Load(asset.bytes);

            //return Assembly.Load(asset.bytes);



            GameSceneManager sceneManager = new GameSceneManager();
            sceneManager.LoadSceneAsync("Login", new )
        }
    }
}
