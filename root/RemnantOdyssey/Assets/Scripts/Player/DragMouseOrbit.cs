using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse drag Orbit with zoom")]
public class DragMouseOrbit : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private float distanceFromTarget = 5.0f;
    [SerializeField] private float horizontalOffset = 0f;
    [SerializeField] private float verticalOffset = 0f;
    [SerializeField] private float XSpeed = 10.0f;
    [SerializeField] private float YSpeed = 10.0f;
    [SerializeField] private float YMinLimit = -20f;
    [SerializeField] private float YMaxLimit = 80f;
    [SerializeField] private float distanceMin = 1f;
    [SerializeField] private float distanceMax = 15f;
    [SerializeField] private float SmoothTime = 2f;
    private float rotationYAxis;
    private float rotationXAxis;
    private float velocityX;
    private float velocityY;

    void Start()
    {
        rotationXAxis = transform.eulerAngles.x;
        rotationYAxis = transform.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (!Target) { return; }

        velocityX += XSpeed * Input.GetAxis("Mouse X") * 0.02f;
        velocityY += YSpeed * Input.GetAxis("Mouse Y") * 0.02f;
        rotationYAxis += velocityX;
        rotationXAxis -= velocityY;
        rotationXAxis = ClampAngle(rotationXAxis, YMinLimit, YMaxLimit);
        var rotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);

        distanceFromTarget = Mathf.Clamp(distanceFromTarget - Input.GetAxis("Mouse ScrollWheel") * 5f, distanceMin, distanceMax);
        var negDistance = new Vector3(-horizontalOffset, -verticalOffset, -distanceFromTarget);
        var position = rotation * negDistance + Target.position;

        transform.rotation = rotation;
        transform.position = position;
        velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * SmoothTime);
        velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * SmoothTime);
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
        {
            angle += 360F;
        }
        if (angle > 360F)
        {
            angle -= 360F;
        }

        return Mathf.Clamp(angle, min, max);
    }
}