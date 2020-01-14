using UnityEngine;

namespace Util
{
    public class MovementInput : MonoBehaviour, IMovementInput
    {
        //Unity dont let us serialize Interfaces so I had to find a dirty solution
        public virtual Direction GetMovementDirection()
        {
            return Direction.None;
        }

        public static Vector2 GetPositionByDirection(Vector2 currentPosition, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    currentPosition.y++;
                    break;
                case Direction.East:
                    currentPosition.x++;
                    break;
                case Direction.South:
                    currentPosition.y--;
                    break;
                case Direction.West:
                    currentPosition.x--;
                    break;
                case Direction.None:
                default:
                    break;
            }

            return currentPosition;
        }

        public static Vector2 GetPositionChangeByDirection(Direction direction)
        {
            var change = new Vector2();
            switch (direction)
            {
                case Direction.North:
                    change.y++;
                    break;
                case Direction.East:
                    change.x++;
                    break;
                case Direction.South:
                    change.y--;
                    break;
                case Direction.West:
                    change.x--;
                    break;
                case Direction.None:
                default:
                    break;
            }

            return change;
        }
    }
}