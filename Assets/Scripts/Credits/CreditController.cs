using System;
using UniRx;
using UnityEngine;

namespace Credits
{
    public class CreditController : MonoBehaviour
    {
        [SerializeField] private GameObject[] _credits;

        public IObservable<Unit> ShowCreditAsObservable()
        {
            return Observable.Timer(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1))
                .TakeWhile(x => x < _credits.Length)
                .Do(x => {
                    foreach (var credit in _credits)
                    {
                        credit.SetActive(false);
                    }
                    _credits[x].SetActive(true);
                })
                .DoOnCompleted(() =>
                {
                    foreach (var credit in _credits)
                    {
                        credit.SetActive(false);
                    }
                })
                .AsUnitObservable();
        }
    }
}
