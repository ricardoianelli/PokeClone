using System;
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
            _collider2D = GetComponent<Collider2D>();
        }
        
        // Update is called once per frame
        /*private void FixedUpdate()
        {
            
            _moveDirection = movementInput.GetMovementDirection();
            _moving = (_moveDirection != Direction.None);
            _animator.SetBool("moving", _moving);
            if (_moving)
            {
                MoveCharacter(_moveDirection);
            }
        }*/
        private void Update()
        {
            
            if (_moving) return;
            
            _moveDirection = movementInput.GetMovementDirection();
            
            if (_moveDirection != Direction.None)
            {
                MoveByDirection(_moveDirection);
            }
        }
        
        private void UpdateMoveAnimation()
        {
            var positionChange = MovementInput.GetPositionChangeByDirection(_moveDirection);
            _animator.SetFloat("moveX", positionChange.x);
            _animator.SetFloat("moveY", positionChange.y);
            _animator.SetBool("moving", _moving);
        }

        private void MoveByDirection(Direction direction)
        {
            var newPosition = MovementInput.GetPositionByDirection(_rigidbody2D.position, direction);
            _collider2D.enabled = false;
            var hit = Physics2D.Linecast(_rigidbody2D.position, newPosition);
            _collider2D.enabled = true;
            if (hit.transform == null)
            {
                _moving = true;
                UpdateMoveAnimation();
                StartCoroutine(MoveCharacter(newPosition));
            }
        }
       
        private IEnumerator MoveCharacter(Vector2 toPosition)
        {	
            	
            while (_rigidbody2D.position != toPosition)	
            {	
                _rigidbody2D.position =	
                    Vector2.MoveTowards(_rigidbody2D.position, toPosition, Time.deltaTime * _movementSpeed);	
                yield return 0;	
            }	

            _moving = false;	
            _animator.SetBool("moving", false);	
        }
    }
}