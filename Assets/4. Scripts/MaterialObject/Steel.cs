using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steel : MonoBehaviour, IInteractable
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
            else if (GameManager.GameManager._Instance.houseSectionUsingCount > 1 && GameManager.GameManager._Instance.cementUsingToHouse1 > 2)
            {
                GameManager.GameManager._Instance.SectionHouse1Complete();
            }
            else
            {
                return;
            }
        }

        if (hitTag == "RWorkTable")
        {
            GameManager.GameManager._Instance.houseSection2UsingCount += 1;

            this.gameObject.SetActive(false);
            if (GameManager.GameManager._Instance.houseSection2UsingCount < 1)
            {
                GameManager.GameManager._Instance.enablehouse2();
            }
            else if (GameManager.GameManager._Instance.houseSection2UsingCount > 1 && GameManager.GameManager._Instance.cementUsingToHouse2 > 2)
            {
                GameManager.GameManager._Instance.SectionHouse2Complete();
            }
            else
            {
                return;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
