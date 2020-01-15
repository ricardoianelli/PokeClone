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
        private void Update()
        {
            
            if (_moving) return;
            
            _moveDirection = movementInput.GetMovementDirection();

            if (_moveDirection != Direction.None)
            {
                UpdateMoveAnimation();
                _moving = true;
                _animator.SetBool("moving", true);
                StartCoroutine(MoveCharacter(_moveDirection));
            }
        }

        private IEnumerator MoveCharacter(Direction moveDirection)
        {
            var newPosition = MovementInput.GetPositionByDirection(_rigidbody2D.position, moveDirection);
            while (_rigidbody2D.position != newPosition)
            {
                _rigidbody2D.position =
                    Vector2.MoveTowards(_rigidbody2D.position, newPosition, Time.deltaTime * _movementSpeed);
                yield return 0;
            }

            _moving = false;
            _animator.SetBool("moving", false);
        }

        private void UpdateMoveAnimation()
        {
            var positionChange = MovementInput.GetPositionChangeByDirection(_moveDirection);
            _animator.SetFloat("moveX", positionChange.x);
            _animator.SetFloat("moveY", positionChange.y);
            
            //_animator.SetBool("moving", _moving);
        }
    }
}