using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 5f;

    private CharacterController controller;

    private CameraFollow cameraFollow;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        cameraFollow = FindAnyObjectByType<CameraFollow>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Make the player face the direstion that the camera is facing (even after moving the camera around)
        float cameraYaw = cameraFollow.GetYaw();

        if (cameraFollow.IsFirstPerson())
        {
            transform.rotation = Quaternion.Euler(0, cameraYaw, 0);
        }

        Quaternion cameraRotation = Quaternion.Euler(0, cameraYaw, 0);

        Vector3 moveDirection = cameraRotation * new Vector3(horizontal, 0, vertical);

        controller.Move(moveDirection *  movespeed *Time.deltaTime);

        if (moveDirection.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }
}
