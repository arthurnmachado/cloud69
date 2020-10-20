using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MovimentarUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoverUI()
    {
        this.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }
}
