using UnityEngine;
using System.Collections.Generic;

namespace Players.InputImpls
{
    public class GamePadInput
    {
        public enum Buttons
        {
            Triangle = 0,
            Circle,
            Cross,
            Square,
            DirectionUp,
            DirectionRight,
            DirectionDown,
            DirectionLeft,
            Right1,
            Left1,
            Right2,
            Left2,
            Right3,
            Left3,
            Option,
            Share,
            PS,
            Start
        }

        public enum Axes
        {
            RightX = 0,
            RightY,
            LeftX,
            LeftY,
            RightTrigger,
            LeftTrigger
        }

        private static Dictionary<Axes, bool> _isAlreadyTappedTrigger = new Dictionary<Axes, bool>
        {
            [Axes.RightTrigger] = false,
            [Axes.LeftTrigger] = false,
        };
        public static Dictionary<Axes, bool> IsAlreadyTappedTrigger => _isAlreadyTappedTrigger;

        private bool[] _buttons = new bool[18];
        private float[] _axes = new float[6];

        public GamePadInput(string joystickName, bool[] buttons, float[] axes)
        {
            switch (joystickName) {
                default:
                    InitDefault(buttons, axes);
                    break;
            }
        }

        private void InitDefault(bool[] buttons, float[] axes)
        {
            _buttons[0] = buttons[3];
            _buttons[1] = buttons[2];
            _buttons[2] = buttons[1];
            _buttons[3] = buttons[0];
            _buttons[8] = buttons[5];
            _buttons[9] = buttons[4];
            _buttons[10] = buttons[7];
            _buttons[11] = buttons[6];
            _buttons[12] = buttons[11];
            _buttons[13] = buttons[10];
            _buttons[14] = buttons[9];
            _buttons[15] = buttons[8];
            _buttons[16] = buttons[12];
            _buttons[17] = buttons[13];

            _buttons[4] = (axes[7] < 0);
            _buttons[6] = (axes[7] > 0);

            _buttons[7] = (axes[6] < 0);
            _buttons[5] = (axes[6] > 0);

            _axes[0] = axes[2];
            _axes[1] = axes[3];
            _axes[2] = axes[0];
            _axes[3] = axes[1];
            _axes[4] = axes[5];
            _axes[5] = axes[4];
        }

        private void InitXbox(bool[] buttons, float[] axes)
        {
            _buttons[0] = buttons[3];
            _buttons[1] = buttons[1];
            _buttons[2] = buttons[0];
            _buttons[3] = buttons[2];
            _buttons[8] = buttons[5];
            _buttons[9] = buttons[4];

            _buttons[10] = (axes[9] > 0);
            _buttons[11] = (axes[8] > 0);

            _buttons[12] = buttons[9];
            _buttons[13] = buttons[8];
            _buttons[14] = buttons[7];
            _buttons[15] = buttons[6];
            _buttons[16] = buttons[6];
            _buttons[17] = buttons[7];

            _buttons[4] = (axes[6] > 0);
            _buttons[6] = (axes[6] < 0);

            _buttons[7] = (axes[5] < 0);
            _buttons[5] = (axes[5] > 0);

            _axes[0] = axes[3];
            _axes[1] = axes[4];
            _axes[2] = axes[0];
            _axes[3] = axes[1];
            _axes[4] = axes[9];
            _axes[5] = axes[8];
        }

        public bool Button(Buttons button)
        {
            return _buttons[(int)button];
        }

        public float Axis(Axes axis)
        {
            return _axes[(int)axis];
        }
    }
}