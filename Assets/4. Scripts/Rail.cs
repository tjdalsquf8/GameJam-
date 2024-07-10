using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    public enum RailNumber{
        num1,
        num2,
        num3
    }
    public RailNumber railNumber;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wagon"))
        {
            switch (railNumber)
            {
                case RailNumber.num1:
                    RailManager.instance.isEmptyRail_1 = true;
                    break;
                case RailNumber.num2:
                    RailManager.instance.isEmptyRail_2 = true; break;
                case RailNumber.num3:
                    RailManager.instance.isEmptyRail_3 = true; break; 
            }   
        }
    }
}
