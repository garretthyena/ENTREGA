using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

    public GameObject gameManager;
    public GameObject gameOverBox;

    private bool isTouch;

    private void Start()
    {
        isTouch = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bomb" && isTouch == false)
        {
            isTouch = true;
            gameManager.GetComponent<SoundManager>().PlayBombFX();
            gameManager.GetComponent<GameManager>().LoseLive();
            StartCoroutine("WaitState");
        }
        if (collision.tag == "Stars" && isTouch == false)
        {
            isTouch = true;
            gameManager.GetComponent<GameManager>().AddPoint();
            gameManager.GetComponent<GameManager>().ShowScore();
            gameManager.GetComponent<SoundManager>().PlayStarFX();
            StartCoroutine("WaitState");
        }
        if (collision.tag == "Death")
        {
            gameOverBox.SetActive(true);
        }
    
    }

    private IEnumerator WaitState()
    {
        yield return new WaitForSeconds(0.4f);
        isTouch = false;
    }

}
