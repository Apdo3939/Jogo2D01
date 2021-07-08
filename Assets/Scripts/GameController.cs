using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int totalCoins;
    public Text coinsText;

    public Image hpBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins(){
        totalCoins++;
        coinsText.text = totalCoins.ToString();
    }

    public void playerLostHp(float hp){
        hpBar.fillAmount = hp/10;
    }
}
