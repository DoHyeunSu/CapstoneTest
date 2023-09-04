using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffButton : MonoBehaviour
{
    public GameObject[] units;

    private int atk_v;
    private int ori;
    private int randomNum;
    private float times;
    private bool on;
    private MersenneAlgorithm.RandomMersenne Mer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        units = GameObject.FindGameObjectsWithTag("Player");
        if (on)
        {
            times += Time.deltaTime;
            if (times > 5f)
            {
                if (randomNum < 40)
                {
                    ApplyBuff(-10);
                }
                else if (randomNum < 80)
                {
                    ApplyBuff(10);
                }
                else if (randomNum < 90)
                {
                    ApplyBuff(-40);
                }
                else if (randomNum < 100)
                {
                    ApplyBuff(40);
                }
                on = !on;
                times = 0f;
            }
        }
    }
    public void OnClickBuff()
    {
        if (on == false)
        {
            on = !on;
            int seed = (int)System.DateTime.Now.Ticks;
            Mer = new MersenneAlgorithm.RandomMersenne((uint)seed);
            randomNum = Mer.IRandom(0, 100);
            if (randomNum < 40)//공격력 10업
            {
                ApplyBuff(10);
            }
            else if (randomNum < 80)
            {
                ApplyBuff(-10);
            }
            else if (randomNum < 90)
            {
                ApplyBuff(40);
            }
            else if (randomNum < 100)
            {
                ApplyBuff(-40);
            }
        }
        else
            Debug.Log("이미 버프가 활성화 되있습니다");
        
    }
    void ApplyBuff(int value)
    {
        for (int i = 0; i < units.Length; i++)
        {
            atk_v = units[i].GetComponent<UnitAction>().AtkValue;
            atk_v += value;
            units[i].GetComponent<UnitAction>().AtkValue = atk_v;
        }
    }
}
