using System;
using System.Collections.Generic;
using System.Linq;
using Credits;
using Players;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameManagers
{
    public class ResultManager : MonoBehaviour
    {
        [Inject]
        void Initialize(List<PlayerCore> playerCores, CreditController creditController)
        {
            playerCores.Select(p => p.Explode)
                .Merge()
                .First()
                .ContinueWith(_ => Observable.Timer(TimeSpan.FromSeconds(2)))
                .ContinueWith(_ => creditController.ShowCreditAsObservable())
                .Concat()
                .ContinueWith(_ => Observable.Timer(TimeSpan.FromSeconds(1)))
                .ContinueWith(_ => SceneManager.LoadSceneAsync("Title", LoadSceneMode.Additive).AsObservable())
                .ContinueWith(_ => SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene()).AsObservable())
                .Subscribe()
                .AddTo(this);
        }
    }
}
