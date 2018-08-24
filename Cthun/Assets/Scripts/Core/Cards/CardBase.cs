using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBase : MonoBehaviour
{
    public int totalManaRequest;
    public string nameCard, descriptionCard;
    public Texture imgcard;

    public TextMesh textMana, textNameCard, TextDescripitionCard;
    public Renderer rendereImgCard;

    // Use this for initialization
    protected void Start()
    {
       
        textMana.text = totalManaRequest.ToString();
        textNameCard.text = nameCard;
        TextDescripitionCard.text = descriptionCard;
        rendereImgCard.material.mainTexture = imgcard;
    }

    // Update is called once per frame
    protected void Update()
    {

    }    
}