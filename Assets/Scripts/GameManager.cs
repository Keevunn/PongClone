using System.Collections;
using TMPro;
using UnityEngine;

public enum GameMode
{
    Singleplayer,
    Multiplayer
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private Paddle playerPaddle;
    [SerializeField] private Paddle cpuPaddle;
    
    private int playerScore = 0;
    public TextMeshProUGUI playerScoreText;
    
    private int cpuScore = 0;
    public TextMeshProUGUI cpuScoreText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private IEnumerator ResetRound()
    {
        ball.ResetSelf();
        playerPaddle.ResetSelf();
        cpuPaddle.ResetSelf();

        yield return new WaitForSeconds(1f);
        
        ball.AddStartingForce();
    }
    
    public void UpdatePlayerScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        playerScoreText.text = playerScore.ToString();
        StartCoroutine(ResetRound());
    }
    
    public void UpdateCPUScore(int scoreToAdd)
    {
        cpuScore += scoreToAdd;
        cpuScoreText.text = cpuScore.ToString();
        StartCoroutine(ResetRound());
    }
}
