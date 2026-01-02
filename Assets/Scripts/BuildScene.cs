using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScene : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        float radius = 7;
        int numPickups = 16;
        float angleStep = Mathf.PI * 2f / numPickups;
        float angle = 0;

        for (int i = 0; i < numPickups; i++) { 
            float x = Mathf.Cos(angle) * radius; 
            float y = 0.5f;
            float z = Mathf.Sin(angle) * radius;
     
        Vector3 pos = new Vector3(x, y, z);
        GameObject obj = Instantiate<GameObject>(prefab, pos, Quaternion.identity, transform);
        obj.name = "PickUp" + i;

            angle += angleStep;
        }
    }

}
