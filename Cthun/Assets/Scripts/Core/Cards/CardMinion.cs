using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMinion : CardBase
{
    public TextMesh textAttack, textLife;
    public int attackPower;

    private CardLife cardLife;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        cardLife = GetComponent<CardLife>();
        textAttack.text = attackPower.ToString();
        textLife.text = cardLife.GetCurrentLife().ToString();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}