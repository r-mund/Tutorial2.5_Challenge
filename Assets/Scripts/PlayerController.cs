﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
    private Rigidbody2D rb2d;
    public float speed;
    public float jumpForce;
    public Text countText;
    public Text winText;

    private int count;

    public static int health { get; internal set; }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        {
            if (other.gameObject.CompareTag("PickUp"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();
            }
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count = 4)
        {
            winText.text = "You Win!";
        }
    }


 }
