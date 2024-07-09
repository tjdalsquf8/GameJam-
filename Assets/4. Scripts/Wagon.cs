using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon : MonoBehaviour
{
    // ÀÚÀç
    public GameObject steel;
    public GameObject rice;
    public GameObject cement;

    public Transform arrivePos; // arrive this gameobject position

    private GameObject havingWagon;


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
        havingWagon = sections[Random.Range(0, sections.Count)];
    }
    void Start()
    {

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
            this.transform.position =  Vector3.Slerp(this.transform.position, arrivePos.position, 10);
            // player getted having wagon
            // if meterial is getted for player, isEmpty = false;
        }
    }
    public GameObject getHavingWagon()
    {
        GameObject temp = havingWagon;
        havingWagon = null;
        return temp;
    }
    // load - cement
    // house - cement, steel
    // field - rice
}

