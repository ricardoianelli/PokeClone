using UnityEngine;
using Util;

namespace Creatures
{
    public class Creature : MonoBehaviour
    {
        [SerializeField]
        protected float _movementSpeed;
        protected Rigidbody2D _rigidbody2D;
        protected bool _moving = false;
        protected Direction _lookDirection = Direction.None;
        protected Direction _moveDirection = Direction.None;
        
        public static Vector2 GetPositionByDirection(Vector2 currentPosition, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    currentPosition.y--;
                    break;
                case Direction.East:
                    currentPosition.x++;
                    break;
                case Direction.South:
                    currentPosition.y++;
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
    }
}