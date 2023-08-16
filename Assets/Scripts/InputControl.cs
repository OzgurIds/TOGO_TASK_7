using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


#pragma warning disable IDE0051, IDE0060
public class InputController : MonoBehaviour, IPointerDownHandler, IDragHandler
{

    public GameObject Player;
    public GameManager manager;

    public void OnPointerDown(PointerEventData eventData)
    {
        manager.isStarted = true;
        Player.GetComponent<PlayerCont>().StartAll();
    }


    public void OnDrag(PointerEventData eventData)
    {
        Player.GetComponent<PlayerCont>().LeftRight(eventData.delta.x);
    }
}
