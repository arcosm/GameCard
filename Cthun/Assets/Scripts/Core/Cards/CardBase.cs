using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBase : MonoBehaviour
{
    public int totalManaRequest;
    public string nameCard, descriptionCard;
    public float dumbDragMovimentation;

    public Texture imgcard;
    public TextMesh textMana, textNameCard, TextDescripitionCard;
    public Renderer rendereImgCard;
    public Vector3 offsetZoomPosition;
    private Camera mainCamera, pespectiveCamera;
    private Vector3 startPosition, zoomPosition, positionToGo;
    private bool onHand, canPlayerControl, isFaceShowing = true, isDragging;

    // Use this for initialization
    protected void Start()
    {
        textMana.text = totalManaRequest.ToString();
        textNameCard.text = nameCard;
        TextDescripitionCard.text = descriptionCard;
        rendereImgCard.material.mainTexture = imgcard;
        mainCamera = Camera.main;
        pespectiveCamera = Camera.allCameras[0];
        GetComponentInChildren<Canvas>().worldCamera = pespectiveCamera;
    }

    // Update is called once per frame
    protected void Update()
    {
        if (transform.position != positionToGo && onHand)
        {
            transform.position = Vector3.Lerp(transform.position, positionToGo, dumbDragMovimentation);
        }
    }

    public void OnClick()
    {

    }

    public void OnMouseHover()
    {
        if (onHand && !isDragging)
        {
            positionToGo = zoomPosition;
        }
    }

    public void OnMouseExit()
    {
        if (onHand && !isDragging)
        {
            positionToGo = startPosition;
        }
    }

    public void OnMouseDrag()
    {
        if (onHand)
        {
            isDragging = true;
            positionToGo = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            positionToGo.y = startPosition.y;
        }
    }

    public void OnDrop()
    {
        if (onHand)
        {
            isDragging = false;
            positionToGo = startPosition;
            ToggleLayer();
        }
    }

    public void OnStartDrop()
    {
        if (onHand)
            ToggleLayer();
    }

    public void FlipCard()
    {
        Vector3 newRotation = transform.eulerAngles;
        isFaceShowing = !isFaceShowing;

        if (isFaceShowing)
        {
            newRotation.z = 0;
        }
        else
        {
            newRotation.z = 180;
        }

        transform.eulerAngles = newRotation;
    }

    public void SetOnHand()
    {
        onHand = true;

    }

    public void SetOwer(bool canPlayerControl)
    {
        this.canPlayerControl = canPlayerControl;

        if (!this.canPlayerControl)
            FlipCard();
    }

    public void SetStartPosition(Vector3 position)
    {
        startPosition = position;
        positionToGo = startPosition;
        zoomPosition = startPosition + offsetZoomPosition;
    }

    public void ToggleLayer()
    {
        int newLayer;
        if (gameObject.layer == LayerMask.NameToLayer("UI"))
        {
            newLayer = LayerMask.NameToLayer("Default");
        }
        else
        {
            newLayer = LayerMask.NameToLayer("UI");
        }

        Transform[] transformsCard = GetComponentsInChildren<Transform>();

        foreach (Transform t in transformsCard)
        {
            t.gameObject.layer = newLayer;
        }
    }
}