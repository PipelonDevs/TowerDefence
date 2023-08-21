using UnityEngine;

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
    }
}