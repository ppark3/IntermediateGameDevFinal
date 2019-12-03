using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMover1 : MonoBehaviour
{
    public float scrollSpeed = 0.5f; //speed at which water will move
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(0, offset); //we are setting the offset to be slightly larger than it was before so that it looks like the water is moving
    }
}
