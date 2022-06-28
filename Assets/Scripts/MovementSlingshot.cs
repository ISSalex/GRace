using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSlingshot : MonoBehaviour
{
    [SerializeField] private Rigidbody carRigid;
    [SerializeField] private Rigidbody shootRigid;

    [SerializeField] private float maxDistance = 2f; 

    [SerializeField] private bool isPressed = false;

    private void Start()
    {
        carRigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isPressed == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, shootRigid.position) > maxDistance)
            {
                carRigid.position = shootRigid.position + (mousePos - shootRigid.position).normalized * maxDistance;
            }
            else
            {
                carRigid.position = mousePos;
            }
        }
    }
    private void OnMouseDown()
    {
        isPressed = true;
        carRigid.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        carRigid.isKinematic = false;

        StartCoroutine(LetGo());
    }

    IEnumerator LetGo()
    {
        yield return new WaitForSeconds(0.1f);

        gameObject.GetComponent<SpringJoint>();

    }
}
