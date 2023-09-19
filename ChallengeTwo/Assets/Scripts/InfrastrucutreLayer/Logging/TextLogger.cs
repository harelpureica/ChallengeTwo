using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.Infrastructure.Logging
{
    //this class is resposible for logging text during run time using TMPro ui.
    public class TextLogger
    {
        //the ui text element to display the log.
        [Inject(Id = "LogerText")]
        private TextMeshProUGUI _textMeshProUGUI;

        //sets the ui's text . 
        public void Log(string text)
        {
            _textMeshProUGUI.text = text;
        }
    }
}
