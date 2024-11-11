using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class InputHandler : MonoBehaviour, AxisState.IInputAxisProvider
{
    [HideInInspector]
    public InputAction horizontal;
    [HideInInspector]
    public InputAction vertical;

    private Camera cam;
    private CinemachineFreeLook cmFreeLook;
    [SerializeField]
    private GameObject player;

    void Start()
    {
        cam = this.GetComponentInChildren<Camera>();
        cmFreeLook = this.GetComponent<CinemachineFreeLook>();

        if (cam == null)
        {
            Debug.LogError("No Camera found on this GameObject or in the scene as 'Main Camera'.");
            return;
        }

        int layer = cam.gameObject.layer;

        // Accessing and modifying the camera's rect directly
        Rect viewRect = cam.rect;

        switch (layer)
        {
            case var _ when layer == LayerMask.NameToLayer("Player 1"):
                viewRect.x = 0.5f;
                viewRect.y = -0.5f;
                break;
            case var _ when layer == LayerMask.NameToLayer("Player 2"):
                viewRect.x = -0.5f;
                viewRect.y = 0.5f;
                break;
            case var _ when layer == LayerMask.NameToLayer("Player 3"):
                viewRect.x = 0.5f;
                viewRect.y = 0.5f;
                break;
            default:
                Debug.LogWarning("Layer not recognized for this GameObject.");
                break;
        }

        // Apply the updated rect to the camera
        cmFreeLook.Follow = player.transform;
        cmFreeLook.LookAt = player.transform;
        cam.rect = viewRect;
    }

    public float GetAxisValue(int axis)
    {
        switch (axis)
        {
            case 0: return horizontal.ReadValue<Vector2>().x;
            case 1: return horizontal.ReadValue<Vector2>().y;
            case 2: return vertical.ReadValue<float>();
        }

        return 0;
    }
}
