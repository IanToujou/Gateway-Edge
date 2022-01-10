using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] private float baseSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float boostRotationSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deathSpeed;
    [SerializeField] private GameObject trail;

    private Camera cam;
    private Rigidbody rb;
    private float speedMultiplier;
    private bool boosting;
    private bool braking;
    private float currentRotationSpeed;
    private bool freezed;
    private Vector3 startPosition;
    private bool teleportInsteadDeath;

    //Disable controls in the tutorial
    private bool allowRotation = true;
    private bool allowBrake = true;
    private bool allowBoost = true;
    private bool failRotation = false;

    void Start() {
        cam = FindObjectOfType<Camera>();
        rb = GetComponent<Rigidbody>();
        speedMultiplier = 1;
        boosting = false;
        braking = false;
        currentRotationSpeed = rotationSpeed;
        freezed = false;
        startPosition = gameObject.transform.position;
        allowRotation = true;
        allowBrake = true;
        allowBoost = true;
        failRotation = false;
        teleportInsteadDeath = false;
    }

    void Update() {

        Vector3 moveInput = new Vector3(0, 0, 0);

        //Update controls
        if(allowBoost) boosting = (Input.GetAxisRaw("Vertical") >= 0.5f);
        if(allowBrake) braking = (Input.GetAxisRaw("Vertical") <= -0.5f);

    }

    void FixedUpdate() {

        if(freezed) {
            trail.SetActive(false);
            rb.velocity = Vector3.zero;
            return;
        } else {
            trail.SetActive(true);
        }

        //Create a camera ray that points on a virtual ground plane to find the mouse cursor.
        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        //Anything related to mouse movement if a mouse pointer has been found.
        float rayLength;
        if(groundPlane.Raycast(cameraRay, out rayLength)) {

            if(allowRotation) {
                if(failRotation) currentRotationSpeed /= 10;
                Vector3 rayPoint = cameraRay.GetPoint(rayLength);
                Vector3 pointToLook = new Vector3(rayPoint.x, transform.position.y, rayPoint.z);
                Vector3 pointToMove = Vector3.RotateTowards(rb.rotation.eulerAngles, pointToLook - transform.position, Mathf.PI / 2, 0.5f);
                Quaternion targetRotation = Quaternion.LookRotation(pointToMove);
                rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, 0.1f * currentRotationSpeed);
            }

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

    void OnCollisionEnter(Collision collision) {

        //Check for death
        if(collision.gameObject.CompareTag("Wall")) {
            if(rb.velocity.magnitude >= deathSpeed) {
                Die();
            }
        }

    }

    void Die() {

        if(teleportInsteadDeath) {
            gameObject.transform.position = startPosition;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        } else {
            Debug.Log("Death.");
        }
        
    }

    public void SetFreezed(bool freezed) {
        this.freezed = freezed;
    }

    public bool IsFreezed() {
        return freezed;
    }

    public void SetAllowRotation(bool allowRotation) {
        this.allowRotation = allowRotation;
    }

    public bool IsAllowRotation() {
        return allowRotation;
    }

    public void SetAllowBrake(bool allowBrake) {
        this.allowBrake = allowBrake;
    }

    public bool IsAllowBrake() {
        return allowBrake;
    }

    public void SetAllowBoost(bool allowBoost) {
        this.allowBoost = allowBoost;
    }

    public bool IsAllowBoost() {
        return allowBoost;
    }

    public void SetFailRotation(bool failRotation) {
        this.failRotation = failRotation;
    }

    public bool IsFailRotation() {
        return failRotation;
    }

    public bool IsTeleportInsteadDeath() {
        return teleportInsteadDeath;
    }

    public void SetTeleportInsteadDeath(bool teleportInsteadDeath) {
        this.teleportInsteadDeath = teleportInsteadDeath;
    }

}
