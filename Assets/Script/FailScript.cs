using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailScript : MonoBehaviour
{
    private int num = 0;
    private bool pause_b;
    private EndText end;
    public string thisScene;
    public GameObject Canvas_Pause;
    // Start is called before the first frame update
    void Start()
    {
        end = GameObject.Find("Canvas").GetComponent<EndText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pause_b)
        {
            Pause();
        }
            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (collision.transform.gameObject.GetComponent<EnemyStat>().EnemyKey == 103)
            {
                end.Finish = false;
            }
            num++;
            Debug.Log(num);
            if (num >= 12)
            {
                end.Finish = false;
                pause_b = true;
                end.EndPanelAni();
            }
        }
    }
    public void Pause()
    {
        //thisScene = SceneManager.GetActiveScene().name;
        Time.timeScale = 0f;
        //Canvas_Pause.SetActive(true);
    }
}
