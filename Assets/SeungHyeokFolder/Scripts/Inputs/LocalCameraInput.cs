using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalCameraInput : MonoBehaviour
{
    private Vector2 lastInputPosition;

    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private RectTransform exclusionArea;

    private void Update()
    {
        // Check for swipe input on PC (mouse) or Android (touch)
        if (Input.GetMouseButtonDown(0))
        {
            lastInputPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 inputPosition = Input.mousePosition;
            RotateCamera(inputPosition - lastInputPosition);
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
                RotateCamera(inputPosition - lastInputPosition);
                lastInputPosition = inputPosition;
            }
        }
    }

    private void RotateCamera(Vector2 rotationInput)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(exclusionArea, lastInputPosition))
        {
            // The exclusion area contains the lastInputPosition, so skip rotation
            return;
        }

        // Adjust rotation based on input speed and sensitivity
        float rotationX = rotationInput.y * rotationSpeed * Time.deltaTime;
        float rotationY = -rotationInput.x * rotationSpeed * Time.deltaTime;

        // Apply rotation to the camera or parent GameObject
        transform.Rotate(rotationX, rotationY, 0f, Space.Self);
    }
}
