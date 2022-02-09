using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class DialogueController : MonoBehaviour
{
    private XmlDocument xmlDoc;
    [SerializeField] private TextAsset textAsset;

    // Start is called before the first frame update
    void Start()
    {
        xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
    }

    public string getNPC()
    {
        XmlNode item = xmlDoc.SelectSingleNode("NPC/info/name");
        if (item == null)
        {
            Debug.LogError("ERROR: Couldn't find name from '" + textAsset.name + "'");
        }
        return item.InnerText;
    }

    public string getDialogue(int index)
    {
        XmlNode item = xmlDoc.SelectSingleNode("NPC/dialogue/item[@id='" + index + "']/text");
        if (item == null)
        {
            Debug.LogError("ERROR: Couldn't find dialogue from '" + textAsset.name + "' with an id of '" + index + "'.");
        }
        return item.InnerText;
    }
}
