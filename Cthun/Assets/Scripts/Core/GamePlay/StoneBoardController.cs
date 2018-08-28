using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBoardController : MonoBehaviour
{
    public StoneBehaviour stonePrefab;
    public List<StoneBehaviour> stones;
    public Transform min, max;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddStone(CardBase card)
    {
        GameObject tempStone = Instantiate(stonePrefab.gameObject) as GameObject;
        CardMinion selectedCard = card.GetComponent<CardMinion>();
        tempStone.GetComponent<StoneBehaviour>().SetStone(selectedCard.attackPower, selectedCard.GetComponent<CardLife>().GetCurrentLife(), selectedCard.imgcard, false);
        stones.Add(tempStone.GetComponent<StoneBehaviour>());
        ReorganizeBoard();        
    }

    public void ReorganizeBoard()
    {
        Vector3 position = transform.position;
        for (int i = 1; i < stones.Count + 1; i++)
        {
            position = CalcDistanceBoardPosition(i, stones.Count + 1);
            if (i - 1 < stones.Count)
            {
                stones[i - 1].SetStartPosition(position);
            }
        }
    }

    private Vector3 CalcDistanceBoardPosition(int indice, int limit)
    {
        float distance = indice / (float)(limit);
        return Vector3.Lerp(min.position, max.position, distance);
    }
}