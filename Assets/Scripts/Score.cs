// add score manager
using UnityEngine;
using UnityEngine.UI;

// access the Text Mesh Pro namespace
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text teamText;
    public int maxScore = 5;
    public string[] teams = new string[2]{"Red", "Blue"};

    int score;
    string team_name = "red";

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;

        // Afeef: I am attempting to randomly assign the team
        // if(my_team_name = "Red")
        // {
        //     team_name = "Red";
        // }
        // else{
        //     team_name = "Blue";
        // }
        //team_name = teams[random.Next(teams.Length)];
        teamText.text = "Team: " + team_name;
    }

    //we will call this method from our target script
    // whenever the player collides or shoots a target a point will be added
    public void AddPoint()
    {
        score++;

        if (score != maxScore)
            scoreText.text = "Score: " + score;
        else
            scoreText.text = "You won!";
    }
}