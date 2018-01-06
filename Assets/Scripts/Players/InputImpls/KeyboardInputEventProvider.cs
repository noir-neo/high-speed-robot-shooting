using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Players.InputImpls
{
    public class KeyboardInputEventProvider : MonoBehaviour, IInputEventProvider
    {
        private readonly static List<Tuple<KeyCode, Vector3>> Movements = new List<Tuple<KeyCode, Vector3>>
        {
            Tuple.Create(KeyCode.W, Vector3.forward),
            Tuple.Create(KeyCode.A, Vector3.left),
            Tuple.Create(KeyCode.S, Vector3.back),
            Tuple.Create(KeyCode.D, Vector3.right),
            Tuple.Create(KeyCode.LeftShift, Vector3.up),
            Tuple.Create(KeyCode.LeftControl, Vector3.down),
        };

        private readonly static List<Tuple<KeyCode, Vector2>> Aims = new List<Tuple<KeyCode, Vector2>>
        {
            Tuple.Create(KeyCode.UpArrow, Vector2.up),
            Tuple.Create(KeyCode.LeftArrow, Vector2.left),
            Tuple.Create(KeyCode.DownArrow, Vector2.down),
            Tuple.Create(KeyCode.RightArrow, Vector2.right),
        };

        private IObservable<Unit> UpdateAsObservableForPlayerId(PlayerId playerId)
        {
            return this.UpdateAsObservable().Where(_ => {
                var currentPlayerId = !Input.GetKey(KeyCode.RightAlt) ? PlayerId.Player1 : PlayerId.Player2;
                return currentPlayerId == playerId;
            });
        }

        public IObservable<Vector3> MoveDirection(PlayerId playerId)
        {
            return this.UpdateAsObservableForPlayerId(playerId).Select(_ => {
                var result = Vector3.zero;

                foreach (var movement in Movements)
                {
                    if (Input.GetKey(movement.Item1))
                    {
                        result += movement.Item2;
                    }
                }

                return result.normalized;
            }).TakeUntilDestroy(this);
        }

        public IObservable<Vector2> AimDirection(PlayerId playerId)
        {
            return this.UpdateAsObservableForPlayerId(playerId).Select(_ => {
                var result = Vector2.zero;

                foreach (var aim in Aims)
                {
                    if (Input.GetKey(aim.Item1))
                    {
                        result += aim.Item2;
                    }
                }

                return result.normalized;
            }).TakeUntilDestroy(this);
        }
    }

}