using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    private static int Coin = 0;
    private MersenneAlgorithm.RandomMersenne Mer;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "x" + Coin;
    }
    public void AddCoin()
    {
        int seed = (int)System.DateTime.Now.Ticks;
        Mer = new MersenneAlgorithm.RandomMersenne((uint)seed);
        int rand= Mer.IRandom(0, 10);
        if (rand < 7)
            Coin += Mer.IRandom(0, 20);
        else if (rand < 9)
            Coin += Mer.IRandom(20, 40);
        else if (rand < 10)
            Coin += 100;
    }
    public void SubCoin(int num)
    {
        Coin -= num;
    }
    public int ReturnCoin()
    {
        return Coin;
    }
}
