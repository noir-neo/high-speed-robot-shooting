using UnityEngine;
using UniRx;

namespace Players {
    interface IInputEventProvider
    {
        IObservable<Vector3> MoveDirection
        {
            get;
        }
    }
}
