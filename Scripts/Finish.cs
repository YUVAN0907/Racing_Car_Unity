using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Finish : MonoBehaviour
{
    [Header("Finish UI")]
    public GameObject finishUI;
    public GameObject playerUI;
    public GameObject playercar;


    [Header("Win/Lose")]
    public TMP_Text text;
    IEnumerator waitfortheFinishUI()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(25f);
        gameObject.GetComponent<BoxCollider>().enabled = true;

    }

    IEnumerator finishZoneTimer()
    {
        finishUI.SetActive(true);
        playerUI.SetActive(false);
        playercar.SetActive(false);

        yield return new WaitForSeconds(5f);
        Time.timeScale = 0f;
    }
    private void Start()
    {
        StartCoroutine(waitfortheFinishUI());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(finishZoneTimer());
            gameObject.GetComponent<BoxCollider>().enabled = false;
            text.text = "You Win!";
            text.color = Color.red;
        }
        else if(other.gameObject.tag == "OpponentCar")
        {
            StartCoroutine(finishZoneTimer());
            gameObject.GetComponent<BoxCollider>().enabled = false;
            text.text = "You Lose!";
            text.color = Color.red;
        }
    }

}
