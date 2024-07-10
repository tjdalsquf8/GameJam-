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
            if (GameManager.GameManager._Instance.cementUsingCount < 10)
            {
                GameManager.GameManager._Instance.enableLoad();
                if (GameManager.GameManager._Instance.cementUsingCount >= 9)
                {
                    GameManager.GameManager._Instance.SectionLoadComplete();
                }
            }
        }
        else if(hitTag == "LWorkTable" )
        {
            GameManager.GameManager._Instance.cementUsingToHouse1 += 1;
        }
        else if(hitTag == "RWorkTable")
        {
            GameManager.GameManager._Instance.cementUsingToHouse2 += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

}
}
