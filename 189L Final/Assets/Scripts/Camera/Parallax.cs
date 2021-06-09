using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial provided by YouTuber Dani, titled "Unity Parallax Tutorial - How to infinite scrolling background".
public class Parallax : MonoBehaviour
{
    private float Length, StartPos;
    public GameObject Camera;
    // Number between 0 and 1 that describes the ratio between how the background should move in respect to the camera. 
    // Objects further away should have a lower parallax ratio.
    public float ParallaxParam;

    // Number of 100ths of a position unit for a corrective param.
    public int CorrectiveParam;
    // Start is called before the first frame update
    void Start()
    {
        // Get starting position and length of the component. 
        this.StartPos = transform.position.x;
        this.Length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (Camera.transform.position.x * (1 - this.ParallaxParam));
        float dist = Camera.transform.position.x * this.ParallaxParam;
        transform.position = new Vector3(StartPos + dist, transform.position.y, transform.position.z);

        // -2 is an error factor used to correct not updating at the right time.
        if (temp > StartPos + Length - CorrectiveParam)
        {
            this.StartPos += Length;
        }
        else if (temp < this.StartPos - Length + CorrectiveParam)
        {
            this.StartPos -= this.Length;
        }


    }
}
