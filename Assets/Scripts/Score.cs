// add score manager
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

// access the Text Mesh Pro namespace
using TMPro;

public class Score : MonoBehaviour
{
    //public TMP_Text teamText;
    public TMP_Text scoreText1;
    public TMP_Text scoreText2;
    int maxScore = 10;
    public string[] teams = new string[2]{"RED", "BLUE"};

    int score1;
    int score2;
    string team_name = "red";

    // Start is called before the first frame update
    void Start()
    {
        score1 = 0;
        score2 = 0;

        //teamText.text = "";
        scoreText1.text  = "Red Team Score: " + score1;
        scoreText2.text = "Blue Team Score: " + score2;
        Debug.Log("Red Team Score: " + score1);
        Debug.Log("Blue Team Score: " + score2);

    }

    public void setTeam(int i)
    {
        //teamText.text = "You are " + teams[i-1] + " team";
        Debug.Log("You are " + teams[i - 1] + " team");

    }

    //we will call this method from our target script
    // whenever the player collides or shoots a target a point will be added
    public void AddPointRed()
    {
        score1++;

        if (score1 != maxScore)
            scoreText1.text = "Red Team Score: " + score1;
        else
            scoreText1.text = "Red Team WINS!";

        Debug.Log("Red Team Score: " + score1);


    }

    public void AddPointBlue()
    {
        score2++;

        if (score2 != maxScore)
            scoreText2.text = "Blue Team Score: " + score2;
        else
            scoreText2.text = "Blue Team WINS!";

        Debug.Log("Blue Team Score: " + score2);

    }
}