using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

namespace Players
{
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private PlayerCore _playerCore;

        [Inject]
        void Initialize(List<IInputEventProvider> inputEventProviders)
        {
            inputEventProviders.Select(x => x.MoveDirection)
                .Merge()
                .Subscribe(Move)
                .AddTo(this);
        }

        private void Move(Vector3 direction)
        {
            var pos = transform.position;
            pos += direction * _playerCore.PlayerParameters.MoveSpeed;
            transform.position = pos;
        }
    }
}
