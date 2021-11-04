using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//per lavorare con diverse scene nello stesso momento
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenu : MonoBehaviour
{

    public InputField nameInputField;
    
    public void StartNew()
    {
        NameManager.Instance.SetName(nameInputField.text);
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
