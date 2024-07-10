using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailManager : MonoBehaviour
{
    public static RailManager instance;

    public GameObject wagon;

    private float createInterval = 3.0f;
    private float time = 0.0f;

    

    public List<bool> isEmptyRail = new List<bool>();
    public List<Transform> railSpawnPositions = new List<Transform>();
    public List<Transform> arrivePosition = new List<Transform>();
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(instance);
    }
    void Start()
    {
        isEmptyRail.Add(true);
        isEmptyRail.Add(true);
        isEmptyRail.Add(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (time > createInterval)
        {
            time = 0.0f;
            for(int i = 0; i<3; i++)
            {
                if (isEmptyRail[i] == true)
                {
                    GameObject newWagon =  Instantiate(wagon, railSpawnPositions[i].position, railSpawnPositions[i].rotation);
                    newWagon.GetComponent<Wagon>().ArrivePos = arrivePosition[i];
                    isEmptyRail[i] = false;
                    break;
                }
            }
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    IEnumerator SetIsEmptyTrue(int i)
    {
        yield return new WaitForSeconds(3.0f);
        isEmptyRail[i] = true;
    }
}
