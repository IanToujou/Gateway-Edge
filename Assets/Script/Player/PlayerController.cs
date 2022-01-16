using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] private float baseSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float boostRotationSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private int playerHealth;
    [SerializeField] private float deathSpeed;
    [SerializeField] private float damageDelay;
    [SerializeField] private GameObject trail;

    private Camera cam;
    private PlayerCamera camController;
    private Rigidbody rb;
    private float speedMultiplier;
    private bool boosting;
    private bool boostingPad;
    private bool braking;
    private bool brakingPad;
    private float currentRotationSpeed;
    private bool freezed;
    private bool dead;
    private Vector3 startPosition;
    private bool teleportInsteadDeath;
    private bool damageDelayed;

    //Disable controls in the tutorial
    private bool allowRotation = true;
    private bool allowBrake = true;
    private bool allowBoost = true;
    private bool failRotation = false;

    void Start() {
        cam = FindObjectOfType<Camera>();
        camController = cam.GetComponent<PlayerCamera>();
        rb = GetComponent<Rigidbody>();
        speedMultiplier = 1;
        boosting = false;
        boostingPad = false;
        braking = false;
        brakingPad = false;
        currentRotationSpeed = rotationSpeed;
        freezed = false;
        startPosition = gameObject.transform.position;
        allowRotation = true;
        allowBrake = true;
        allowBoost = true;
        failRotation = false;
        teleportInsteadDeath = false;
        damageDelayed = false;
    }

    void Update() {

        Vector3 moveInput = new Vector3(0, 0, 0);

        //Update controls
        if(allowBoost) boosting = (Input.GetAxisRaw("Vertical") >= 0.5f);
        if(allowBrake) braking = (Input.GetAxisRaw("Vertical") <= -0.5f);

    }

    void FixedUpdate() {

        if(freezed || dead) {
            trail.SetActive(false);
            rb.velocity = Vector3.zero;
            LevelManager.GetCurrentManager().StopTimer();
            return;
        } else {
            trail.SetActive(true);
            LevelManager.GetCurrentManager().StartTimer();
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

            if(boostingPad) {
                currentRotationSpeed = boostRotationSpeed;
                camController.Shake(0.1f, 0.1f, 1f);
                if(rb.velocity.magnitude <= minSpeed - 0.1f) {
                    rb.velocity = transform.TransformDirection(new Vector3(0, rb.velocity.y, baseSpeed + acceleration * speedMultiplier * 30));
                    speedMultiplier++;
                }
                return;
            }

            if(brakingPad) {
                currentRotationSpeed = boostRotationSpeed;
                if(rb.velocity.magnitude >= minSpeed + 0.1f) {
                    rb.velocity = transform.TransformDirection(new Vector3(0, rb.velocity.y, baseSpeed + acceleration * speedMultiplier));
                    speedMultiplier--;
                }
                return;
            }

            //Check for any controls
            if(boosting && !braking) {

                currentRotationSpeed = boostRotationSpeed;
                camController.Shake(0.1f, 0.1f, 1f);

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
            if(failRotation) {
                PlayerDeath();
            } else if(rb.velocity.magnitude >= deathSpeed) {
                PlayerDeath();
            }
        }

    }

    void PlayerDeath() {

        if(teleportInsteadDeath) {

            gameObject.transform.position = startPosition;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            camController.Shake(1f, 0.3f, 1f);

        } else {

            if(damageDelayed) return;
            StartCoroutine(TakeDamage());

            if(playerHealth <= 0) {
                LevelManager.GetCurrentManager().PlayerDeath();
                dead = true;
            }
            
        }
        
    }

    public IEnumerator TakeDamage() {

        camController.Shake(3f, 0.2f, 1f);
        playerHealth--;
        damageDelayed = true;
        yield return new WaitForSeconds(damageDelay);
        damageDelayed = false;

    }
    
    public void SetBoostingPad(bool boostingPad) {
        this.boostingPad = boostingPad;
    }

    public void SetBrakingPad(bool brakingPad) {
        this.brakingPad = brakingPad;
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

    public int GetPlayerHealth() {
        return playerHealth;
    }

    public void SetPlayerHealth(int playerHealth) {
        this.playerHealth = playerHealth;
    }

}
