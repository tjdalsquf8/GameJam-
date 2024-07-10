using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wagon : MonoBehaviour
{
    public enum WagonCategory{
        cement,
        steel,
        rice
    }

    public WagonCategory category;
    // ÀÚÀç
    public GameObject steel;
    public GameObject rice;
    public GameObject cement;
    public Transform spawnPos;

    private GameObject carryingMater;

    public Transform arrivePos; // arrive this gameobject position

    private Stack<GameObject> havingWagon = new Stack<GameObject>();


    private bool loadSection = false;
    private bool houseSection = false;
    private bool houseSection2 = false;
    private bool fieldSection = false;

    private bool isEmpty = false;


    private int stackCount;

    private void Awake()
    {
        category = (WagonCategory)Random.Range(0, 1); // 3 -> value 
    }
    void Start()
    {
        switch (category)
        {
            case WagonCategory.cement:
                carryingMater = cement;
                break;
            case WagonCategory.steel:
                carryingMater = steel;
                break;
            case WagonCategory.rice:
                carryingMater = rice;
                break;
        }
        for (int i = 0; i< Random.Range(1, 3); i++) // 3 -> value change
        {
            GameObject obj = Instantiate(carryingMater, spawnPos.position, spawnPos.rotation);
            havingWagon.Push(obj);
        }
        stackCount = havingWagon.Count;

    }

    // Update is called once per frame
    void Update()
    {
        if (isEmpty)
        {
            Debug.Log("if statement isEMpty");
            Destroy(this.gameObject, 3.0f);
        }
        else
        {
            // movement logic
          //  this.transform.position =  Vector3.Slerp(this.transform.position, arrivePos.transform.position, Time.deltaTime * 0.01f);
            Debug.Log(stackCount);
            if(stackCount == 0)
            {
                Debug.Log("Empty");
                isEmpty = true;
            }
            // player getted having wagon
            // if meterial is getted for player, isEmpty = false;
        }
    }
    public GameObject getHavingWagon()
    {
        if(stackCount != 0) {
            stackCount -= 1;
            Debug.Log(stackCount);
            return havingWagon.Pop();
        }
        {
            return null;
        }
    }
    // load - cement
    // house - cement, steel
    // field - rice
}

