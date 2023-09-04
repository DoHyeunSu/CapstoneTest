using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Image startimage;
    public GameObject image;
    public GameObject button;
    public GameObject blackimage;

    float FadeSpeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        startimage.enabled = false;
        image.SetActive(true);
        blackimage.SetActive(true);
        Destroy(button);
        Invoke("SceneChange", 14f);
        StartCoroutine(FadeIn());
    }
    void SceneChange()
    {
        SceneManager.LoadScene("SampleScene");
    }
    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(12f);
        Color color = blackimage.GetComponent<Image>().color;
        while (color.a < 255)
        {
            color.a += Time.deltaTime * FadeSpeed;
            blackimage.GetComponent<Image>().color = color;
            yield return null;
        }
    }
}
