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
            new Tuple<KeyCode, Vector3>(KeyCode.W, Vector3.forward),
            new Tuple<KeyCode, Vector3>(KeyCode.A, Vector3.left),
            new Tuple<KeyCode, Vector3>(KeyCode.S, Vector3.back),
            new Tuple<KeyCode, Vector3>(KeyCode.D, Vector3.right),
            new Tuple<KeyCode, Vector3>(KeyCode.LeftShift, Vector3.up),
            new Tuple<KeyCode, Vector3>(KeyCode.LeftControl, Vector3.down),
        };

        private readonly static List<Tuple<KeyCode, Vector2>> Aims = new List<Tuple<KeyCode, Vector2>>
        {
            new Tuple<KeyCode, Vector2>(KeyCode.UpArrow, Vector2.up),
            new Tuple<KeyCode, Vector2>(KeyCode.LeftArrow, Vector2.left),
            new Tuple<KeyCode, Vector2>(KeyCode.DownArrow, Vector2.down),
            new Tuple<KeyCode, Vector2>(KeyCode.RightArrow, Vector2.right),
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