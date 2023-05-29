using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NetworkNonVRInputHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector3 moveInputVector = Vector3.zero;

    private Vector2 inputDirection;
    private bool isInput;

    [SerializeField] private RectTransform lever;
    [SerializeField] private RectTransform rectTransform;

    [SerializeField, Range(10, 150)] private float leverRange;

    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        isInput = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        isInput = false;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    private void ControlJoystickLever(PointerEventData eventData)
    {
        var inputPos = eventData.position - rectTransform.anchoredPosition;
        var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        lever.anchoredPosition = inputVector;
        inputDirection = inputVector / leverRange;
    }

    private void InputControlVector()
    {
        moveInputVector = new Vector3(inputDirection.x, 0f, inputDirection.y);
    }

    void Update()
    {
        moveInputVector = Vector3.zero;
        if (isInput)
        {
            InputControlVector();
        }
    }

    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();

        networkInputData.direction = moveInputVector;

        return networkInputData;
    }
}
