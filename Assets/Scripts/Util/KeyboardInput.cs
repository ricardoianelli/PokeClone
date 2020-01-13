using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Util
{
    public class KeyboardInput : MovementInput
    {
        private Direction _lastDirection = Direction.None;
        private IList<KeyCode> _keysPressed = new List<KeyCode>();
        
        private readonly  IList<KeyCode> _keyCodeList = new List<KeyCode>()
            {KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.LeftArrow};

        public override Direction GetMovementDirection()
        {
            return _lastDirection;
        }

        private void Update()
        {
            UpdatePressedKeys();
            _lastDirection = GetDirectionByKeycode(_keysPressed.LastOrDefault());
        }

        private static Direction GetDirectionByKeycode(KeyCode keycode)
        {
            switch (keycode)
            {
                case KeyCode.UpArrow:
                    return Direction.North;
                case KeyCode.RightArrow:
                    return Direction.East;
                case KeyCode.DownArrow:
                    return Direction.South;
                case KeyCode.LeftArrow:
                    return Direction.West;
                default:
                    return Direction.None;
            }
        }

        private void UpdatePressedKeys()
        {
            foreach (var keyCode in _keyCodeList)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    _keysPressed.Add(keyCode);
                }

                if (Input.GetKeyUp(keyCode))
                {
                    _keysPressed.Remove(keyCode);
                }
            }
        }
    }
}