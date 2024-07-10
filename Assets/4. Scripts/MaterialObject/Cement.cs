using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cement : MonoBehaviour, IInteractable
{
    public void OnInteract(string hitTag)
    {
        if (hitTag == "Tractor")
        {
            GameManager.GameManager._Instance.cementUsingCount += 1;
            this.gameObject.SetActive(false);
            if (GameManager.GameManager._Instance.cementUsingCount < 9)
            {
                GameManager.GameManager._Instance.enableLoad();
            }
            else if(GameManager.GameManager._Instance.cementUsingCount > 8)
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
