using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {
    public GameObject PauseMenuCanvas;
    public bool Paused;
    public string ToScene;
    public static float GlobalTime = 1;
    // Use this for initialization
    void Start() {
        Paused = false;
        PauseMenuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        Pause();
        if (Paused)
        {
            PauseMenuCanvas.SetActive(true);
            Time.timeScale = 0;

        }
        else if (!Paused)
        {
            PauseMenuCanvas.SetActive(false);
            Time.timeScale = PauseMenuScript.GlobalTime;
        }
    }
    public void Pause()
    {
        if (Input.GetKeyDown("escape"))
        {
            Paused = !Paused;
        }

    }
    public void Resume()
    {
        Paused = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(ToScene);
    }
  
}
