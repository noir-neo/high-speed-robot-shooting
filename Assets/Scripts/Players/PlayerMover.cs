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
            inputEventProviders.Select(x => x.MoveDirection(_playerCore.PlayerId))
                .Merge()
                .Subscribe(Move)
                .AddTo(this);

            inputEventProviders.Select(x => x.AimDirection(_playerCore.PlayerId))
                .Merge()
                .Subscribe(Turn)
                .AddTo(this);
        }

        private void Move(Vector3 direction)
        {
            var pos = transform.position;
            pos += transform.TransformDirection(direction) * _playerCore.PlayerParameters.MoveSpeed;
            transform.position = pos;
        }

        private void Turn(Vector2 direction)
        {
            transform.Rotate(Vector3.up, direction.x * _playerCore.PlayerParameters.TurnSpeed);
        }
    }
}
