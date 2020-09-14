using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInventory : MonoBehaviour
{

    public TestHand Left;
    public TestHand Right;

    //Rotation
    public float rotSpeed = 250;
    public float damping = 10;
    private Quaternion desiredRotQ;

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
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
    }

    void RotateClockwise()
    {
        desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90f);
    }

    void RotateAntiClockwise()
    {
        desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 90f);
    }

    void Combine()
    {
        var LItem = Left.GetItem();
        var RItem = Right.GetItem();
        if(LItem && RItem)
        {
            Left.ClearHand();
            Right.ClearHand();

            LItem.transform.parent = RItem.transform;
            LItem.transform.localPosition = new Vector3(0, 0, 0);
            Destroy(LItem);
        }
    }

    void Switch()
    {

        //Empty hands
        var LItem = Left.GetItem();
        Left.ClearHand();
        var RItem = Right.GetItem();
        Right.ClearHand();

        //Move Left Item
        if (LItem)
        {
            LItem.transform.parent = Right.transform;
            LItem.transform.localPosition = new Vector3(0, 0, -0.5f);
        }

        //Move Right Item
        if (RItem)
        {
            RItem.transform.parent = transform;
            RItem.transform.position = new Vector3(Left.transform.position.x , Left.transform.position.y, Left.transform.position.z - 0.5f);
        }
    }
}
