using System;
using UnityEngine;

namespace Players {
    interface IInputEventProvider
    {
        IObservable<Vector3> MoveDirection { get; }
        IObservable<Vector2> AimDirection { get; }
    }
}
