using System;
using UnityEngine;

namespace Players {
    public enum PlayerId
    {
        Player1 = 1,
        Player2 = 2,
    }

    public class InputValue<T>
    {
        public PlayerId PlayerId;
        public T Value;

        public InputValue(PlayerId playerId, T value)
        {
            PlayerId = playerId;
            Value = value;
        }
    }
    
    interface IInputEventProvider
    {
        IObservable<Vector3> MoveDirection(PlayerId playerId);
        IObservable<Vector2> AimDirection { get; }
    }
}
