using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    Renderer renderer;
    public Camera mainCamera;
    public bool isinCamera;
    public float _distance;
    public float _position;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        renderer = GetComponent<Renderer>();
        MonsterManager.monsters.Add(this);
        isinCamera = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(this.transform.position);
        if (viewPos.x < 0.9 && viewPos.x > 0.1 && viewPos.y < 0.9 && viewPos.y > 0.1)
        {
            isinCamera = true;
        }
        /*if(renderer.isVisible)
        {
            Debug.Log("aaaa");
        }*/
    }

    public void GetDistanceFromCamera()
    {
        float distance = Vector3.Distance(this.transform.position, mainCamera.transform.position);
        _distance = distance;
    }

    public void GetPositionFromCenter()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(this.transform.position);
        float xposition = Mathf.Abs((viewPos.x) - (1 - viewPos.x));
        float yposition = Mathf.Abs((viewPos.y) - (1 - viewPos.y));
        _position = (xposition + yposition) / 2;
    }
}
