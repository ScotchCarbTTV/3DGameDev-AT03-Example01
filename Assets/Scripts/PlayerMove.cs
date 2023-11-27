using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpHeight = 2.0f;

    private Vector3 playerVelocity = new Vector3();

    private bool isGrounded;


    //reference to the character controller
    private CharacterController cTroller;

    private void Awake()
    {
        if(!TryGetComponent<CharacterController>(out cTroller))
        {
            Debug.Log("Needs a characer controler attached");
            gameObject.SetActive(false);            
        }
    }

    private void Update()
    {
        MovementInputs();
    }

    private void MovementInputs()
    {

        isGrounded = cTroller.isGrounded;

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

            //declare a vector3 for handling the final movement direction and velocity
        Vector3 motion = new Vector3();

        motion.x = Input.GetAxis("Horizontal");
        motion.z = Input.GetAxis("Vertical");

        cTroller.Move(transform.rotation * motion * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * Physics.gravity.y);
        }

        playerVelocity.y += Physics.gravity.y * Time.deltaTime;

    }

}
