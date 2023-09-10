using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAlgorithms : MonoBehaviour
{
    //private MersenneAlgorithm.RandomMersenne Mer; 메르센 알고리즘 사용방법

    public UnitPanel unitpanel;
    public Unit[] units;
    private GameObject InstanceUnit;
    private static int index=0;
    [System.Serializable]
    public class Unit
    {
        public string name;
        public float rarityWeight;
    }

    void Start()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("Unit", 0); i++)
            Invoke("Rands", 2f);
        /*int seed = (int)System.DateTime.Now.Ticks; 메르센 알고리즘 사용방법
        Mer = new MersenneAlgorithm.RandomMersenne((uint)seed);
        int randomNum = Mer.IRandom(0, 100);
        Debug.Log("RanNum = " + randomNum);*/
    }
    private void Rands()
    {
        unitpanel = GameObject.Find("UnitPanel").GetComponent<UnitPanel>();
        InstanceUnit = new GameObject();
        // 가중치 총합 계산
        float totalWeight = 0;
        foreach (var unit in units)
        {
            totalWeight += unit.rarityWeight;
        }

        // 확률 계산 및 랜덤 선택
        float randomValue = Random.Range(0f, totalWeight);
        float cumulativeWeight = 0;

        foreach (var unit in units)
        {
            cumulativeWeight += unit.rarityWeight;
            if (randomValue <= cumulativeWeight)
            {
                Debug.Log("Selected unit: " + unit.rarityWeight);
                EqualsUnit(unit.rarityWeight);
                break;
            }
        }
    }
    private void EqualsUnit(float value)
    {
        int rand;
        switch (value)
        {
            case 59:
                rand = Random.Range(0, 3);
                if (rand == 0)
                {
                    unitpanel.SetUnit(index, "N_Saber");
                    index++;
                }
                else if (rand == 1)
                {
                    unitpanel.SetUnit(index, "N_Archer");
                    index++;
                }
                else if (rand == 2)
                {
                    unitpanel.SetUnit(index, "N_Caster");
                    index++;
                }
                break;
            case 30:
                rand = Random.Range(0, 3);
                if (rand == 0)
                {
                    unitpanel.SetUnit(index, "R_Saber");
                    index++;
                }
                else if (rand == 1)
                {
                    unitpanel.SetUnit(index, "R_Archer");
                    index++;
                }
                else if (rand == 2)
                {
                    unitpanel.SetUnit(index, "R_Caster");
                    index++;
                }
                break;
            case 10:
                rand = Random.Range(0, 3);
                if (rand == 0)
                {
                    unitpanel.SetUnit(index, "U_Saber");
                    index++;
                }
                else if (rand == 1)
                {
                    unitpanel.SetUnit(index, "U_Archer");
                    index++;
                }
                else if (rand == 2)
                {
                    unitpanel.SetUnit(index, "U_Caster");
                    index++;
                }
                break;
            case 1:
                rand = Random.Range(0, 3);
                if (rand == 0)
                {
                    unitpanel.SetUnit(index, "L_Saber");
                    index++;
                }
                else if (rand == 1)
                {
                    unitpanel.SetUnit(index, "L_Archer");
                    index++;
                }
                else if (rand == 2)
                {
                    unitpanel.SetUnit(index, "L_Caster");
                    index++;
                }
                break;
            default:
                rand = Random.Range(0, 4);
                if (rand == 0)
                {
                    unitpanel.SetUnit(index, "Hidden1");
                    index++;
                }
                else if (rand == 1)
                {
                    unitpanel.SetUnit(index, "Hidden2");
                    index++;
                }
                else if (rand == 2)
                {
                    unitpanel.SetUnit(index, "Hidden3");
                    index++;
                }
                else if (rand == 3)
                {
                    unitpanel.SetUnit(index, "Hidden4");
                    index++;
                }
                break;

        }


    }
    public void SpawnUnit2()
    {
        for(int i=0;i< PlayerPrefs.GetInt("Unit2", 0); i++)
        {
            Invoke("Rands", 2f);
        }
    }
    public void SpawnUnit3()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("Unit3", 0); i++)
        {
            Invoke("Rands", 2f);
        }
    }
}
