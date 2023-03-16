using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class ScreenBounds : MonoBehaviour
{

    public Camera mainCamera;
    BoxCollider2D boxCollider;

    public UnityEvent<Collider2D> ExitTriggerFired;

    [SerializeField] private float teleportOffset = 0.2f;
    //map created of screen size
    void Awake()
    {

        this.mainCamera.transform.localScale = Vector3.one;

        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
        
    }
    void Start()
    {

        transform.position = Vector3.zero;
        UpdateBoundsSize();

    }

    private void UpdateBoundsSize()
    {

        float ySize = mainCamera.orthographicSize * 2;

        Vector2 boxColliderSize = new Vector2(ySize * mainCamera.aspect, ySize);
        boxCollider.size = boxColliderSize;

    }
    //collison with screen
    private void OnTriggerExit2D(Collider2D collision)
    {

        ExitTriggerFired?.Invoke(collision);

    }

    public bool AmIOutOfBounds(Vector3 worldPosition)
    {

        return Mathf.Abs(worldPosition.x) > Mathf.Abs(boxCollider.bounds.min.x) || Mathf.Abs(worldPosition.y) > Mathf.Abs(boxCollider.bounds.min.y);

    }
    //goes to the other side of screen
    public Vector2 CalculateWrappedPosition(Vector2 worldPosition)
    {

        bool xBoundResult = Mathf.Abs(worldPosition.x) > (Mathf.Abs(boxCollider.bounds.min.x));

        Vector2 signWorldPosition = new Vector2(Mathf.Sign(worldPosition.x), Mathf.Sign(worldPosition.y));

        if (xBoundResult)
        {

            return new Vector2(worldPosition.x * -1, worldPosition.y) + new Vector2(teleportOffset * signWorldPosition.x, teleportOffset);

        }
        else
        {

            return worldPosition;

        }

    }

}
