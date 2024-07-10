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

    public Wagon onDestroyEvent;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void WagonOnDestroy()
    {
        switch (railNumber)
        {
            case RailNumber.num1:
                RailManager.instance.isEmptyRail[0] = true;
                break;
            case RailNumber.num2:
                RailManager.instance.isEmptyRail[1] = true; break;
            case RailNumber.num3:
                RailManager.instance.isEmptyRail[2] = true; break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wagon"))
        {
            onDestroyEvent = other.gameObject?.GetComponent<Wagon>();
            onDestroyEvent.OnObjectDestroy += WagonOnDestroy;
        }
    }
}
