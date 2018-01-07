using System;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Titles
{
    public class TitleController : MonoBehaviour
    {
        void Awake()
        {
            Observable.Timer(TimeSpan.FromSeconds(2))
                .ContinueWith(_ => SceneManager.LoadSceneAsync("Main", LoadSceneMode.Additive).AsObservable())
                .ContinueWith(_ => SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene()).AsObservable())
                .Subscribe()
                .AddTo(this);
        }
    }
}
