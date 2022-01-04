using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] private float baseSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float boostRotationSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float acceleration;

    private Camera cam;
    private Rigidbody rb;
    private float speedMultiplier;
    private bool boosting;
    private bool braking;
    private float currentRotationSpeed;

    void Start() {
        cam = FindObjectOfType<Camera>();
        rb = GetComponent<Rigidbody>();
        speedMultiplier = 1;
        boosting = false;
        braking = false;
        currentRotationSpeed = rotationSpeed;
    }

    void Update() {

        Vector3 moveInput = new Vector3(0, 0, 0);

        //Update controls
        boosting = (Input.GetAxisRaw("Vertical") >= 0.5f);
        braking = (Input.GetAxisRaw("Vertical") <= -0.5f);

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

            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, 0.1f * currentRotationSpeed);

            //Check for any controls
            if(boosting && !braking) {

                currentRotationSpeed = boostRotationSpeed;

                //Check if the player magnitude is at maximum speed. If not, accelerate.
                if(rb.velocity.magnitude <= maxSpeed - 0.1f) {
                    rb.velocity = transform.TransformDirection(new Vector3(0, rb.velocity.y, baseSpeed + acceleration * speedMultiplier));
                    speedMultiplier++;
                } else {
                    rb.velocity = transform.TransformDirection(new Vector3(0, rb.velocity.y, maxSpeed));
                }

            } else if(braking && !boosting) {
                
                currentRotationSpeed = rotationSpeed;

                //Brake
                //Check if the player magnitude is at minimum speed. If not, brake.
                if(rb.velocity.magnitude >= minSpeed + 0.1f) {
                    rb.velocity = transform.TransformDirection(new Vector3(0, rb.velocity.y, baseSpeed + acceleration * speedMultiplier));
                    speedMultiplier--;
                } else {
                    rb.velocity = transform.TransformDirection(new Vector3(0, rb.velocity.y, minSpeed));
                }

            } else {
                
                currentRotationSpeed = rotationSpeed;

                //Turn back to base speed.
                if(speedMultiplier > 1) {
                    speedMultiplier--;
                } else if(speedMultiplier < 1) {
                    speedMultiplier++;
                }

                //Check if the player is near the base speed. If not, brake.
                if(rb.velocity.magnitude > baseSpeed + 0.1f) {
                    rb.velocity = transform.TransformDirection(new Vector3(0, rb.velocity.y, baseSpeed + acceleration * speedMultiplier));
                } else {
                    rb.velocity = transform.TransformDirection(new Vector3(0, rb.velocity.y, baseSpeed));
                }

            }

        }

    }

}
