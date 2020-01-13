using UnityEngine;

namespace Util
{
    public class KeyboardInput : MovementInput
    {
        private Direction _lastDirection = Direction.None;

        public override Direction GetMovementDirection()
        {
            return _lastDirection;
        }

        private void Update()
        {
            _lastDirection = GetDirectionByKey();
        }
        
        private static Direction GetDirectionByKey()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                return Direction.North;
            }
            
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                return Direction.East;
            }
            
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                return Direction.South;
            }
            
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                return Direction.West;
            }

            return Direction.None;
        }
    }
}