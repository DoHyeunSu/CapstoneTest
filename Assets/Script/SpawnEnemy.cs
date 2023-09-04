using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnEnemy : MonoBehaviour
{
    private int num = 0;
    private Vector2 vec = new Vector2();
    private bool RoundCheck = false;
    private GameObject[] EnemyNum;
    private GameObject lastenemy;
    private ButtonMange bm;
    private bool lastTrigger = false;
    private EndText end;

    public int roundNum = 1;
    public bool spawnBool;
    public GameObject[] enemy_prefab;
    // Start is called before the first frame update
    void Start()
    {
        vec = this.transform.position;
        EnemyNum = new GameObject[PlayerPrefs.GetInt("Enemy", 0)];
        lastenemy = new GameObject();
        bm = GameObject.Find("Canvas").GetComponent<ButtonMange>();
        end = GameObject.Find("Canvas").GetComponent<EndText>();
        InvokeRepeating("SpawnEnemies", 5, 1);//5�� �ĺ��� 1�ʸ��� �ݺ� ����
    }

    // Update is called once per frame
    void Update()
    {
        if (RoundCheck)
        {
            roundNum++;
            RoundCheck = false;
        }
        if(lastenemy==null)
        {
            bm.StartGame();
            lastenemy = new GameObject();
            if (roundNum == 3 && lastTrigger)
            {
                Debug.Log("���� ��");
                try
                {
                    //end.Finish = true;
                    /*if (lastenemy.GetComponent<EnemyStat>().Round3())
                        end.Finish = true;
                    else
                        end.Finish = false;*/
                    /*Debug.Log(end.Finish);
                    if (lastenemy.GetComponent<EnemyStat>().returnHP() <= 0)
                        end.Finish = true;
                    else
                        end.Finish = false;*/
                }
                catch(NullReferenceException ie)
                {
                    Debug.Log("������ ����");
                }
                end.EndPanelAni();
            }
        }
        
    }
    void SpawnEnemies()
    {
        if (spawnBool == true)
        {
            if (roundNum == 1)
            {
                if (num < PlayerPrefs.GetInt("Enemy", 0))
                {
                    EnemyNum[num] = (GameObject)Instantiate(enemy_prefab[0], vec, Quaternion.identity);
                    if (num == PlayerPrefs.GetInt("Enemy", 0) - 1)
                    {
                        Debug.Log("������");
                        lastenemy = EnemyNum[num];
                    }
                        
                    //GameObject enemy = (GameObject)Instantiate(enemy_prefab[0], vec, Quaternion.identity);
                    num++;
                }
                else
                {
                    spawnBool = false;
                    RoundCheck = true;
                }
                    
            }
            else if (roundNum == 2)
            {
                if (num < PlayerPrefs.GetInt("Enemy", 0))
                {
                    EnemyNum[num] = (GameObject)Instantiate(enemy_prefab[1], vec, Quaternion.identity);
                    if (num == PlayerPrefs.GetInt("Enemy", 0) - 1)
                    {
                        Debug.Log("������");
                        lastenemy = EnemyNum[num];
                    }
                    num++;
                }
                else
                {
                    spawnBool = false;
                    RoundCheck = true;
                }
            }
            else if (roundNum == 3)
            {
                GameObject enemy = (GameObject)Instantiate(enemy_prefab[2], vec, Quaternion.identity);
                lastenemy = enemy;
                spawnBool = false;
                lastTrigger = true;
            }
        }
        /*if (spawnBool == true)
        {
            if (num < 10)
            {
                if (roundNum == 1)
                {
                    GameObject enemy = (GameObject)Instantiate(enemy_prefab[0], vec, Quaternion.identity);
                    num++;
                }
                else if (roundNum == 2)
                {
                    GameObject enemy = (GameObject)Instantiate(enemy_prefab[1], vec, Quaternion.identity);
                    num++;
                }
                
            }
            else
                spawnBool = false;
        }*/
    }
    public void ClickSpawn()
    {
        spawnBool = true;
        Debug.Log("�̹� ���� : " + roundNum);
        num = 0;
    }
}
