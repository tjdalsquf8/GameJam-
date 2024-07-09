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

    public Transform headTransform;
    private readonly KeyCode keyCodeInteract = KeyCode.F;

    private RotateToMouse rotateToMouse;
    private MovementCharacterController movement;

    //RayCast
    RaycastHit hit;
    
    //Animator
    private Animator anim;
    public bool isWalking = false;


    private void Awake()
    {
        rotateToMouse = GetComponent<RotateToMouse>();
        movement = GetComponent<MovementCharacterController>();
        anim = GetComponent<Animator>();
    }

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
               // inventory에 오브젝트 추가
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
            movement.moveSpeed = 3;
            anim.SetBool("isWalking", true);
        }
        else
        {
            movement.moveSpeed = 0;
            anim.SetBool("isWalking", false);
        }

        movement.MoveTo(new Vector3(x, 0.0f, z));
    }

}
