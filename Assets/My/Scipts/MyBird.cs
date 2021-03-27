using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBird : MonoBehaviour
{
    [SerializeField]
    float upForce = 200f;

    bool isDead = false;
    Rigidbody2D myRigid;
    Animator myAmimator;

    void Awake()
    {
        myRigid = GetComponent<Rigidbody2D>();
        myAmimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                myRigid.velocity = Vector2.zero;
                myRigid.AddForce(new Vector2(0, upForce));
                myAmimator.SetTrigger("Flap");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        myAmimator.SetTrigger("Die");
        MyGameController.instance.BirdDie();
    }
}
