using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Players.InputImpls {
    public class KeyboardInputEventProvider : MonoBehaviour, IInputEventProvider
    {
        private class MovementMap {
            public KeyCode KeyCode;
            public Vector3 Direction;

            public MovementMap(KeyCode keyCode, Vector3 direction)
            {
                KeyCode = keyCode;
                Direction = direction;
            }
        }

        private readonly static Dictionary<PlayerId, List<MovementMap>> PlayerMovementMaps = new Dictionary<PlayerId, List<MovementMap>>
        {
            [PlayerId.Player1] = {
                new MovementMap(KeyCode.W, Vector3.forward),
                new MovementMap(KeyCode.A, Vector3.left),
                new MovementMap(KeyCode.S, Vector3.back),
                new MovementMap(KeyCode.D, Vector3.right),
                new MovementMap(KeyCode.LeftShift, Vector3.up),
                new MovementMap(KeyCode.LeftControl, Vector3.down),
            },
            [PlayerId.Player2] = {
                new MovementMap(KeyCode.UpArrow, Vector3.forward),
                new MovementMap(KeyCode.LeftArrow, Vector3.left),
                new MovementMap(KeyCode.DownArrow, Vector3.back),
                new MovementMap(KeyCode.RightArrow, Vector3.right),
                new MovementMap(KeyCode.RightShift, Vector3.up),
                new MovementMap(KeyCode.Return, Vector3.down),
            },
        };

        public IObservable<Vector3> MoveDirection(PlayerId playerId)
        {
            return Observable.EveryUpdate().Select(_ => {
                var res = Vector3.zero;

                foreach (var movementMap in PlayerMovementMaps[playerId])
                {
                    if (Input.GetKey(movementMap.KeyCode))
                    {
                        res += movementMap.Direction;
                    }
                }

                return res.normalized;
            }).TakeUntilDestroy(this);
        }
    }

}