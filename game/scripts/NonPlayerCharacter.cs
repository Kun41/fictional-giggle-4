using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    // Sýnir lengd tíma sem textabox er sýnt
    public float displayTime = 4.0f;
    // Tengir við dialogBox sem sýnir texta
    public GameObject dialogBox;
    // Tíminn sem er síðast sýnt dialogBox
    float timerDisplay;
    
    void Start()
    {
        // Gerir dialogBox óvirkt í upphafi
        dialogBox.SetActive(false);
        // Setur tímann sem síðast var sýnt í -1.0
        timerDisplay = -1.0f;
    }
    
    void Update()
    {
        // Ef tími til að sýna dialogBox er jákvæður
        if (timerDisplay >= 0)
        {
            // Mínusar tímann sem er eftir til að sýna dialogBox
            timerDisplay -= Time.deltaTime;
            // Ef tíminn er orðinn minna en núll
            if (timerDisplay < 0)
            {
                // Gerir dialogBox óvirkt
                dialogBox.SetActive(false);
            }
        }
    }
    
    // Fall sem sýnir dialog
    public void DisplayDialog()
    {
        // Setur tímann sem síðast sýnt dialog í displayTime
        timerDisplay = displayTime;
        // Gerir dialogBox virkt
        dialogBox.SetActive(true);
    }
}
