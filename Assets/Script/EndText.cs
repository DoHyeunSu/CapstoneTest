using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndText : MonoBehaviour
{
    private GameObject panel;
    private Text text;
    private int num;
    public bool Finish = true;
    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("FinishPanel");
        text = panel.GetComponentInChildren<Text>();
        panel.SetActive(false);
        num = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Finish);
        if (Finish == false)
        {
            switch (num)
            {
                case 1:
                    text.text = "����~ ��� ��� ���� ������ �� �� �˾ƿ�~ �̷� �Ҹ��ϸ� �ȵǰڳ׿�!";
                    break;
                case 2:
                    text.text = "���� �L! ���� ���� �ǰ��� �����ٴ°��� �̷��� ���� ���̱���? ��� ���Ӻ��ϱ� �����׿�";
                    break;
                case 3:
                    text.text = "�װ� �׷��� �ϴ°� �ƴѵ�...��� ��¥ ����ϳ׿�...";
                    break;
            }
        }
        else
        {
            switch (num)
            {
                case 1:
                    text.text = "�������� �� ������ ���� ��� ���ص� �ǰڳ׿�!";
                    break;
                case 2:
                    text.text = "���� �L! ��������� ����� ��� ���ž�?!";
                    break;
                case 3:
                    text.text = "������� ����ϴٴ�..���� ���� �緯������!";
                    break;
            }
        }
    }
    public void EndPanelAni()
    {
        panel.SetActive(true);
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
