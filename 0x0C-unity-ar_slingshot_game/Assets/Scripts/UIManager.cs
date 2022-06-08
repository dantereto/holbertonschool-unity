using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public SlingshotManager slingshotManager;
    public EnemyManager enemyManager;
    public Text promptText;
    public Image promptPanel;
    public GameObject hud;
    public Text pointsText;
    public List<Image> ammoImages;
    public GameObject startButton;
    public GameObject gameOverPanel;
    public GameObject leaderboardPanel;
    public List<Text> scoreTexts;
    private List<int> scores = new List<int>();
    private bool planeDetected = false;
    private int points = 0;
    private ARPlane plane;

    void Update()
    {
        
    }

    public void Addplane(ARPlanesChangedEventArgs args)
    {
        if (planeDetected)
            return;

        if (args.added.Count == 0)
            return;

        planeDetected = true;

        promptText.text = "choose the plan you prefer.";
    }

    public void PlaneSelected(ARPlane plane)
    {
        promptPanel.enabled = false;
        startButton.SetActive(true);
        this.plane = plane;
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        hud.SetActive(true);

        enemyManager.SetupPlane(plane);
        slingshotManager.LoadAmmo();
    }

    IEnumerator CloseSelectionDisplay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Debug.Log("Calling load ammo");

        promptPanel.color = new Color32(255, 255, 255, 60);
        promptText.text = "Pull back on the ball to launch at the enemies!";
    }

    public void UseAmmo(int ammoLeft)
    {
        ammoImages[ammoLeft - 1].color = new Color32(255, 255, 255, 85);
        promptPanel.gameObject.SetActive(false);
    }

    public void ScorePoints(int points)
    {
        this.points += points;

        pointsText.text = this.points.ToString();
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void RestartApp()
    {
        SceneManager.LoadScene("ARSlingshotGame");
    }

    public void Replay()
    {
        slingshotManager.Replay();
        enemyManager.Replay();

        gameOverPanel.SetActive(false);

        points = 0;
        pointsText.text = "0";

        foreach (Image ammoImage in ammoImages)
        {
            ammoImage.color = new Color(224, 224, 224, 224);
        }

        StartGame();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            if (points >= scores[i])
            {
                scores.Insert(i, points);
                break;
            }
        }
    }
}
