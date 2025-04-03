using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuInput : MonoBehaviour
{
    [SerializeField]
    private Canvas pauseMenuPrefab;

    private Canvas spawnedPauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(spawnedPauseMenu == null)
            {
               spawnedPauseMenu = HUDManager.AddUIToScreen(pauseMenuPrefab);
            }
            else
            {

               HUDManager.RemoveUIFromScreen(spawnedPauseMenu);

            }

        }
        
    }
}
