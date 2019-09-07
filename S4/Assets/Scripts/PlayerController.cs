using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform Bullet;
    public Transform CannonPosition;

    public int Score;

    public Text ScoreText;

    public float timeLeft;

    public Text timerText;

    public Slider Life;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Marcador: 0";
        timeLeft = 60;
        Life.value = 100;
        timerText.text = "Time Left: 60";
        UpdateTimer();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Marcador: " + Score;
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        gameObject.transform.Translate(new Vector3(0.5f*h, 0.5f*v, 0));

        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
    }

    void Shoot() {
        Instantiate(Bullet, CannonPosition.position, Quaternion.identity);
    }

    void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
        }
        UpdateTimer();
    }

    void UpdateTimer()
    {
        timerText.text = "Time Left: " + Mathf.RoundToInt(timeLeft);
    }

    void OnTriggerEnter2D(Collider2D other1)
    {
        Life.value -= 5;
        
    }
}
