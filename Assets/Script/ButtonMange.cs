using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMange : MonoBehaviour
{
    public GameObject TileBtn;
    public GameObject SpawnBtn;
    public GameObject UnitBtn;
    private bool set = true;
    
    // Start is called before the first frame update
    void Start()
    {
        TileBtn = GameObject.Find("TileButton");
        SpawnBtn = GameObject.Find("MonSpawnButton");
        UnitBtn = GameObject.Find("UnitButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        set = !set;
        TileBtn.SetActive(set);
        SpawnBtn.SetActive(set);
        UnitBtn.SetActive(set);
        DownPanel();
        GameObject.Find("StartPos").GetComponent<SpawnEnemy>().On_UnitWindow();
    }
    void DownPanel()
    {
        if(GameObject.Find("Panel").GetComponent<PanelMove>().Getismove())
            GameObject.Find("Panel").GetComponent<PanelMove>().OnClick();
        if(GameObject.Find("UnitPanel").GetComponent<UnitPanel>().GetismoveUnit())
            GameObject.Find("UnitPanel").GetComponent<UnitPanel>().OnClickUnitPanel();
        
    }
}
