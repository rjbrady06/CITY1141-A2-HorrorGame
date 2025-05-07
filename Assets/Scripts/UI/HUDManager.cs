using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    private Canvas mainMenu;
    
    private void Start()
    {
        AddUIToScreen(mainMenu);
    }
    public static Canvas AddUIToScreen(Canvas Menu)
    {
        if (Menu != null)
        { 
           return Instantiate(Menu);
        }
        else
        {
            Debug.LogError("No valid UI prefab to spawn");
        }
        return null;
    }

    public static void RemoveUIFromScreen(Canvas ui)
    {
        if (ui != null)
        {
            Destroy(ui.gameObject);
        }
        else
        {
            Debug.LogWarning("Destroying invalid UI");
        }
    }
}
