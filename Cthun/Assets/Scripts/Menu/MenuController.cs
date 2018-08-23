using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menuGeneral, menuOptions;

    // Use this for initialization
    void Start()
    {
        ActiveMenu(menuGeneral);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HideMenu()
    {
        menuGeneral.SetActive(false);
        menuOptions.SetActive(false);
    }

    public void ActiveMenu(GameObject menu)
    {
        HideMenu();
        menu.SetActive(true);
    }

    public void ExitGame()
    {
        ApplicationController.ExitGame();
    }

    public void Play()
    {
        SceneManager.LoadScene("GamePlay");
    }
}