using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtonController : MonoBehaviour
{
    public GameObject BallPrefab;

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SpawnBall()
    {
        Instantiate(BallPrefab, new Vector3(0, 10, 0), Quaternion.identity);
    }
}
