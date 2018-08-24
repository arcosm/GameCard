using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMinion : CardBase
{
    public TextMesh textAttack, textLife; 
    public int attackPower;

    private CardLife cardLife;

    // Use this for initialization
    void Start()
    {
        base.Start();
        cardLife = GetComponent<CardLife>();
        textAttack.text = attackPower.ToString();
        textLife.text = cardLife.GetCurrentLife().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}