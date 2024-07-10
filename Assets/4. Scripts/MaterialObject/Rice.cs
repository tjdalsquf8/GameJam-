using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rice : MonoBehaviour, IInteractable
{
    public void OnInteract(string hitTag)
    {
        if (hitTag == "RiceTable")
        {
            GameManager.GameManager._Instance.fieldUsingCount += 1;
            this.gameObject.SetActive(false);
            if (GameManager.GameManager._Instance.fieldUsingCount < 4)
            {
                GameManager.GameManager._Instance.enableField();
                if (GameManager.GameManager._Instance.fieldUsingCount >= 3)
                {
                    GameManager.GameManager._Instance.SectionFieldComplete();
                }
            }
            else if (GameManager.GameManager._Instance.fieldUsingCount > 3)
            {
                GameManager.GameManager._Instance.SectionFieldComplete();
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
