using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumber : MonoBehaviour
{
    public static int RUnit, REnemy, RLevel;

    // Start is called before the first frame update
    void Awake()
    {
        RUnit = Random.Range(1, 4);
        REnemy = Random.Range(15, 30);
        RLevel = Random.Range(1, 4);
        PlayerPrefs.SetInt("Unit", RUnit);
        PlayerPrefs.SetInt("Enemy", REnemy);
        PlayerPrefs.SetInt("Level", RLevel);
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
