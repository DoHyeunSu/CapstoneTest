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
                    text.text = "허접~ 당신 어디서 가서 게임좀 할 줄 알아요~ 이런 소리하면 안되겠네요!";
                    break;
                case 2:
                    text.text = "오우 쒵! 보는 눈에 건강이 안좋다는것은 이럴때 쓰는 말이군요? 당신 게임보니까 나오네요";
                    break;
                case 3:
                    text.text = "그거 그렇게 하는거 아닌데...당신 진짜 답답하네요...";
                    break;
            }
        }
        else
        {
            switch (num)
            {
                case 1:
                    text.text = "이정도면 나 게임좀 잘해 라고 말해도 되겠네요!";
                    break;
                case 2:
                    text.text = "오우 쒵! 깨지말라고 만든걸 어떻게 깬거야?!";
                    break;
                case 3:
                    text.text = "운빨게임을 통과하다니..오늘 복권 사러가세요!";
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
