using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



public class GameManager : MonoBehaviour
{
    [Header("Menu Scene Settings")]
    public string menu_scene;
    public string first_quiz_scene;
    public string result_scene;


    [Header("Quiz Scene Settings")]

    public string correctAnswer;
    public int marks;
    public string next_scene;

    public AudioClip correctSound;
    public AudioClip wrongSound;
    public AudioSource soundManager;

    [Header("Result Scene Settings")]
    public GameObject[] stars;
    public TMP_Text text_score;
    public int stars_1_limit;
    public int stars_2_limit;
    public int stars_3_limit;

    [Header("For Debugging Only, Ignore Me!")]
    public int score;


    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score");

        if (SceneManager.GetActiveScene().name == menu_scene)
        {
            PlayerPrefs.SetString("first_quiz_scene", first_quiz_scene);
            PlayerPrefs.SetString("result_scene", result_scene);

        }
        else if (SceneManager.GetActiveScene().name == PlayerPrefs.GetString("result_scene"))
        {
            Result();
        }
        else if (SceneManager.GetActiveScene().name == PlayerPrefs.GetString("first_quiz_scene"))
        {
            PlayerPrefs.SetInt("score", 0);
        }


    }

    public void User_Answer(string jawaban)
    {
        if (jawaban == correctAnswer)
        {
            CorrectAnswer();
        }
        else
        {
            WrongAnswer();
        }

       StartCoroutine(NextScenes());
    }

    public void CorrectAnswer()
    {
        soundManager.clip = correctSound;
        soundManager.Play();

        score = PlayerPrefs.GetInt("score");
        score = score + marks;
        PlayerPrefs.SetInt("score",score);
    }

    void WrongAnswer()
    {
        soundManager.clip = wrongSound;
        soundManager.Play();
    }

    IEnumerator NextScenes()
    {
        yield return new WaitForSeconds(1f);
        MoveScenes(next_scene);
    }

    // CONSTANT

    void Result()
    {
        if (score <= stars_1_limit)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
        }
        else if (score <= stars_2_limit)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(false);
        }
        else if (score <= stars_3_limit)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }

        text_score.text = "score: " + score;
    }

    public void MoveScenes(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public void Open_Popup(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void Close_Popup(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void Exit_Applications()
    {
        Application.Quit();
    }

}
