using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobberBehaviour : BTAgent
{
    public GameObject circle;
    public GameObject square;
    public GameObject triangle;
    public GameObject capsule;
    public GameObject start;


    GameObject pickup;

    [Range(0, 1000)]
    public int money = 800;

    Leaf goToCircle;
    Leaf goToSquare;
    
    // tham chiếu đến Sprite nhân vật
    public GameObject robber;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        var steal = new Sequence("Ăn trộm gì đó");
        // đi đến 1 trong 2 vật phẩm, cái nào được thì bỏ qua cái kia
        goToCircle = new Leaf("Go To Circle", GoToCircle, 10);
        goToSquare = new Leaf("Go To Square", GoToSquare, 2);
        var pickOnePItem = new PSelector("Lựa chọn vật phẩm");
        pickOnePItem.AddChild(goToCircle);
        pickOnePItem.AddChild(goToSquare);
        
        var goToTriangle = new Leaf("Go To Triangle", GoToTriangle, 1);
        var goToCapsule = new Leaf("Go To Capsule", GoToCapsule, 2);
        var pickOneItem = new Selector("Lấy vật phẩm");
        pickOneItem.AddChild(goToTriangle);
        pickOneItem.AddChild(goToCapsule);
        
        var goToStart = new Leaf("Go To Start", GoToStart);
       
        var hasGotMoney = new Leaf("Has Got Money", HasMoney);
        var invertMoney = new Inverter("Invert Money");
        invertMoney.AddChild(hasGotMoney);
       
        steal.AddChild(invertMoney);
        steal.AddChild(pickOnePItem);
        steal.AddChild(pickOneItem);
        steal.AddChild(goToStart);
        tree.AddChild(steal);
    }

    public Node.Status HasMoney()
    {
        if(money < 500)
            return Node.Status.FAILURE;
        return Node.Status.SUCCESS;
    }

    public Node.Status GoToTriangle()
    {
        if (!triangle.activeSelf) return Node.Status.FAILURE;
        Node.Status s = GoToLocation(triangle.transform.position);
        if (s == Node.Status.SUCCESS)
        {
            triangle.transform.parent = this.gameObject.transform;
            pickup = triangle;
        }
        return s;
    }

    public Node.Status GoToCapsule()
    {
        if (!capsule.activeSelf) return Node.Status.FAILURE;
        Node.Status s = GoToLocation(capsule.transform.position);
        if (s == Node.Status.SUCCESS)
        {
            capsule.transform.parent = this.gameObject.transform;
            pickup = capsule;
        }
        return s;
    }
    
    public Node.Status GoToCircle()
    {
        Node.Status s = GoToOneItem(circle);
        if (s == Node.Status.FAILURE)
            goToCircle.sortOrder = 10;
        else
            goToSquare.sortOrder = 1;
        return s;
    }

    public Node.Status GoToSquare()
    {
        Node.Status s = GoToOneItem(square);
        if (s == Node.Status.FAILURE)
            goToSquare.sortOrder = 10;
        else
            goToSquare.sortOrder = 1;
        return s;
    }

    public Node.Status GoToStart()
    {
        Node.Status s = GoToLocation(start.transform.position);
        if (s == Node.Status.SUCCESS)
        {
            money += 300;
            pickup.SetActive(false);
        }
        return s;
    }

    public Node.Status GoToOneItem(GameObject item)
    {
        Node.Status s = GoToLocation(item.transform.position);
        if (s == Node.Status.SUCCESS)
        {
            if (!item.GetComponent<Lock>().isLocked)
            {
                return Node.Status.SUCCESS;
            }
            return Node.Status.FAILURE;
        }
        else
            return s;
    }

}
