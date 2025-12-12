using UnityEditor;
using UnityEngine;

public class PlayersController : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 force = new Vector3(x, 0, y);
        force.Normalize();
        force *= speed;
        rb.AddForce(force);
    }
}
