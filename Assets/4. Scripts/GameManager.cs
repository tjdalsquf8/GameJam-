using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;


namespace GameManager
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager _Instance = null;
        public GameObject wagon; // 
        public Transform createPos; // create Wagon position


        public int cementUsingCount = 0;
        public int houseSectionUsingCount = 0;
        public int houseSection2UsingCount = 0;
        public int fieldUsingCount = 0;

        private int playerScore = 100;

        private bool loadSection = false;
        private bool houseSection = false;
        private bool houseSection2 = false;
        private bool fieldSection = false;

   

        public bool LoadSection { get => loadSection; set => loadSection = value; }
        public bool HouseSection { get => houseSection; set => houseSection = value; }
        public bool HouseSection2 { get => houseSection2; set => houseSection2 = value; }
        public bool FieldSection { get => fieldSection; set => fieldSection = value; }

        public List<GameObject> load = new List<GameObject>();
        private void Awake()
        {
            if (_Instance == null)
            {
                _Instance = this;
            }
            else
            {
                Destroy(this);

            }
            DontDestroyOnLoad(gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
           
        }
        public void enableLoad()
        {
            for(int i = 0; i< 9; i++)
            {
                if (load[i].activeSelf == false)
                {
                    load[i].SetActive(true);
                    return;
                }
            }
        }

       public void SectionLoadComplete()
        {
            LoadSection = true;
            // GameObject 
        }
    }

}