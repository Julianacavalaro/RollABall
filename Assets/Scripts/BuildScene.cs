using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class BuildScene : MonoBehaviour
{
    public GameObject prefab;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

        List<Vector3> occupiedPositions = new List<Vector3>
        {
            player.transform.position
        };
     //   float radius = 7;
        int numPickups = 16;
    //    float angleStep = Mathf.PI * 2f / numPickups;
      //  float angle = 0;

        for (int i = 0; i < numPickups; i++) {
            //   float x = Mathf.Cos(angle) * radius; 
            //  float y = 0.5f;
            // float z = Mathf.Sin(angle) * radius;

            //float x = Random.Range(-8.0f, 8.0f);
            //  float z = Random.Range(-8.0f, 8.0f);
            float x, z; ;
            float y = 0.5f;

            bool occupied;
            do
            {
                occupied = false;
                x = Random.Range(-8.0f, 8.0f);
                z = Random.Range(-8.0f, 8.0f);
                Vector3 tryPosition = new Vector3(x, y, z);

                foreach (Vector3 otherPosition in occupiedPositions)
                {
                    if(Vector3.Distance(tryPosition, otherPosition) < 2f)
                        occupied = true;
                }
            } while (occupied);




            Vector3 pos = new Vector3(x, y, z);
            occupiedPositions.Add(pos);
            GameObject obj = Instantiate<GameObject>(prefab, pos, Quaternion.identity, transform);
        obj.name = "PickUp" + i;

         //   angle += angleStep;
        }
    }

}
