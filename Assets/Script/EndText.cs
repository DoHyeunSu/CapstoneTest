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
                    text.text = "너 게임 ㅈㄴ 못한다 ㅋㅋㅋ";
                    break;
                case 2:
                    text.text = "너 롤도 브론즈지?";
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
                    text.text = "클리어 축하하고 이제 집이나 가";
                    break;
                case 3:
                    text.text = "이걸 클리어까지 하고 가는거야...? 너도 참...";
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
