using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    
    [SerializeField] private GameObject cameraFocus;

    private Transform camTransform;
	private float shakeDuration;
	private float shakeAmount;
	private float decreaseFactor;
    private float originalY;

    void Awake() {
        camTransform = gameObject.transform;
        shakeDuration = 0f;
        shakeAmount = 0f;
        decreaseFactor = 1f;
        originalY = gameObject.transform.position.y;
    }

    void FixedUpdate() {

        //Get the player transform.
        Transform playerTransform = cameraFocus.transform;

        if (shakeDuration > 0) {
            Vector3 position = new Vector3(playerTransform.position.x, originalY, playerTransform.position.z);
			camTransform.localPosition = position + Random.insideUnitSphere * shakeAmount;
			shakeDuration -= Time.deltaTime * decreaseFactor;
		} else {
			shakeDuration = 0f;
			//Move the camera relative to the player's position.
            transform.position = new Vector3(playerTransform.position.x, originalY, playerTransform.position.z);
		}
        
    }

    public void Shake(float amount, float duration, float decrease) {

        this.shakeAmount = amount;
        this.shakeDuration = duration;
        this.decreaseFactor = decrease;

    }

}
