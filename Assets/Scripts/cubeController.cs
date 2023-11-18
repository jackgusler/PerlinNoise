using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeController : MonoBehaviour
{
    Material cubeMat = null;
    public Color cubeColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        cubeMat = GetComponent<Renderer>().material;
        cubeMat.color = cubeColor;
    }

    // Update is called once per frame
    void Update()
    {
        float y = transform.localScale.y;
        transform.position = new Vector3(transform.position.x, y / 2f, transform.position.z);
        cubeMat.color = new Color(1f - (y / 10f), 1f - (y / 10f), 1f - (y / 10f), 1);
    }
}
