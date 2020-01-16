using System.Collections;
using UnityEngine;
using Util;
using Vector2 = UnityEngine.Vector2;

namespace Creatures
{
    public class MainPlayer : Creature
    {
        
        [SerializeField]
        protected MovementInput movementInput;

        void Start()
        {
            _movementSpeed = 4;
            _animator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        // Update is called once per frame
        private void FixedUpdate()
        {
            
            _moveDirection = movementInput.GetMovementDirection();
            _moving = (_moveDirection != Direction.None);
            _animator.SetBool("moving", _moving);
            if (_moving)
            {
                MoveCharacter(_moveDirection);
            }
        }

        private void MoveCharacter(Direction moveDirection)
        {
            var positionChange = MovementInput.GetPositionChangeByDirection(_moveDirection);
            _animator.SetFloat("moveX", positionChange.x);
            _animator.SetFloat("moveY", positionChange.y);
            _rigidbody2D.MovePosition(transform.position + (Vector3)positionChange * (_movementSpeed * Time.deltaTime));
        }
    }
}