using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailManager : MonoBehaviour
{
    public static RailManager instance;

    public GameObject wagon;

    private float createInterval = 3.0f;
    private float time = 0.0f;

    public bool isEmptyRail_1 = false;
    public bool isEmptyRail_2 = false;
    public bool isEmptyRail_3 = false;

    private List<bool> isEmptyRail = new List<bool>();
    public List<Transform> railSpawnPositions = new List<Transform>();
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
                    Instantiate(wagon, railSpawnPositions[i].position, railSpawnPositions[i].rotation);
                    //StartCoroutine(SetIsEmptyTrue(i));
                    // player가 wagon위의 gameobject를 다 가져가면 삭제됨.
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
        isEmptyRail[i] = false;
        yield return new WaitForSeconds(3.0f);
        isEmptyRail[i] = true;
    }
}
