using System.Collections;
using System.Collections.Generic;
using Cainos.PixelArtTopDown_Basic;
using UnityEngine;
using Mirror;


public class PlayerMovement : NetworkBehaviour
    {
        public float speed;

        private Animator animator;
        public Joystick joystick;

        public Camera cam;
        
        private void Start()
        {

            #if UNITY_ANDROID
                joystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
            #endif
            animator = GetComponent<Animator>();
        }


        public override void OnStartLocalPlayer()
        {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        cam.GetComponent<CameraFollow>().target = transform;

        }


    private void Update()
        {
            if (!isLocalPlayer) return;

            Vector2 dir = Vector2.zero;

#if UNITY_ANDROID
            if(joystick.isActiveAndEnabled)
            {

                if (joystick.Vertical < 0)
                {

                    animator.SetInteger("Direction", 0);
                }
                if (joystick.Vertical > 0)
                {

                    animator.SetInteger("Direction", 1);
                }

                if (joystick.Horizontal < 0 && Mathf.Abs(joystick.Horizontal) > Mathf.Abs(joystick.Vertical))
                {
                    animator.SetInteger("Direction", 3);
                }

                if (joystick.Horizontal > 0 && Mathf.Abs(joystick.Horizontal) > Mathf.Abs(joystick.Vertical) )
                {

                    animator.SetInteger("Direction", 2);
                }

                dir.x = joystick.Horizontal;
                dir.y = joystick.Vertical;
            }
#endif

        if (Input.GetKey(KeyCode.A) )           
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W) )
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S) )
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
