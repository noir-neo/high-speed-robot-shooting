using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Players.InputImpls
{
    class GamePadInputEventProvider : MonoBehaviour, IInputEventProvider
    {
        private static readonly Dictionary<PlayerId, string> _joystickIds = new Dictionary<PlayerId, string>
        {
            [PlayerId.Player1] = "Joystick1",
            [PlayerId.Player2] = "Joystick2",
        };

        private IObservable<GamePadInput> GamePadInputAsObservable(PlayerId playerId)
        {
            return this.UpdateAsObservable()
                .Where(_ => Input.GetJoystickNames().Length >= (int)playerId)
                .Select(_ =>
                {
                    var joystickId = _joystickIds[playerId];;

                    var buttons = new bool[20];
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        buttons[i] = Input.GetButton(joystickId + "Button" + i);
                    }

                    var axes = new float[13];
                    for (int i = 0; i < axes.Length; i++)
                    {
                        axes[i] = Input.GetAxis(joystickId + "Axis" + i);
                    }

                    var joystickName = Input.GetJoystickNames()[(int)playerId - 1];
                    return new GamePadInput(joystickName, buttons, axes);
                });
        }

        public IObservable<Vector3> MoveDirection(PlayerId playerId)
        {
            return GamePadInputAsObservable(playerId).
                Select(gamePadInput =>
                {
                    var result = Vector3.zero;
                    result += Vector3.forward * gamePadInput.Axis(GamePadInput.Axes.LeftY);
                    result += Vector3.right * gamePadInput.Axis(GamePadInput.Axes.LeftX);
                    if (gamePadInput.Button(GamePadInput.Buttons.Right2)) {
                        result += Vector3.up;
                    }
                    if (gamePadInput.Button(GamePadInput.Buttons.Left2)) {
                        result += Vector3.down;
                    }
                    return result.normalized;
                }).
                TakeUntilDestroy(this);
        }

        public IObservable<Vector2> AimDirection(PlayerId playerId)
        {
            return GamePadInputAsObservable(playerId).
                Select(gamePadInput =>
                    new Vector2(
                        gamePadInput.Axis(GamePadInput.Axes.RightX),
                        gamePadInput.Axis(GamePadInput.Axes.RightY)
                    ).normalized
                ).
                TakeUntilDestroy(this);
        }

        public IObservable<bool> ShootButton(PlayerId playerId)
        {
            return GamePadInputAsObservable(playerId)
                .Select(x => x.Button(GamePadInput.Buttons.Right1))
                .TakeUntilDestroy(this);
        }
    }
}