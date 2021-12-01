using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] private float baseSpeed = 5.0f;
    [SerializeField] private float rotationSpeed = 30.0f;

    private Rigidbody rigidBody;
    private Camera cam;

    void Start() {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
    }

    void FixedUpdate() {

        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;
        if(groundPlane.Raycast(cameraRay, out rayLength)) {

            Vector3 rayPoint = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, rayPoint, Color.blue);

            Vector3 pointToLook = new Vector3(rayPoint.x, transform.position.y, rayPoint.z);
            transform.LookAt(pointToLook);

            Vector3 pointToMove = new Vector3(pointToLook.x, pointToLook.y, pointToLook.z);
            transform.position = Vector3.MoveTowards(transform.position, pointToMove, baseSpeed * Time.deltaTime);

        }

    }

}
