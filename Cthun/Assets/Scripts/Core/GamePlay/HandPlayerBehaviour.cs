using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPlayerBehaviour : MonoBehaviour
{
    public Transform positionToShowPlayer;
    public Vector3 rangecardPosition;
    [System.NonSerialized]
    public Vector3 PositionNextCard;
    public int maxCardInHand = 10;

    private PlayerController player;
    private Vector3 minPosition, maxPosition;
    private List<CardBase> cards = new List<CardBase>();


    // Use this for initialization
    void Start()
    {
        minPosition = transform.position - rangecardPosition;
        maxPosition = transform.position + rangecardPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPlayer(PlayerController playerToSet)
    {
        player = playerToSet;
    }

    public void ReorganizeCards()
    {
        Vector3 position = transform.position;
        for (int i = 1; i < cards.Count; i++)
        {
            position = CalcDistanceHandPosition(i, cards.Count + 1);
            if (i - 1 < cards.Count)
            {
                cards[i - 1].transform.position = position;
            }
        }
        PositionNextCard = CalcDistanceHandPosition(cards.Count, cards.Count + 1);
    }

    private Vector3 CalcDistanceHandPosition(int indice, int limit)
    {
        float distance = indice / (float)(limit);
        return Vector3.Lerp(minPosition, maxPosition, distance);
    }

    public void AddCard(CardBase card)
    {
        if (cards.Count < 10)
        {
            cards.Add(card);
            ReorganizeCards();
        }
        else
            Destroy(card.gameObject, 1);
    }
}