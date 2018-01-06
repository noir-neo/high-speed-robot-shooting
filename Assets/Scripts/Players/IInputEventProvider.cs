using System;
using UnityEngine;

namespace Players
{
    interface IInputEventProvider
    {
        IObservable<Vector3> MoveDirection(PlayerId playerId);
        IObservable<Vector2> AimDirection(PlayerId playerId);
        IObservable<bool> ShootButton(PlayerId playerId);
    }
}
