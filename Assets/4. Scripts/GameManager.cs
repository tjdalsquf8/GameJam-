using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager _Instance = null;

        public GameObject Afterplane;
        public GameObject Beforeplane;
        public GameObject BeforeHouse1;
        public GameObject BeforeHouse2;
        public GameObject AfterHouse1;
        public GameObject AfterHouse2;
        public GameObject OpenFence;
        public GameObject money;
        public int cementUsingCount = 0;
        public int houseSectionUsingCount = 0;
        public int houseSection2UsingCount = 0;
        public int fieldUsingCount = 0;

        private int playerScore = 100;

        public int clearSectionCount = 0;
        public bool loadSection = false;
        public bool houseSection = false;
        public bool houseSection2 = false;
        public bool fieldSection = false;



        public bool LoadSection { get => loadSection; set => loadSection = value; }
        public bool HouseSection { get => houseSection; set => houseSection = value; }
        public bool HouseSection2 { get => houseSection2; set => houseSection2 = value; }
        public bool FieldSection { get => fieldSection; set => fieldSection = value; }

        public List<GameObject> load = new List<GameObject>();
        public List<GameObject> house1 = new List<GameObject>();
        public List<GameObject> house2 = new List<GameObject>();
        public List<GameObject> field = new List<GameObject>();

        //UI
        public Text moneyText;

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
            DontDestroyOnLoad(_Instance);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(LoadSection&&HouseSection&&HouseSection2&&FieldSection)
            {
                UpdateMoney(1000000);
                OpenFence.SetActive(false);
            }
        }
        public void enableLoad()
        {
            for (int i = 0; i < 9; i++)
            {
                if (!load[i].activeSelf)
                {
                    load[i].SetActive(true);
                    return;
                }
            }
        }

        public void enablehouse1()
        {
            for (int i = 0; i < 1; i++)
            {
                if (!house1[i].activeSelf)
                {
                    house1[i].SetActive(true);
                    return;
                }
            }
        }

        public void enablehouse2()
        {
            for (int i = 0; i < 1; i++)
            {
                if (!house2[i].activeSelf)
                {
                    house2[i].SetActive(true);
                    return;
                }
            }
        }

        public void enableField()
        {
            for (int i = 0; i < 3; i++)
            {
                if (!field[i].activeSelf)
                {
                    field[i].SetActive(true);
                    return;
                }
            }
        }

        public void SectionLoadComplete()
        {
            LoadSection = true;
            cementUsingCount += 1;
            // GameObject 
            Afterplane.SetActive(true);
            Beforeplane.SetActive(false);
        }
        public void SectionHouse1Complete()
        {
            HouseSection = true;
            // GameObject 
            AfterHouse1.SetActive(true);
            BeforeHouse1.SetActive(false);
        }
        public void SectionHouse2Complete()
        {
            HouseSection2 = true;
            // GameObject 
            AfterHouse2.SetActive(true);
            BeforeHouse2.SetActive(false);
        }
        public void SectionFieldComplete()
        {
            FieldSection = true;
            // GameObject 
        }

        void UpdateMoney(int amount)
        {
            if (moneyText != null)
            {
                money.SetActive(true);
                moneyText.text = "400,000";
                Debug.Log("Money updated to: " + amount);
            }
        }
    }
}
