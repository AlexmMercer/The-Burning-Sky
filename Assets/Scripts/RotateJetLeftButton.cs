using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RotateJetLeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isRotating = false;
    [SerializeField] GameObject Player;
    [SerializeField] float PlayerRotationSpeed;

    void Update()
    {
        if (isRotating && Player != null)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Player.transform.Rotate(Vector3.up, -PlayerRotationSpeed * Time.deltaTime);
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
