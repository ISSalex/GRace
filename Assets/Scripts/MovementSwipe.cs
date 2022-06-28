using UnityEngine;
using UnityEngine.EventSystems;

public class MovementSwipe : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] private Transform _car;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.x > 0)
            {
                _car.position += Vector3.left;
            }
            else
            {
                _car.position += Vector3.right;
            }
        }

        else
        {
            if (eventData.delta.y > 0)
            {
                _car.position += Vector3.back;
            }
            else
            {
                _car.position += Vector3.forward;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}
