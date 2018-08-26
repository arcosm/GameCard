using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    private Vector3 initialSize;
    private int totalInitialCards;
    public List<CardBase> initListCards;
    private PlayerController player;

    //animation Variables
    public float timeToShowPlayer, dumbGetCard;
    private float currentTimeToShowPlayer;
    private bool moveToHand;
    private Vector3 positionShowPlayer, positionHand, targetPosition;
    private GameObject tempCard;

    // Use this for initialization
    void Start()
    {
        initialSize = transform.localScale;
        totalInitialCards = initListCards.Count;
        positionShowPlayer = player.hand.positionToShowPlayer.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveToHand && tempCard != null)
        {
            currentTimeToShowPlayer += Time.deltaTime;
            if (currentTimeToShowPlayer > timeToShowPlayer)
            {
                positionHand = player.hand.PositionNextCard;
                targetPosition = positionHand;
            }
            tempCard.transform.position = Vector3.Lerp(tempCard.transform.position, targetPosition, dumbGetCard * Time.deltaTime);
            if (tempCard.transform.position == positionHand && tempCard != null)
            {
                CardBase tempCardComponent = tempCard.GetComponent<CardBase>();
                tempCardComponent.SetOnHand();
                tempCardComponent.SetStartPosition(positionHand);
                tempCard = null;
            }
        }
    }

    public void GetCard()
    {
        if (initListCards.Count > 0)
        {
            int randCardIndex = Random.Range(0, initListCards.Count);
            CardBase selectedCard = initListCards[randCardIndex];
            initListCards.RemoveAt(randCardIndex);

            tempCard = Instantiate(selectedCard.gameObject, transform.position, selectedCard.transform.rotation) as GameObject;
            ResizeDeck();
            moveToHand = true;
            targetPosition = positionShowPlayer;
            currentTimeToShowPlayer = 0;
            player.hand.AddCard(tempCard.GetComponent<CardBase>());
        }
    }

    private void ResizeDeck()
    {
        Vector3 newSize = transform.localScale;
        newSize.y = initListCards.Count * initialSize.y / totalInitialCards;
        transform.localScale = newSize;

        if (initListCards.Count == 0)
            GetComponent<Renderer>().enabled = false;

    }

    public void SetupDeck(PlayerController playerToSet)
    {
        player = playerToSet;
    }
}