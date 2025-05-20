using System.Collections;
using UnityEngine;
using TMPro;  // Import TextMeshPro namespace

public class Timer : MonoBehaviour
{
    [Header("Timer")]
    public float countDownTimer = 5f;

    public PlayerCarController playercarController;
    public PlayerCarController playercarController1;
    public PlayerCarController playercarController2;
    public OponentCar oponentCar;
    public OponentCar oponentCar1;
    public OponentCar oponentCar2;
    public OponentCar oponentCar3;
    public OponentCar oponentCar4;

    public TMP_Text countdownText;  // Use TMP_Text for TextMeshPro

    void Start()
    {
        StopRace(); // Ensure cars are stopped at the beginning
        StartCoroutine(TimerCount());
    }

    IEnumerator TimerCount()
    {
        while (countDownTimer > 0.1f)  // Prevent floating-point precision errors
        {
            countdownText.text = Mathf.Ceil(countDownTimer).ToString();
            yield return new WaitForSeconds(1f);
            countDownTimer = Mathf.Max(0, countDownTimer - 1);
        }

        countdownText.text = "Go!";
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);

        StartRace(); // Start moving cars after countdown ends
    }

    void StopRace()
    {
        playercarController.accelerateforce = 0f;
        playercarController1.accelerateforce = 0f;
        playercarController2.accelerateforce = 0f;
        oponentCar.movingSpeed = 0f;
        oponentCar1.movingSpeed = 0f;
        oponentCar2.movingSpeed = 0f;
        oponentCar3.movingSpeed = 0f;
        oponentCar4.movingSpeed = 0f;
    }

    void StartRace()
    {
        playercarController.accelerateforce = 300f;
        playercarController1.accelerateforce = 300f;
        playercarController2.accelerateforce = 300f;
        oponentCar.movingSpeed = 12f;
        oponentCar1.movingSpeed = 13f;
        oponentCar2.movingSpeed = 14f;
        oponentCar3.movingSpeed = 8f;
        oponentCar4.movingSpeed = 10f;
    }
}
