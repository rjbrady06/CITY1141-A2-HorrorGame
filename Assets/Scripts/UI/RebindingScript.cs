using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RebindingScript : MonoBehaviour
{
    [SerializeField]
    private KeyCode exampleInput = KeyCode.L;

    [SerializeField]
    TextMeshProUGUI rebindButton;

    private string currentRebindingKey;

    [SerializeField]
    Dictionary<string, KeyCode> keyMaps = new Dictionary<string, KeyCode>(); 

   
    // Start is called before the first frame update
    void Start()
    {
        keyMaps.Add("Example", KeyCode.L);

        keyMaps.TryGetValue("Example", out KeyCode val);
        SetButtonName(val);
    }

    void SetButtonName(KeyCode key)
    {
        rebindButton.text = "Current key: " + key.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        keyMaps.TryGetValue("Example", out KeyCode val);
        if (Input.GetKeyDown(val) && currentRebindingKey.Length == 0)
        {
            Debug.Log("Key Pressed");
        }
    }

    public void StartRebinding(string keyToBind)
    {
        currentRebindingKey = keyToBind;
        rebindButton.text = "Rebinding";
    }

    private void OnGUI()
    {
        if(currentRebindingKey.Length > 0)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keyMaps[currentRebindingKey] = e.keyCode;
                currentRebindingKey = "";
                SetButtonName(e.keyCode);
            }
        }
    }
}
