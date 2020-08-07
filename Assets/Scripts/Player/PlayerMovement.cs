using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class PlayerMovement : MonoBehaviour
        {

            public float speed = 3.0F;
            public float rotateSpeed = 3.0F;
            public float jumpSpeed = 8.0f;
            public float gravity = 20.0f;

            private CharacterController controller;
            private Vector3 moveDirection = Vector3.zero;

            private void Start()
            {
                controller = GetComponent<CharacterController>();
            }

            void Update()
            {
                // Rotate around y - axis
                transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

                if (controller.isGrounded)
                {
                    // We are grounded, so recalculate
                    // move direction directly from axes

                    moveDirection = transform.TransformDirection(Vector3.forward);
                    moveDirection *= Input.GetAxis("Vertical");
                    moveDirection *= speed;

                    if (Input.GetButton("Jump"))
                    {
                        moveDirection.y = jumpSpeed;
                    }
                }
                else
                {
                    // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
                    // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
                    // as an acceleration (ms^-2)
                    moveDirection.y -= gravity * Time.deltaTime;
                }

                // Move the controller
                controller.Move(moveDirection * Time.deltaTime);
            }
        }
    }
}