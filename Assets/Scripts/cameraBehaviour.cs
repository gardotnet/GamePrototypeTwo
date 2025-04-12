using UnityEngine;

public class cameraBehaviour : MonoBehaviour {
    public Camera mainCamera;
    public float followSpeed = 5f;
    public float moveThreshold = 0.01f;

    private Vector3 lastMousePosition;

    void Start() {
        if (mainCamera == null) {
            mainCamera = Camera.main;
        }
        lastMousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        lastMousePosition.z = mainCamera.transform.position.z;
    }

    void Update() {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = mainCamera.transform.position.z;

        if (Vector3.Distance(mousePosition, lastMousePosition) > moveThreshold) {
            Vector3 smoothPosition = Vector3.Lerp(mainCamera.transform.position, mousePosition, followSpeed * Time.deltaTime);

            mainCamera.transform.position = smoothPosition;
            lastMousePosition = mousePosition;
        }
    }
}
