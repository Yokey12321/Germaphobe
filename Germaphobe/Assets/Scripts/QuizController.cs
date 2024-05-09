using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizController : Controller
{

    private int choice = 0;
    public string[] questions = "test, test, !test, test, test".Split('\n');
    public TMP_Text[] answerTexts;
    public TMP_Text questionText;
    private int questionNumber = 0;
    private int correctAnswer = 0;
    public GameObject loseScreen;
    public GameObject winScreen;
    public GameObject wyatt;
    public GameObject cameraFollow;
    private bool cameraMoving = false;
    private bool wyattMoving = false;
    public GameObject canvas;

    // Start is called before the first frame update
    new void Start()
    {
        StartCoroutine("StartSceneFlow");
    }

    IEnumerator StartSceneFlow()
    {
        cameraMoving = true;
        wyattMoving = true;
        while (cameraMoving || wyattMoving) {
            yield return null;
        }
        canvas.SetActive(true);
        initQuestion();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (cameraMoving)
        {

            Vector3 newPos = Vector3.MoveTowards(cameraFollow.transform.position, new Vector3(19.2f, 0, 0), 7 * Time.deltaTime);
            if (newPos == cameraFollow.transform.position)
            {
                cameraMoving = false;
            }
            cameraFollow.transform.position = newPos;
        }
        if (wyattMoving)
        {
            Vector3 newPos = Vector3.MoveTowards(wyatt.transform.position, new Vector3(14.1f, 0, 0), 5 * Time.deltaTime);
            if (newPos == wyatt.transform.position)
            {
                wyattMoving = false;
            }
            wyatt.transform.position = newPos;
        }
    }

    void initQuestion() {
        string question = questions[questionNumber];
        string[] questionData = question.Split(", ");
        questionText.text = questionData[0];
        for (int i = 1; i <= 4; i++) {
            answerTexts[i - 1].text = questionData[i].Replace("!", string.Empty);
            if (questionData[i].StartsWith("!")){
                correctAnswer = i;
            }
        }
    }

    private void CheckAnswer() {
        if (choice == correctAnswer) {
            choice = 0;
            questionNumber++;
            if (questionNumber < 5) {
                initQuestion();
            } else {
                //Win
                winScreen.SetActive(true);
            wyatt.SetActive(false);
            canvas.SetActive(false);
            }
        } else {
            //loss WIP
            loseScreen.SetActive(true);
            wyatt.SetActive(false);
            canvas.SetActive(false);
        }
    }

    public void Button1() {
        choice = 1;
        CheckAnswer();
    }
    
    public void Button2() {
        choice = 2;
        CheckAnswer();
    }

    public void Button3() {
        choice = 3;
        CheckAnswer();
    }

    public void Button4(){
        choice = 4;
        CheckAnswer();
    }

    public void Restart() {
        Debug.Log("hi");
        SceneManager.LoadScene("End");
    }
}
