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
    private GameObject Unit_Window;
    private bool UnitOn;

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
        InvokeRepeating("SpawnEnemies", 5, 1);//5초 후부터 1초마다 반복 실행
        Unit_Window = GameObject.Find("Unit_Window");
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
                Debug.Log("게임 끝");
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
                    Debug.Log("마지막 종료");
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
                        //Debug.Log("마지막");
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
                        Debug.Log("마지막");
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
                if (lastenemy == null)
                    On_UnitWindow();
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
        Debug.Log("이번 라운드 : " + roundNum);
        num = 0;
        if(roundNum==1)
            GameObject.Find("GameManager").GetComponent<RandomAlgorithms>().SpawnUnit2();
        else if(roundNum==2)
            GameObject.Find("GameManager").GetComponent<RandomAlgorithms>().SpawnUnit3();
    }
    public void On_UnitWindow()
    {
        Debug.Log(Unit_Window);
        UnitOn = !UnitOn;
        Unit_Window.SetActive(UnitOn);
    }
}
