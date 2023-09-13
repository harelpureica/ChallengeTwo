using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class Loger 
{
    //the ui text element to display the log.
    [Inject(Id ="LogerText")]
    private TextMeshProUGUI _textMeshProUGUI;   

    //sets the ui's text . 
    public void  Log(string text)
    {
        _textMeshProUGUI.text = text;
    }
}
