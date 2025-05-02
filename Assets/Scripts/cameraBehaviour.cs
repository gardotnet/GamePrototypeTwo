using UnityEngine;

public class CameraBehaviour : MonoBehaviour {
    public Camera mainCamera;
    public float followSpeed = 1.5f;


    public Vector2 minBounds = new Vector2(-10f, -5f);
    public Vector2 maxBounds = new Vector2(10f, 5f);

    private Vector3 lastMousePosition;
    [SerializeField] private GameObject cameraManager;

    void Start()
    {
        cameraManager.SetActive(false);
    }
    public void unlockCamera(){
        cameraManager.SetActive(true);
        mainCamera ??= Camera.main;
        UpdateLastMousePosition();
    }

    void Update() {
        Vector3 mousePosition = GetMouseWorldPosition();

        if (Vector3.Distance(mousePosition, lastMousePosition) > 0) {
            Vector3 smoothPosition = Vector3.Lerp(mainCamera.transform.position, mousePosition, followSpeed * Time.deltaTime);
            mainCamera.transform.position = ClampPosition(smoothPosition);
            lastMousePosition = mousePosition;
        }
    }

    private void UpdateLastMousePosition() {
        lastMousePosition = GetMouseWorldPosition();
        lastMousePosition.z = mainCamera.transform.position.z;
    }

    private Vector3 GetMouseWorldPosition() {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = mainCamera.transform.position.z;
        return mousePosition;
    }

    private Vector3 ClampPosition(Vector3 position) {
        float halfHeight = mainCamera.orthographicSize;
        float halfWidth = mainCamera.aspect * halfHeight;

        float clampedX = Mathf.Clamp(position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);

        return new Vector3(clampedX, clampedY, position.z);
    }
}
