using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_PauseMenu : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private GameObject par_GamePauseUI;
    [SerializeField] private Button btn_SelectEnglishKeyboard;
    [SerializeField] private Button btn_SelectFrenchKeyboard;

    //public but hidden variables
    [HideInInspector] public KeyboardLayout keyboardLayout;
    [HideInInspector] public enum KeyboardLayout
    {
        english,
        french
    }

    //private variables
    private bool isGamePaused;

    private void Awake()
    {
        SelectEnglishKeyboard();
        UnpauseGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                PauseGame();
            }
            else if (isGamePaused)
            {
                UnpauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        par_GamePauseUI.SetActive(true);
        // <<<ADD ANY PAUSABLE VARIABLES BELOW HERE>>>

        // <<<ADD ANY PAUSABLE VARIABLES ABOVE HERE>>>
        isGamePaused = true;
        Debug.Log("Game is paused!");
    }
    public void UnpauseGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        par_GamePauseUI.SetActive(false);
        // <<<ADD ANY UNPAUSABLE VARIABLES BELOW HERE>>>

        // <<<ADD ANY UNPAUSABLE VARIABLES ABOVE HERE>>>
        isGamePaused = false;
        Debug.Log("Game is no longer paused!");
    }

    public void SelectEnglishKeyboard()
    {
        btn_SelectEnglishKeyboard.interactable = false;
        btn_SelectFrenchKeyboard.interactable = true;
        keyboardLayout = KeyboardLayout.english;
        Debug.Log("Changed keyboard inputs to english.");
    }
    public void SelectFrenchKeyboard()
    {
        btn_SelectEnglishKeyboard.interactable = true;
        btn_SelectFrenchKeyboard.interactable = false;
        keyboardLayout = KeyboardLayout.french;
        Debug.Log("Changed keyboard inputs to french.");
    }

    public void Quit()
    {
        Application.Quit();
    }
}