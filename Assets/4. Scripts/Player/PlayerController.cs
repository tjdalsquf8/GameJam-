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

    [SerializeField]
    private GameObject _righthand;

    private GameObject gettedMaterial;
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
            if (hit.collider.CompareTag("Wagon") && Input.GetKeyDown(keyCodeInteract) )
            {
                if(_righthand.transform.childCount < 1 && gettedMaterial == null)
                {
                    gettedMaterial = hit.collider.GetComponent<Wagon>().getHavingWagon();
                    gettedMaterial.transform.parent = _righthand.transform;
                    gettedMaterial.transform.localPosition = Vector3.one;

                }
                else
                {
                    // cant take object
                }
            }
            else if(!hit.collider.CompareTag("Wagon") && Input.GetKeyDown(keyCodeInteract))
            {
                IInteractable inter = gettedMaterial?.GetComponent<IInteractable>();
                if(inter != null)
                {
                    inter.OnInteract(hit.collider.gameObject);
                    // OnInteract ���� ������Ʈ�� ��� �ߴٴ� �� �߰��� ��.
                    gettedMaterial = null;
                }
                else
                {

                }
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

        if(z==0 && x<0)
        {
            movement.moveSpeed = 3;
            anim.SetBool("isWalking", false);
            anim.SetBool("LeftWalk", true);
        }

        else if(z == 0 && x > 0)
        {
            movement.moveSpeed = 3;
            anim.SetBool("isWalking", false);
            anim.SetBool("RightWalk", true);
        }

        else if (x != 0 || z != 0)
        {
            movement.moveSpeed = 3;
            anim.SetBool("LeftWalk", false);
            anim.SetBool("RightWalk", false);
            anim.SetBool("isWalking", true);
        }

        else
        {
            movement.moveSpeed = 0;
            anim.SetBool("LeftWalk", false);
            anim.SetBool("RightWalk", false);
            anim.SetBool("isWalking", false);
        }

        movement.MoveTo(new Vector3(x, 0.0f, z));
    }

}
