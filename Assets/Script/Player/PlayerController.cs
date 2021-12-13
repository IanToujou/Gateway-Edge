using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] private float baseSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxSpeed;

    private Camera cam;
    private Rigidbody rb;
    private float speedMultiplier;

    void Start() {
        cam = FindObjectOfType<Camera>();
        rb = GetComponent<Rigidbody>();
        speedMultiplier = 1;
    }

    void Update() {
        Vector3 moveInput = new Vector3(0, 0, 0);
    }

    void FixedUpdate() {

        //Create a camera ray that points on a virtual ground plane to find the mouse cursor.
        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        //Anything related to mouse movement if a mouse pointer has been found.
        float rayLength;
        if(groundPlane.Raycast(cameraRay, out rayLength)) {

            Vector3 rayPoint = cameraRay.GetPoint(rayLength);
            Vector3 pointToLook = new Vector3(rayPoint.x, transform.position.y, rayPoint.z);

            Vector3 pointToMove = Vector3.RotateTowards(rb.rotation.eulerAngles, pointToLook - transform.position, Mathf.PI / 2, 0.5f);

            Quaternion targetRotation = Quaternion.LookRotation(pointToMove);

            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, 0.1f * rotationSpeed);
            
            //Check if the player magnitude is at maximum speed. If not, accelerate.
            if(rb.velocity.magnitude < maxSpeed) {
                rb.velocity = transform.TransformDirection(new Vector3(0, rb.velocity.y, baseSpeed + 0.1f * speedMultiplier));
                speedMultiplier++;
            } else {
                rb.velocity = transform.TransformDirection(new Vector3(0, rb.velocity.y, maxSpeed));
            }

        }

    }

}
