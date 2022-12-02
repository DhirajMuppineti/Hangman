using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Guessing : MonoBehaviour
{
    public Text output;
    public Text triesLeft;
    public TMP_InputField inputField;
    int whitespaces = 0;

    public void Awake(){
        output.text = display(takeInput.word);
        for(int i = 0;i<takeInput.word.Length;i++){
            if(takeInput.word[i] == ' ')
                whitespaces++;
        }
    }

    char[] vowels = {'a','e','i','o','u','A','E','I','O','U'};
    

    bool isVowel(char c){
        for(int i = 0;i<10;i++){
            if(c == vowels[i])
                return true;
        }
        return false;
    }
    
    string display(string str){
        string s = " ";
        for(int i = 0;i<str.Length;i++){
            if(isVowel(str[i]))
                s += "*";
            else if(str[i] == ' ')
                s += " ";
            else
                s += "_";
        }
        return s;
    }

    public int tries = 10;
    int[] guesses = new int[takeInput.word.Length];
    int updates = 0;
    int correctGuesses = 0;
    


    public void guess(){
        string updatedStr = "";
        updates = update(inputField.text,takeInput.word,takeInput.word.Length,guesses,ref updatedStr);
        if(updates == 0){
            tries--;
            triesLeft.text = $"Tries left : {tries}";
        }    
        correctGuesses += updates;
        if(correctGuesses == takeInput.word.Length - whitespaces){
            SceneManager.LoadScene(3);
            return;
        }
        if(tries == 0){
            SceneManager.LoadScene(4);
        }
        output.text = updatedStr;
    }


    int update(string c,string str,int n,int[] guesses,ref string currGuess){
        if(c == str){
            return takeInput.word.Length - whitespaces;
        }
        int updates = 0;
        for(int i = 0;i < n;i++){
            if(str[i] == ' '){
                currGuess += str[i];
            }
            else if(str[i] == c[0]){
                guesses[i] = 1;
                updates++;
                currGuess += str[i];
            }else if(guesses[i] == 1)
                currGuess += str[i];
            else if(isVowel(str[i]))
                currGuess += "*";
            else
                currGuess += "_";    
        }
        return updates;
    }
}
