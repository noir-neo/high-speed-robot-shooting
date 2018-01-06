using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

namespace Players
{
    public class PlayerMover : MonoBehaviour
    {
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
            pos += direction;
            transform.position = pos;
        }
    }
}
