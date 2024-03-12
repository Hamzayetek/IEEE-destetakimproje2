using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private bool isDragging = false;
    private Vector3 screenPoint;
    private Vector3 offset;

    // Topun sürüklenme hýzý
    public float dragSpeed = 10f;

    private void OnMouseDown()
    {
        isDragging = true;
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            // Yeni konumu belirlerken y eksenini sabit tut
            curPosition.y = transform.position.y;

            // Topun daha hýzlý hareket etmesi için bir hýz çarpaný ekleyin
            Vector3 newPosition = Vector3.Lerp(transform.position, curPosition, Time.deltaTime * dragSpeed);
            rb.MovePosition(newPosition);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        rb.useGravity = true;
    }
}
