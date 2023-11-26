using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    private CsvReader csv;
    public int HpValue;
    public int EnemyKey;
    private bool lastFinish;
    private EndText end;
    private int num;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Level", 0) == 1)//난이도에 따른 몬스터 체력 계수
            num = 50;
        else if (PlayerPrefs.GetInt("Level", 0) == 2)
            num = 100;
        else if (PlayerPrefs.GetInt("Level", 0) == 3)
            num = 150;
        csv = GameObject.Find("GameManager").GetComponent<CsvReader>();
        HpValue = csv.GetData(EnemyKey).MaxHp + num;
        end = GameObject.Find("Canvas").GetComponent<EndText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HpValue <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("Canvas").GetComponent<CoinScript>().AddCoin();
        }
        if (EnemyKey == 103 && HpValue <= 0)
            end.Finish = true;
    }
    public void DamageEnemy(int AtkValue)
    {
        HpValue -= AtkValue;
        //Debug.Log(HpValue);
    }
    public int returnHP()
    {
        return HpValue;
    }
    public bool Round3()
    {
        return lastFinish;
    }
}
