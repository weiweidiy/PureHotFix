using Cysharp.Threading.Tasks;
using System;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Game
{
    public abstract class Transition : MonoBehaviour, ITransition
    {
        public void Awake()
        {
            DontDestroyOnLoad(this);
        }

        protected GameTransitionState state;
        public async UniTask BeginIn()
        {
            state = GameTransitionState.In;

            await Process();
        }

        public async UniTask BeginOut()
        {
            state = GameTransitionState.Out;

            await Process();
        }

        protected abstract UniTask Process();
    }

    public class FadeTransition : Transition
    {
        float duration = 1f;

        float progress = 0f;

        protected async override UniTask Process()
        {
            bool done = false;
            float elapsedTime = 0f;

            while (!done)
            {
                float effectTime = elapsedTime;

                //如果是进入，则反向效果时间
                if (state == GameTransitionState.In)
                {
                    effectTime = duration - effectTime;
                }
                progress = GameUtils.SmoothProgress(0, duration, effectTime);

                Debug.Log("progress = " + progress);

                done = !(elapsedTime < duration);

                await UniTask.DelayFrame(1);

                elapsedTime += Time.deltaTime;

                Debug.Log("elapsedTime = " + elapsedTime);
            }
        }
    }

    public class GameSceneManager
    {
        public async UniTask LoadSceneAsync(string sceneName, LoadSceneMode mode, ITransition transition = null)
        {
            if (transition != null)
            {
                Debug.Log("BeginOut Start");
                await transition.BeginOut();
                Debug.Log("BeginOut Complete");
            }

            Debug.Log("Load Scene Start " + sceneName);
            await Addressables.LoadSceneAsync(sceneName, mode).Task;
            Debug.Log("Load Scene Complete " + sceneName);

            if (transition != null)
            {
                Debug.Log("BeginIn Start");
                await transition.BeginIn();
                Debug.Log("BeginIn Complete");
            }
        }

        public async UniTask LoadSceneAsync(string sceneName, ITransition transition = null)
        {
            await LoadSceneAsync(sceneName, LoadSceneMode.Single, transition);
        }
    }

    public class Launcher
    {
        public async void Launch()
        {
            Debug.Log("Launcher is Running");
            //return null;
            //加载核心程序集
            //TextAsset asset = Addressables.LoadAssetAsync<TextAsset>("ObjectPool_dll").WaitForCompletion();
            //return Assembly.Load(asset.bytes);

            //return Assembly.Load(asset.bytes);


            GameObject go = new GameObject("transition");
            var transition = go.AddComponent<FadeTransition>();

            GameSceneManager sceneManager = new GameSceneManager();
            var task = sceneManager.LoadSceneAsync("Login", transition);
            Debug.Log("LoadSceneAsync Begin");
            await task;
            Debug.Log("LoadSceneAsync End");
        }
    }
}
