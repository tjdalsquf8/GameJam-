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
    }
    void Start()
    {
        for(int i = 0; i< Random.Range(1, 3); i++)
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
            Destroy(this.gameObject, 3.0f);
        }
        else
        {
            // movement logic
            this.transform.position =  Vector3.Slerp(this.transform.position, arrivePos.transform.position, Time.deltaTime * 0.01f);
            if(stackCount == 0)
            {
                isEmpty = true;
            }
            // player getted having wagon
            // if meterial is getted for player, isEmpty = false;
        }
    }
    public GameObject getHavingWagon()
    {
        if(havingWagon.Count != 0) {
            stackCount -= 1;
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

