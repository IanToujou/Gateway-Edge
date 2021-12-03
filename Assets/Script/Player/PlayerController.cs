using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] private float baseSpeed = 20.0f;
    [SerializeField] private float maxSpeed = 1.0f;
    [SerializeField] private float rotationSpeed = 30.0f;
    [SerializeField] private float boostAmount = 3f;

    private Camera cam;
    private Rigidbody rb;
    private bool boostKey;

    void Start() {
        cam = FindObjectOfType<Camera>();
        rb = GetComponent<Rigidbody>();
        boostKey = false;
    }

    void Update() {
        bool boostKey = (Input.GetAxisRaw("Vertical") >= 0.5f);
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

            //rb.velocity = (pointToMove.normalized * baseSpeed);

            transform.position = Vector3.MoveTowards(transform.position, pointToMove, baseSpeed * Time.deltaTime);

        }

    }

}
