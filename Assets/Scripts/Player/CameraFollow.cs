using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    //Distance from the player
    public float distance = 8f;

    //Height above the player
    public float height = 4f;

    //Camera rotation speed
    public float rotationSpeed = 120f;

    public float minPitch = 10f;
    public float maxPitch = 60f;

    private float yaw = 0f;
    private float pitch = 9f;

    //Camera zoooooooom
    public float zoomSpeed = 5f;
    public float minDistance = 3f;
    public float maxDistance = 15f;

    //First person settings
    public float firstPersonThreshold = 1.5f;
    public Vector3 firstPersonOffset = new Vector3(0f, 1.7f, 0f);

    //Get rid of player in first person
    public GameObject playerVisual;

    private void LateUpdate()
    {
        //Zoom using the scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        distance -= scroll * zoomSpeed;

        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        //Rotate the camera while holding right mouse
        if (Input.GetMouseButton(1))
        {
            yaw += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

            pitch -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        }

        bool firstPerson = distance <= firstPersonThreshold;

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        //First person camera
        if (firstPerson)
        {
            transform.position = player.position + firstPersonOffset;

            transform.rotation = rotation;
        }

        //If not in first person (third person camera)
        else
        {
            float currentHeight = Mathf.Lerp(1.5f, height, distance / maxDistance);
            Vector3 offset = rotation * new Vector3(0f, currentHeight, -distance);
            transform.position = player.position + offset;

            transform.LookAt(player.position + Vector3.up * 2f);
        }

        //Get rid of player model while in first person
        playerVisual.SetActive(!firstPerson);
    }

    public float GetYaw()
    {
        return yaw;
    }

    public bool IsFirstPerson()
    {
        return distance <= firstPersonThreshold;
    }
}
