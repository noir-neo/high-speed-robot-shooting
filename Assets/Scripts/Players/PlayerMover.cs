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
        [SerializeField] private Rigidbody _rigidbody;

        [Inject]
        void Initialize(List<IInputEventProvider> inputEventProviders)
        {
            inputEventProviders.Select(x => x.MoveDirection(_playerCore.PlayerId))
                .Merge()
                .TakeUntil(_playerCore.Explode)
                .Subscribe(Move)
                .AddTo(this);

            inputEventProviders.Select(x => x.AimDirection(_playerCore.PlayerId))
                .Merge()
                .TakeUntil(_playerCore.Explode)
                .Subscribe(Turn)
                .AddTo(this);
        }

        private void Move(Vector3 direction)
        {
            var pos = transform.position;
            pos += transform.TransformDirection(direction) * _playerCore.PlayerParameters.MoveSpeed;
            _rigidbody.MovePosition(pos);
        }

        private void Turn(Vector2 direction)
        {
            var rotation = transform.rotation;
            rotation *= Quaternion.AngleAxis(direction.x * _playerCore.PlayerParameters.TurnSpeed, Vector3.up);
            rotation *= Quaternion.AngleAxis(direction.y * _playerCore.PlayerParameters.TurnSpeed, Vector3.right);
            _rigidbody.MoveRotation(rotation);
        }
    }
}
