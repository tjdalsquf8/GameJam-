using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player; // trd
    public Transform fpsPlayer; // fps
    public float followSpeed = 10f;
    public float sensitivity = 100f;
    public float clampAngle = 70;

    private float rotX;
    private float rotY;
    private float smoothRotX;

    private float targetRotX; // ��ǥ X�� ȸ����
    private float currentRotX; // ���� X�� ȸ����
    private bool isFPS = false;

    public Transform realCamera;
    public Vector3 dirNormalized;
    public Vector3 finalDir;
    public float minDistance;
    public float maxDistance;
    public float finalDistance;
    public float smoothness = 10;
    // Start is called before the first frame update
    private void Awake()
    {
        // tps
        rotX = transform.localEulerAngles.x;
        rotY = transform.localEulerAngles.y;

        dirNormalized = realCamera.localPosition.normalized;
        finalDistance = realCamera.localPosition.magnitude; // ũ��

        smoothRotX = rotX;
        targetRotX = rotX;
        currentRotX = rotX;
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*  
          //rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

          rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
          Quaternion rot = Quaternion.Euler(rotX, 0, 0);
          transform.rotation = rot;*/
        if (Input.GetKeyDown(KeyCode.V))
        {
            isFPS = !isFPS;
            realCamera.parent = isFPS ? fpsPlayer : this.transform;
            realCamera.transform.position = isFPS ? Vector3.zero : this.transform.position;
        }
    }

    private void FixedUpdate()
    {
        // tps
        if (!isFPS)
        {
            float mouseDeltaY = -(Input.GetAxis("Mouse Y")) * sensitivity * Time.deltaTime * 5;
            targetRotX += mouseDeltaY; // ��ǥ ȸ������ ���콺 �Է��� �����ݴϴ�.

            // ��ǥ ȸ������ Ŭ�����Ͽ� ��ȿ�� ���� ������ �����մϴ�.
            targetRotX = Mathf.Clamp(targetRotX, -clampAngle, clampAngle);

            // �ε巯�� ������ ����Ͽ� ���� ȸ������ ��ǥ ȸ�������� ���������� �̵���ŵ�ϴ�.
            currentRotX = Mathf.Lerp(currentRotX, targetRotX, smoothness * Time.deltaTime);

            // ���� ȸ������ Quaternion���� ��ȯ�մϴ�.
            Quaternion smoothRot = Quaternion.Euler(currentRotX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            transform.rotation = smoothRot;
            //this.transform.rotation = Quaternion.Euler(rotX, this.transform.rotation.y, this.transform.rotation.z);
            transform.position = Vector3.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);

            finalDir = transform.TransformPoint(dirNormalized * maxDistance);

            RaycastHit hit;

            if (Physics.Linecast(transform.position, finalDir, out hit))
            {
                finalDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
            }
            else
            {
                finalDistance = maxDistance;
            }
            realCamera.localPosition = Vector3.Lerp(realCamera.localPosition, dirNormalized * finalDistance, Time.deltaTime * smoothness);
        }
        else // isFPS = =true;
        {
            realCamera.transform.localPosition = Vector3.zero;
            float mouseDeltaY = -(Input.GetAxis("Mouse Y")) * sensitivity * Time.deltaTime * 5;
            targetRotX += mouseDeltaY; // ��ǥ ȸ������ ���콺 �Է��� �����ݴϴ�.

            // ��ǥ ȸ������ Ŭ�����Ͽ� ��ȿ�� ���� ������ �����մϴ�.
            targetRotX = Mathf.Clamp(targetRotX, -clampAngle, clampAngle);

            // �ε巯�� ������ ����Ͽ� ���� ȸ������ ��ǥ ȸ�������� ���������� �̵���ŵ�ϴ�.
            currentRotX = Mathf.Lerp(currentRotX, targetRotX, smoothness * Time.deltaTime);

            // ���� ȸ������ Quaternion���� ��ȯ�մϴ�.
            Quaternion smoothRot = Quaternion.Euler(currentRotX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            transform.rotation = smoothRot;
        }
    }
}
