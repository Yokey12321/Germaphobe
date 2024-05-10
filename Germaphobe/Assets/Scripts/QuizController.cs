using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizController : Controller
{

    private int choice = 0;
    private string[] questions = @"Why is the stomach important to nosy white blood cells like you Wyatt?, Stomach acid tastes really good, !It breaks down nutrients that make Wyatt stronger, The Host uses the stomach to provide Wyatt with oxygen, It provides a place for Wyatt to sleep
What is IgG?, !The most common antibody found in white blood cells like Wyatt, A reinforcing artificial material that makes Wyatt stronger, The material that helps Redd carry oxygen, The reason why Plato Leto is such a nerd
What are arteries used for?, Transporting blood from the heart to the body, Feeding the white blood cells food, Allowing cells to leave on vacation, !Transporting blood from the body to the heart
What do platelettes like Plato Leto do?, Yap too much, Kill other white blood cells, !Help with blood clotting, Make germs stronger
Last question, this one's tricky: What is Redd's blood type?, B Positive, !O Negative, A Postive, O Postive".Split('\n');
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
    private bool jeremydying = false;
    public GameObject jeremy;

    // Start is called before the first frame update
    new void Start()
    {
        StartCoroutine("StartSceneFlow");
    }

    IEnumerator StartSceneFlow()
    {
        text.gameObject.transform.parent.gameObject.SetActive(true);
        yield return runDialogue(@"W: Finally, we're out of that sticky situation.
P: And, we're in a new one. This is the heart where Jeremy Germ resides. The root of it all!
R: I'm scared! What if he hurts us?
W: Don't worry Redd, we can defeat him. Just remember what we've learned and all will be okay. Let's continue forward.".Split('\n'));
        
        text.gameObject.transform.parent.gameObject.SetActive(false);
        cameraMoving = true;
        wyattMoving = true;
        while (cameraMoving || wyattMoving || Time.timeScale == 0) {
            yield return null;
        }
        yield return new WaitForSeconds(1);
        text.gameObject.transform.parent.gameObject.SetActive(true);
        yield return runDialogue(@"J: So there you all are. Took long enough.
W: Jeremy Germ.
R: Eek!
W: You are a plague on mankind.
J: Let's save the insults for later, Wyatt. I'm sure you have a reason to be here?
W: I'm here to end you.
J: Hah, with your ragtag group of cells? Don't kid me.
W: We've already blasted through your cronies.
J: Woah, really? I like your courage. Tell you what, I'll leave if you answer all the answers on this quiz. However, if you  After all, knowledge is power.
W: This should be easy. Let's get this!
P: A quiz? I love quizzes!".Split('\n'));
        text.gameObject.transform.parent.gameObject.SetActive(false);
        canvas.SetActive(true);
        initQuestion();
    }

    IEnumerator Win() {
        yield return runDialogue(@"J: You got me. Quite impressive. I'm a man of my word, so I'll be on the way out.".Split('\n'));
        jeremydying = true;
        while (jeremydying || Time.timeScale == 0) {
            yield return null;
        }
        yield return runDialogue(@"R: We did it! We did it!
W: That we did. Good work team.
P: That's going in the history books!".Split('\n'));
        winScreen.SetActive(true);
        wyatt.SetActive(false);
        canvas.SetActive(false);
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
        if (jeremydying) {
            Color c = jeremy.GetComponent<SpriteRenderer>().color;
            c.a = Mathf.Clamp(c.a - Time.deltaTime/3f, 0, 1);
            jeremy.GetComponent<SpriteRenderer>().color = c;
            if (c.a == 0) {
                jeremydying = false;
            }
        }
    }

    void initQuestion() {
        Debug.Log(questions);
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
            if (questionNumber < questions.Length) {
                initQuestion();
            } else {
                //Win
                canvas.SetActive(false);
                StartCoroutine("Win");
                
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
