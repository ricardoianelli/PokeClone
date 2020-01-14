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
            //Animator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        // Update is called once per frame
        private void Update()
        {
            
            if (_moving) return;
            
            print("not moving");
            var movementDirection = movementInput.GetMovementDirection();
            print(movementDirection);
            if (movementDirection != Direction.None)
            {
                _moving = true;
                StartCoroutine(MoveCharacter(movementDirection));
            }
        }

        private IEnumerator MoveCharacter(Direction moveDirection)
        {
            var newPosition = GetPositionByDirection(_rigidbody2D.position, moveDirection);
            while (_rigidbody2D.position != newPosition)
            {
                _rigidbody2D.position =
                    Vector2.MoveTowards(_rigidbody2D.position, newPosition, Time.deltaTime * _movementSpeed);
                yield return 0;
            }

            _moving = false;
        }
    }
}