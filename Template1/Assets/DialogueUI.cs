using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void setActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void changeText(string dialogue)
    {
        text.text = dialogue;   
    }
}
