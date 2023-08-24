using UnityEngine;
using System;
using System.Linq;

namespace Code.Dialogue.Helpers
{
    public static class DialogueCallbacks
    {
        public static void HatePlayer(string[] npcNames) // TODO: remove this
        {
            Debug.LogWarning("I hate you!" + string.Join(", ", npcNames));
        }

        /// <summary>
        ///     Set next dialogue for a given NPC. Use when a dialogue with one NPC influences other NPC dialogue paths.
        /// </summary>
        /// <param name="parameters"></param>
        public static void SetNextDialogue(string[] parameters) // TODO
        {
            var nextDialogue = parameters[0];
            var npcName = parameters[1];

            // Find NPC by name
            // Set NPC's next dialogue
            Debug.Log("Set next dialogue to " + nextDialogue);
        }

        /// <summary>
        /// Used as an Ink function to color text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="theme">Can be name of a color of hexadecimal RGBA </param>
        /// <returns></returns>
        public static string Color(string text, string theme)
        {
            string[]words = text.Split (' ');
            Func < string, string > formatWord = word => $"<color={theme}>{word}</color>";

            return string.Join(" ", words.Select(formatWord));
        }
    }
}