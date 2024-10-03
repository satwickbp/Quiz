using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropManager : MonoBehaviour, IDropHandler
{
    public GameManager gameManager;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject drop = eventData.pointerDrag;
        DragManager drag = drop.GetComponent<DragManager>();
        drag.parent = transform;
        drag.gameObject.transform.position = gameObject.transform.position;
        gameManager.User_Answer(drag.name);
    }
}
