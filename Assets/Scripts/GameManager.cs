using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameManager
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager _Instance = null;
        public GameObject wagon; // 
        public Transform createPos; // create Wagon position

        private int playerScore = 100;

        private bool loadSection = false;
        private bool houseSection = false;
        private bool houseSection2 = false;
        private bool fieldSection = false;

        private float createInterval = 3.0f;
        private float time = 0.0f;

        public bool LoadSection { get => loadSection; set => loadSection = value; }
        public bool HouseSection { get => houseSection; set => houseSection = value; }
        public bool HouseSection2 { get => houseSection2; set => houseSection2 = value; }
        public bool FieldSection { get => fieldSection; set => fieldSection = value; }

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
            if (time > createInterval)
            {
                time = 0.0f;
                Instantiate(wagon, createPos.position, createPos.rotation);
            }
            else
            {
                time += Time.deltaTime;
            }
        }


    }

}