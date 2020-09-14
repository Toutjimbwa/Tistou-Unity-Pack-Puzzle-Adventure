using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JTInventoryControl : MonoBehaviour
{

    public JTHand Left;
    public JTHand Right;

    //Rotation
    public float rotSpeed = 250;
    public float damping = 10;
    private Quaternion desiredRotQ;

    //Combine
    public JTCombine combine;
    public JTPickUpAbility pickUpAbility;
    private void OnEnable()
    {
        desiredRotQ = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            RotateClockwise();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            RotateAntiClockwise();
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            Switch();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Combine();
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, 0.1f);
    }

    void RotateClockwise()
    {
        desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRotQ.eulerAngles.z + 90f);
    }

    void RotateAntiClockwise()
    {
        desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRotQ.eulerAngles.z - 90f);
    }

    void Combine()
    {
        var LItem = Left._slot.GetComponentInChildren<JTItem>();
        var RItem = Right.GetItem();
        if (LItem && RItem)
        {
            var newItem = combine.Combine(LItem, RItem);
            if (newItem)
            {
                Left.Drop(LItem);
                Destroy(LItem.gameObject);
                Right.Drop(RItem);
                Destroy(RItem.gameObject);

                var GO = Instantiate(newItem);
                pickUpAbility.PickUp(GO.GetComponent<JTItem>());
            }
        }
    }

    void Switch()
    {
        var LItem = Left._slot.GetComponentInChildren<JTItem>();
        var RItem = Right.GetItem();

        //Move Left Item
        if (LItem)
        {
            Right.PickUp(LItem);
        }

        //Move Right Item
        if (RItem)
        {
            Right.Drop(RItem);
            RItem.transform.parent = Left._slot.transform;
            RItem.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
