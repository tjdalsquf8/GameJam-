using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cement : MonoBehaviour, IInteractable
{
    GameManager.GameManager Instance;
    
    void Start()
    {
        Instance = GameManager.GameManager._Instance;
    }
    public void OnInteract(GameObject hit)
    {
        if (hit.CompareTag("tractor"))
        {
            Instance.cementUsingCount += 1;
            this.gameObject.SetActive(false);
            if (Instance.cementUsingCount < 3)
            {
                Instance.enableLoad();
            }
            else if(Instance.cementUsingCount < 4)
            {
                GameManager.GameManager._Instance.SectionLoadComplete();
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
