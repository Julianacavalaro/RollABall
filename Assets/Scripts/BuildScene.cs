using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScene : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(7, 0.5f, 0);
        GameObject obj = Instantiate<GameObject>(prefab, pos, Quaternion.identity, transform);
        obj.name = "PickUp";
    }

}
