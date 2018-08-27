using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBehaviour : MonoBehaviour
{
    public GameObject meshShield;
    public Renderer meshStone;
    public TextMesh textLife, textAttack;

    private bool isTount = false;
    private int life, attack;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetStone(int attack, int life, Texture imgCard, bool isTaunt)
    {
        this.attack = attack;
        this.life = life;
        this.isTount = isTaunt;
        meshStone.materials[1].mainTexture = imgCard;
        ApplyTaunt();
        UpdateValues();
    }

    private void UpdateValues()
    {
        textLife.text = life.ToString();
        textAttack.text = attack.ToString();
    }

    public void ApplyTaunt()
    {
        meshShield.SetActive(isTount);
    }
}