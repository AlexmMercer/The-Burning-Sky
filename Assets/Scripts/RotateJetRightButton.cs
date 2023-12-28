using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateJetRightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isRotating = false;
    [SerializeField] GameObject Player;
    [SerializeField] float PlayerRotationSpeed;

    void Update()
    {
        if (isRotating && Player != null)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Player.transform.Rotate(Vector3.up, PlayerRotationSpeed * Time.deltaTime);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isRotating = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isRotating = false;
    }
}
