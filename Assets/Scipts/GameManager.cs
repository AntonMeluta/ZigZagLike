using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Time.timeScale = (Time.timeScale == 1) ? 0 : 1;

        if (Input.GetKeyDown(KeyCode.R))
            EventsBroker.OnRestartGame();
    }

}
