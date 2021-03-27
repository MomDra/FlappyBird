using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScrollingObject : MonoBehaviour
{
    Rigidbody2D myRigid;
    void Awake()
    {
        myRigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        myRigid.velocity = new Vector2(MyGameController.instance.scrollSpeed, 0);
    }

    void Update()
    {
        if (MyGameController.instance.gameOver)
        {
            myRigid.velocity = Vector2.zero;
        }
    }
}
