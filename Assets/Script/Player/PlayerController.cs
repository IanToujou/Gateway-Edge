using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] private float baseSpeed = 20.0f;
    [SerializeField] private float rotationSpeed = 10.0f;

    private Camera cam;
    private Rigidbody rb;

    void Start() {
        cam = FindObjectOfType<Camera>();
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        Vector3 moveInput = new Vector3(0, 0, 0);
    }

    void FixedUpdate() {

        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;
        if(groundPlane.Raycast(cameraRay, out rayLength)) {

            Vector3 rayPoint = cameraRay.GetPoint(rayLength);
            Vector3 pointToLook = new Vector3(rayPoint.x, transform.position.y, rayPoint.z);

            Vector3 pointToMove = Vector3.RotateTowards(rb.rotation.eulerAngles, pointToLook - transform.position, Mathf.PI / 2, 0.5f);

            Quaternion targetRotation = Quaternion.LookRotation(pointToMove);

            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, 0.1f);
            rb.velocity = pointToMove.normalized * 50 * baseSpeed * Time.deltaTime;

        }

    }

}
