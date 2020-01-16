using UnityEngine;
using Util;

namespace Creatures
{
    public class Creature : MonoBehaviour
    {
        [SerializeField] protected float _movementSpeed;
        protected Rigidbody2D _rigidbody2D;
        protected Collider2D _collider2D;
        protected Animator _animator;
        protected bool _moving = false;
        protected Direction _moveDirection = Direction.None;
    }
}