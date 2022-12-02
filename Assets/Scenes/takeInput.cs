using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class takeInput : MonoBehaviour
{

    public TMP_InputField inputField;
    public static string word = "";
    
    public void readInput(string s){
        word = inputField.text;
        SceneManager.LoadScene(2);
    }

}
