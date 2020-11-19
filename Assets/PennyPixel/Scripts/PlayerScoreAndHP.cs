using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreAndHP : MonoBehaviour
{
    public Animator animator;
    public Text scoreText;
    public Text HealthText;
    public int score = 0;
    public int hp = 100;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Gem")
        {
            score++;
        }

        if (c.gameObject.tag == "Projectile")
        {
            hp -= 10;
        }
    }

    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        HealthText.text = "HP: " + hp.ToString();
    }
}
