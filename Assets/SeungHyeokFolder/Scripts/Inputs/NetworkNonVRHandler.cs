using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkNonVRHandler : MonoBehaviour
{
    [SerializeField] Transform _Joystick;
    NetworkNonVRInputHandler _nonVRInputHandler;

    Vector3 moveDirection;

    private Vector2 lastInputPosition;

    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private RectTransform exclusionArea;

    float rotationY;

    // Start is called before the first frame update
    void Awake()
    {
        _nonVRInputHandler = _Joystick.GetComponent<NetworkNonVRInputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check Movement Direction
        moveDirection = Vector3.zero;
        moveDirection = _nonVRInputHandler.getMoveDirection();

        // Check for swipe input on PC (mouse) or Android (touch)
        if (Input.GetMouseButtonDown(0))
        {
            lastInputPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 inputPosition = Input.mousePosition;
            rotationY = RotatePlayer(inputPosition - lastInputPosition);
            lastInputPosition = inputPosition;
        }
        else if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                lastInputPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 inputPosition = touch.position;
                rotationY = RotatePlayer(inputPosition - lastInputPosition);
                lastInputPosition = inputPosition;
            }
        }
    }

    private float RotatePlayer(Vector2 rotationInput)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(exclusionArea, lastInputPosition))
        {
            // The exclusion area contains the lastInputPosition, so skip rotation
            return 0f;
        }

        // Adjust rotation based on input speed and sensitivity
        // float rotationX = rotationInput.y * rotationSpeed * Time.deltaTime;
        float rotationY = -rotationInput.x * rotationSpeed * Time.deltaTime;
        return rotationY;

        
    }

    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();

        networkInputData.direction = moveDirection;
        networkInputData.rotationY = rotationY;

        return networkInputData;
    }
}
