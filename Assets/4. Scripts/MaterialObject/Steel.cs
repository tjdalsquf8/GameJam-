using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steel : MonoBehaviour
{
    public void OnInteract(string hitTag)
    {
        if (hitTag == "LWorkTable")
        {
            GameManager.GameManager._Instance.houseSectionUsingCount += 1;
            this.gameObject.SetActive(false);
            if (GameManager.GameManager._Instance.houseSectionUsingCount < 1)
            {
                GameManager.GameManager._Instance.enablehouse1();
            }
            else if (GameManager.GameManager._Instance.houseSectionUsingCount > 1)
            {
                GameManager.GameManager._Instance.enablehouse1();
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

        if (hitTag == "RWorkTable")
        {
            GameManager.GameManager._Instance.houseSection2UsingCount += 1;
            this.gameObject.SetActive(false);
            if (GameManager.GameManager._Instance.houseSection2UsingCount < 1)
            {
                GameManager.GameManager._Instance.enablehouse2();
            }
            else if (GameManager.GameManager._Instance.houseSection2UsingCount > 1)
            {
                GameManager.GameManager._Instance.enablehouse2();
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
