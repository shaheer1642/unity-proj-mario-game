using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterCollision : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public TMP_Text scoreRef;
    public TMP_Text livesRef;

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic) return;

        Debug.Log("OnControllerColliderHit" + body.gameObject.name);
        
        if (body.gameObject.name == "GoldCoin") {
            score += 10;
            scoreRef.text = "Score: " + score;
            Destroy(body.gameObject);
        }

        if (body.gameObject.name == "SilverCoin") {
            score += 5;
            scoreRef.text = "Score: " + score;
            Destroy(body.gameObject);
        }

        if (body.gameObject.name == "EnemyObject") {
            lives -= 1;
            livesRef.text = "Lives: " + lives;
            Destroy(body.gameObject);
            if (lives == 0) {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
