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
    }
}