using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    public Text winLoseText;
    public Image winLoseBG;
    public Text healthText;
    public Text scoreText;
    public float speed = 30f;
    public Rigidbody rb;
    private int score = 0;
    public int health = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate(){
        if (Input.GetKey("d"))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            winLoseText.text = "Game Over!";
            winLoseText.color = Color.white;
            winLoseBG.color = Color.red;
            winLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            score += 1;
            SetScoreText();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Trap")
        {
            health -= 1;
            SetHealthText();
        }
        if (other.gameObject.tag == "Goal")
        {
            winLoseText.color = Color.black;
            winLoseText.text = "You Win!";
            winLoseBG.color = Color.green;
            winLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
        }
    }
    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }
    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(0);
    }
}
