using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayersController : MonoBehaviour
{
    public float speed;
    public int score;
    public Text scoreText;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
         //   other.gameObject.SetActive(false); //Deactivate gameObject
         Destroy(other.gameObject); //destroy gameObject
            score++;
            scoreText.text = "Points: " + score;
            Debug.Log("New Score: " + score);
        }
     
    }
}
