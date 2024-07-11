using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;

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

    private GameObject gettedMaterial = null;
    //RayCast
    RaycastHit hit;
    
    //Animator
    private Animator anim;
    public bool isWalking = false;
    public LayerMask raycastLayerMask;
    public GameObject GuideImage;

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
        // Camera의 중앙에서 Ray 발사
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        // 광선을 시각적으로 그리기 (길이와 색상 설정)
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 0.3f); ;

        if (Physics.Raycast(ray ,out hit, 3.0f, ~raycastLayerMask))
        {
            if(hit.collider.CompareTag("Sign"))
            {
                if(Input.GetKeyDown(keyCodeInteract))
                {
                    GuideImage.SetActive(!GuideImage.activeSelf);
                }

            }

            if (hit.collider.CompareTag("Wagon") && Input.GetKeyDown(keyCodeInteract) )
            {
                if(_righthand.transform.childCount < 3 && gettedMaterial == null)
                {
                    gettedMaterial = hit.collider.GetComponent<Wagon>().getHavingWagon();
                    gettedMaterial.GetComponent<Rigidbody>().isKinematic = true;
                    gettedMaterial.GetComponent<Collider>().enabled = false;
                    gettedMaterial.transform.parent = _righthand.transform;
                    gettedMaterial.transform.localPosition = Vector3.zero;
                }
                else
                {
                    // cant take object
                }
            }
            else if(!hit.collider.CompareTag("Wagon") && Input.GetKeyDown(keyCodeInteract))
            {
                IInteractable inter = gettedMaterial != null ? gettedMaterial?.GetComponent<IInteractable>() : null;
                if (inter != null)
                {
                    inter.OnInteract(hit.collider.tag);
                    Destroy(gettedMaterial);
                    // gettedMaterial 삭제
                }
                else
                {

                }
            }
        }
        else
        {

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
