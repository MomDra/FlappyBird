using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyColumn : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ji");
        if(collision.GetComponent<MyBird>() != null)
        {
            MyGameController.instance.BirdScored();
        }
    }
}
