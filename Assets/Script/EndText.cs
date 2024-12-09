using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndText : MonoBehaviour
{
    private GameObject panel;
    private GameObject Unit_Window;
    private Text text;
    private int num;
    public bool Finish = true;
    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("FinishPanel");
        Unit_Window = GameObject.Find("Unit_Window");
        text = panel.GetComponentInChildren<Text>();
        panel.SetActive(false);
        num = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Finish);
        if (Finish == false)
        {
            switch (num)
            {
                case 1:
                    text.text = "�ƽ��׿� ���ӿ� �й��ϼ̽��ϴ�";
                    break;
                case 2:
                    text.text = "�������� �� �¸��Ͻñ⸦!";
                    break;
                case 3:
                    text.text = "������ Ŭ�������� ���ϼ̽��ϴ�!";
                    break;
            }
        }
        else
        {
            switch (num)
            {
                case 1:
                    text.text = "���� Ŭ��� �����մϴ�~~";
                    break;
                case 2:
                    text.text = "���� Ŭ���� �����ϼ̽��ϴ�!";
                    break;
                case 3:
                    text.text = "Ŭ���� �Ͻôٴ� ���� ����ϼ���!";
                    break;
            }
        }
    }
    public void EndPanelAni()
    {
        panel.SetActive(true);
        Unit_Window.SetActive(false);
    }
    public void ClickEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
