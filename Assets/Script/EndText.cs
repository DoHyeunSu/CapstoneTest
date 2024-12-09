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
                    text.text = "아쉽네요 게임에 패배하셨습니다";
                    break;
                case 2:
                    text.text = "다음에는 꼭 승리하시기를!";
                    break;
                case 3:
                    text.text = "게임을 클리어하지 못하셨습니다!";
                    break;
            }
        }
        else
        {
            switch (num)
            {
                case 1:
                    text.text = "게임 클리어를 축하합니다~~";
                    break;
                case 2:
                    text.text = "게임 클리어 수고하셨습니다!";
                    break;
                case 3:
                    text.text = "클리어 하시다니 정말 대단하세요!";
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
