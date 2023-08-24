using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Dialogue.Helpers
{
    public class DialogueBox
    {
        private Text _nameTag;
        private Text _message;
        private readonly float _slowPower;

        public DialogueBox(GameObject textBox, string speakerName, float slowPower)
        {
            _nameTag = textBox.transform.GetChild(0).GetComponent<Text>();
            _nameTag.text = speakerName;

            _message = textBox.transform.GetChild(1).GetComponent<Text>();
            _slowPower = slowPower;
        }

        public void ClearText()
        {
            _message.text = "";
        }

        // Type out the sentence letter by letter and make character idle if they were talking
        public IEnumerator TypeSentence(string sentence)
        {
            ClearText();
            var words = sentence.Split(' '); // In a sentence there is no \n
            
            int displayedWords = 0;
            foreach (string word in words)
            {
                // Slow down the typing speed 
                yield return new WaitForSeconds(1 - _slowPower);

                _message.text += word + ' ';
                displayedWords ++;
                
                // Ensure that the text box doesn't get overloaded with text
                if (displayedWords > 5 && word.Last() is'.' or '?' or '!' or '?') 
                {
                    Debug.LogWarning("Click space to continue");
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                    ClearText();
                    displayedWords = 0;
                }

                yield return null;
            }

            /* BACKLOG: "Animator"
             SpeakerAnimation tempSpeakerAnimation = GameObject.FindObjectOfType<SpeakerAnimation>();
             if(tempSpeaker.isTalking)
             {
             SetAnimation("idle");
             }
            */
            yield return null;
        }
    }
}