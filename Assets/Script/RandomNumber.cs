using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumber : MonoBehaviour
{
    public static int RUnit, REnemy, RLevel, RUnit2, RUnit3;
    private MersenneAlgorithm.RandomMersenne Mer;

    // Start is called before the first frame update
    void Awake()
    {
        int seed = (int)System.DateTime.Now.Ticks;
        Mer = new MersenneAlgorithm.RandomMersenne((uint)seed);

        /*RUnit = Random.Range(1, 4);
        REnemy = Random.Range(15, 30);
        RLevel = Random.Range(1, 4);*/
        RUnit = Mer.IRandom(1, 4);
        REnemy = Mer.IRandom(15, 30);
        RLevel = Mer.IRandom(1, 4);
        RUnit2= Mer.IRandom(1, 4);
        RUnit3 = Mer.IRandom(1, 4);
        PlayerPrefs.SetInt("Unit", RUnit);
        PlayerPrefs.SetInt("Enemy", REnemy);
        PlayerPrefs.SetInt("Level", RLevel);
        PlayerPrefs.SetInt("Unit2", RUnit2);
        PlayerPrefs.SetInt("Unit3", RUnit3);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetValue(string sh)
    {
        if (sh == "Unit")
            return RUnit;
        else if (sh == "Enemy")
            return REnemy;
        else if (sh == "Level")
            return RLevel;
        return 0;
    }
}
