using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivationScript : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(obj1.activeSelf)
        {
            obj2.gameObject.SetActive(false);
        }
        else
        {
            obj2.gameObject.SetActive(true);
        }
    }
}
