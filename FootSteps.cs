using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour {

    float dirX;
    [SerializeField]
    float moveSpeed = 5f;
    Ridgidbody2D rb;
    AudioSource audioSrc;
    bool isMoving = false;


    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update() {
        drix = Input.GetAxis("Horizontal") * moveSpeed;

        if (rb.velocity.x != 0)
            isMoving = true;
        else
            isMoving = false
                if (isMoving)
        {
            if (!audioScr.isPlaying)
                audioScr.Play();
        }
        else
            audioSrc.Stop();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

}
