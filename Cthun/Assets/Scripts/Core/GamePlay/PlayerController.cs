using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : LifeBase
{
    public DeckController deck;
    public HandPlayerBehaviour hand;
    public StoneBoardController board;

    public bool canPlayerControl;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        deck.SetupDeck(this);
        hand.SetPlayer(this);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.C))
            deck.GetCard();
    }

    public override void OnDamage()
    {

    }

    public override void OnDie()
    {

    }
}