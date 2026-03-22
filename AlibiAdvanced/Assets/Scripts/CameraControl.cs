using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform[] targetPoints;

    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;

    private Transform currentTarget;

    void Start()
    {

        if (targetPoints.Length > 0)
        {
            currentTarget = targetPoints[0];
        }


    }


    void Update()
    {
        InputDetection();
        CamMovement();
    }


    void InputDetection()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentTarget = targetPoints[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentTarget = targetPoints[2];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentTarget = targetPoints[3];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentTarget = targetPoints[4];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentTarget = targetPoints[5];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            currentTarget = targetPoints[0];
        }


    }

    void CamMovement()
    {
        if(currentTarget == null)
        {
            return;
        }

        transform.position = Vector3.Lerp(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Slerp(transform.rotation, currentTarget.rotation, rotationSpeed * Time.deltaTime);

    }




}
