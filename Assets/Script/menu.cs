using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject infopanel;
    public GameObject levelpanel;
    // Start is called before the first frame update
    void Start()
    {
        infopanel.SetActive(false);
        levelpanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void StartButton()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    // }

    public void InfoButton()
    {
        infopanel.SetActive(true);
    }

    public void LevelPanel()
    {
        levelpanel.SetActive(true);
    }

    public void OpenLevel(int levelid)
    {
        string levelName = "level" + levelid;
        SceneManager.LoadScene(levelName);
    }

    public void BackButton()
    {
        infopanel.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("tombol quit telah ditekan");
    }


    
}
