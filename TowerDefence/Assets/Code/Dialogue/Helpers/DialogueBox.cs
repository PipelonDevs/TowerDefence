using System.Collections;
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
            for (var letterIndex = 0; letterIndex < sentence.Length; letterIndex++)
            {
                // Slow down the typing speed 
                yield return new WaitForSeconds(1 - _slowPower);

                var letter = sentence[letterIndex];
                _message.text += letter;

                // Ensure that the text box doesn't get overloaded with text
                if (letterIndex > 40 && letter is '.' or '!' or '?' or ',') // TODO: problem with "..."
                {
                    Debug.LogWarning("Click space to continue");
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                    ClearText();
                    letterIndex++; // Skip the space
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