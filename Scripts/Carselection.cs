using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Carselection : MonoBehaviour
{
    public Button nextbutton;
    public Button prevbutton;


    public GameObject selectioncanvas;
    public GameObject skip;
    public GameObject play;


    public GameObject cam1;
    public GameObject cam2;

    private int currcar;
    private GameObject[] carList;
    private void choosecar(int ind)
    {

        prevbutton.interactable =(currcar != 0);

        nextbutton.interactable = (currcar != transform.childCount - 1);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == ind);
        }
    }
    private void Start()
    {
        currcar = PlayerPrefs.GetInt("CarSelected");
        carList = new GameObject[transform.childCount];

        for(int i=0; i< transform.childCount; i++)
        {
            carList[i] = transform.GetChild(i).gameObject;
        }
        foreach(GameObject go in carList)
            go.SetActive(false);
        if (carList[currcar])
            carList[currcar].SetActive(true);
    }
    private void Awake()
    {
        selectioncanvas.SetActive(false);
        play.SetActive(false);
        cam2.SetActive(false);
        choosecar(0);
    }
    public void switchcar(int switchcars)
    {
        currcar += switchcars;
        choosecar(currcar);
    }

    public void playGame()
    {
        PlayerPrefs.SetInt("CarSelected",currcar);
        SceneManager.LoadScene("scene_day");
    }

    public void SkipButton()
    {
        selectioncanvas.SetActive(true);
        play.SetActive(true);
        skip.SetActive(false);
        cam1.SetActive(false);
        cam2.SetActive(true);
    }

}
