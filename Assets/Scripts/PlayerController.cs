using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayersController : MonoBehaviour
{
    public float speed;
    public int score;
    public Text scoreText;
    public Text gameOverText;
    public Text countdownText;

    public float Countdown;

    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameOverText.gameObject.SetActive(false);
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Countdown = Mathf.Clamp(Countdown - Time.deltaTime, 0 ,100);
        countdownText.text = "Countdown: " + Mathf.CeilToInt(Countdown);

        if (Countdown <= 0 && !gameOverText.gameObject.activeSelf)
        {
            gameOverText.text = "Game Over! Final Score: " + score;
            gameOverText.gameObject.SetActive(true);
           
        }
        if (score == 17 && !gameOverText.gameObject.activeSelf)
        {
            gameOverText.text = "You Win Score: " + score;
            gameOverText.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        int layerMask = 1 << LayerMask.NameToLayer("Selectable");

        if (Physics.Raycast(mouseRay, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            hit.transform.GetComponent<Rotator>().speed++;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 force = new Vector3(x, 0, y);
        force.Normalize();
        force *= speed;
        force = Quaternion.Euler(0, Camera.main.transform.localEulerAngles.y, 0) * force;
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
