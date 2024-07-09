using System.Collections;
using System.Collections.Generic;
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

    private GameObject carryingMater;

    public Transform carryingPos;
    public Transform arrivePos; // arrive this gameobject position


    private Stack<GameObject> havingWagon = new Stack<GameObject>();


    private bool loadSection = false;
    private bool houseSection = false;
    private bool houseSection2 = false;
    private bool fieldSection = false;

    private bool isEmpty = false;
    
    
    

    private List<GameObject> sections = new List<GameObject>();
    private void Awake()
    {
        sections.Add(cement);
        sections.Add(steel);
        sections.Add(rice);
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
            //this.transform.position =  Vector3.Slerp(this.transform.position, arrivePos.position, 10);
            // player getted having wagon
            // if meterial is getted for player, isEmpty = false;
        }
    }
    public GameObject getHavingWagon()
    {
        if(havingWagon.Count != 0) {
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

