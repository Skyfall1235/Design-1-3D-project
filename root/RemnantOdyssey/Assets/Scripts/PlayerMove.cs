using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] public float movementSpeed;

    private CharacterController charController;

    private bool isJumping;
    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] public float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] public KeyCode pauseKey;
    public bool isPlaying;

    private void Awake()
    {
        CanMove();
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            PlayerMovement();
        }
        if(Input.GetKeyUp(pauseKey))
        {
            isPlaying = false;
        }
    }

    public void CanMove()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isPlaying = true;
    }

    public void CannotMove()
    {
        Cursor.lockState = CursorLockMode.None;
        isPlaying = false;
    }

    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;
        charController.SimpleMove((forwardMovement + rightMovement).normalized * movementSpeed);
        JumpInput();
    }
     private void JumpInput()
    {
        if(Input.GetKeyDown(jumpKey)&& !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }
    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);
        charController.slopeLimit = 45.0f;
        isJumping = false;
    }

}
