using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

namespace Players
{
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] private PlayerCore _playerCore;

        [Inject]
        void Initialize(List<IInputEventProvider> inputEventProviders)
        {
            inputEventProviders.Select(x => x.ShootButton(_playerCore.PlayerId))
                .Merge()
                .Where(x => x)
                .Subscribe(Shoot)
                .AddTo(this);
        }

        private void Shoot(bool shoot)
        {

        }
    }
}
