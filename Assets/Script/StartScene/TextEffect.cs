using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffect : MonoBehaviour
{
    public string FullText;
    public int Time;
    public int num;
    private string SubText;
    // Start is called before the first frame update
    void Start()
    {
        switch (num) {
            case 1:
                FullText = FullText + PlayerPrefs.GetInt("Unit", 0) + "입니다";
                break;
            case 2:
                FullText = FullText + PlayerPrefs.GetInt("Enemy", 0) + "입니다";
                break;
            case 3:
                FullText = FullText + PlayerPrefs.GetInt("Level", 0) + "입니다";
                break;
            default:
                break;
        }
        Invoke("Delay", Time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Delay()
    {
        StartCoroutine(getText(FullText));
    }
    IEnumerator getText(string _fulltext)
    {
        for (int i = 0; i < _fulltext.Length; i++)
        {
            string currentText = _fulltext.Substring(0, i + 1);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(0.2f);
        }
        this.GetComponent<Text>().text = _fulltext;
        //Debug.Log(_fulltext.Length);
    }
}
