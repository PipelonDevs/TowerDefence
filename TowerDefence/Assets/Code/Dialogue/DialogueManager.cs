using System;
using System.Linq;
using Code.Dialogue.Helpers;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using Selectable = Code.Dialogue.Helpers.Selectable;

namespace Code.Dialogue
{
    /// <summary>
    ///     Handles the Speaker dialog box and story (Player choices, NPC responses and tags)
    /// </summary>
    public class DialogueManager : MonoBehaviour
    {
        [Tooltip("The panel that holds the choices")]
        public GameObject choicePanel;

        [Tooltip("The prefab for choice buttons")]
        public GameObject choiceButton;

        
        private bool _isSpeaking;
        private static Choice _choiceSelected;

        public static Speaker speaker { get; private set; }


        private void Start()
        {
            _choiceSelected = null;
            choicePanel.SetActive(false);
        }


        private void Update()
        {
            if (speaker == null) return;

            if (speaker.story.canContinue)
            {
                AdvanceDialogue();
                ShowChoices();
            }

            if (_choiceSelected) AdvanceFromDecision();
        }

        public static bool SetSpeaker(Speaker newSpeaker)
        {
            if (newSpeaker == null) throw new ArgumentNullException(nameof(newSpeaker));
            if (speaker != null) return false;

            speaker = newSpeaker;
            Debug.Log($"Speaker set to {speaker.name}");
            return true;
        }

        /// <summary>
        ///     Go to the next line of dialogue (lines are separated by \n)
        /// </summary>
        private void AdvanceDialogue()
        {
            var currentLine = speaker.story.Continue();
            TagParser.Parse(speaker.story.currentTags.ToArray());
            if (currentLine.StartsWith("Player:"))
                Debug.LogWarning(currentLine);
            else
                StartCoroutine(speaker.dialogueBox.TypeSentence(currentLine));
        }

        private void ShowChoices()
        {
            var choices = speaker.story.currentChoices;
            Debug.Log($"{choices.Count} choices to be made: {string.Join(", ", choices.Select(c => c.text))}");

            if (choices.Count == 0 && !speaker.story.canContinue) FinishDialogue();

            for (var i = 0; i < choices.Count; i++)
            {
                var temp = Instantiate(choiceButton, choicePanel.transform);
                temp.name = $"{choices[i].text}ChoiceButton";

                temp.transform.GetChild(0).GetComponent<Text>().text = choices[i].text;
                temp.AddComponent<Selectable>();
                temp.GetComponent<Selectable>().element = choices[i];
                temp.GetComponent<Button>().onClick.AddListener(() => { temp.GetComponent<Selectable>().Decide(); });
            }

            choicePanel.SetActive(true);
        }

        /// <summary>
        ///     Tells the story which branch to go to. This is called by the choiceButton
        /// </summary>
        public static void SetDecision(object element)
        {
            _choiceSelected = (Choice)element;
            speaker.story.ChooseChoiceIndex(_choiceSelected.index);
        }

        /// <summary>
        ///     After a choice was made, turn off the panel and advance from that choice
        /// </summary>
        private void AdvanceFromDecision()
        {
            Debug.Log("Selected choice: " + _choiceSelected.text);
            choicePanel.SetActive(false);
            StopAllCoroutines(); // Stop typing NPC text

            for (var i = 0; i < choicePanel.transform.childCount; i++)
                Destroy(choicePanel.transform.GetChild(i).gameObject);

            _choiceSelected = null;
        }

        /// <summary>
        ///     Conversation is finished when the only possible choice is "End"
        /// </summary>
        private void FinishDialogue()
        {
            speaker.FinishConversation();
            speaker = null;
        }

        /// <summary>
        ///     Plays a speaker animation
        /// </summary>
        private void SetAnimation(string animationName)
        {
            var cs = FindFirstObjectByType<SpeakerAnimation>();
            cs.PlayAnimation(animationName);
        }
    }
}