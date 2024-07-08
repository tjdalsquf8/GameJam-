using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    public TMP_InputField inputField;
    public Transform headTransform;
    private readonly KeyCode keyCodeInteract = KeyCode.F;

    private RotateToMouse rotateToMouse;
    private MovementCharacterController movement;
    //RayCast
    public Camera Camera;
    public float holdDistance = 2.0f;
    RaycastHit hit;
    private void Awake()
    {
        rotateToMouse = GetComponent<RotateToMouse>();
        movement = GetComponent<MovementCharacterController>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateUpdate();
        MoveUpdate();
        Vector3 direction = headTransform.forward;
        if (Physics.Raycast(headTransform.position, direction, out hit, 10.0f))
        {
            if (hit.collider.CompareTag("Wagon"))
            {
                // wagon에 있는 옵젝 가져오기
            }
        }
    }
    private void RotateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotateToMouse.UpdateRotate(mouseX, mouseY);
    }
    private void MoveUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (x != 0 || z != 0)
        {
            movement.moveSpeed = 10;
            // anim
        }
        else
        {
            movement.moveSpeed = 0;
        }

        movement.MoveTo(new Vector3(x, 0.0f, z));
    }

}
