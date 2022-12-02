using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Lost : MonoBehaviour
{
    public TextMeshProUGUI output;
    public void Awake(){
        output.text = $"You Lost! The word was {takeInput.word}.";
    }
    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void Quit(){
        Application.Quit();
    }
}
