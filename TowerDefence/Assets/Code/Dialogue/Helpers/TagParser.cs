using UnityEngine;

namespace Code.Dialogue.Helpers
{
    public static class TagParser
    {
        
        /// <summary>
        ///     Parse tags from .ink File
        /// </summary>
        /// <param name="tags">
        ///     List of tags, where each tag suits format:
        ///     #tagName optionalParam
        /// </param>
        public static void Parse(string[] tags)
        {
            foreach (var tag in tags)
            {
                var tagName = tag.Split(' ')[0];
                var param = tag.Split(' ')[1]; // TODO: What if " " is in the param?

                Debug.Log($"Tag: {tag}, TagName: {tagName}, Param: {param}");
                switch (tagName.ToLower())
                {
                    case "function": // for side effects that not affect the Speaker
                        ParseFunction(param);
                        break;
                    case "method":
                        ParseMethod(param, "Speaker");
                        // Speaker.SetAnimation(param);
                        // Speaker.OpenShop(param);
                        break;
                }
            }
        }

        /// <summary>
        ///     Invoke callbacks from DialogueCallbacks.
        /// </summary>
        /// <param name="param"> parameter for callback in format: <i>callbackName:param1,param2,...</i></param>
        private static void ParseFunction(string param)
        {
            (var callbackName, var callbackParams) = ParseNameAndParams(param);

            Debug.Log($"Callback: {callbackName}, Params: {string.Join(", ", callbackParams)}");
            if (typeof(DialogueCallbacks).GetMethod(callbackName) == null)
                Debug.LogError($"Callback {callbackName} does not exist!");
            else
                // similar to eval or getAttr in python:
                typeof(DialogueCallbacks).GetMethod(callbackName).Invoke(null, new object[] { callbackParams });
        }


        /// <summary>
        ///     Invoke callbacks from DialogueCallbacks.
        /// </summary>
        /// <param name="param"> parameter for callback in format: <i>callbackName:param1,param2,...</i></param>
        /// <param name="className">For now it is just a string</param>
        private static void ParseMethod(string param, string className) // TODO
        {
            (var callbackName, var callbackParams) = ParseNameAndParams(param);

            Debug.Log($"Callback: {callbackName}, Params: {string.Join(", ", callbackParams)}");
            if (typeof(DialogueCallbacks).GetMethod(callbackName) == null)
                Debug.LogError($"Callback {callbackName} does not exist!");
            else
                // similar to eval or getAttr in python:
                typeof(DialogueCallbacks).GetMethod(callbackName).Invoke(className, new object[] { callbackParams });
        }

        private static (string, string[]) ParseNameAndParams(string param)
        {
            var name = param.Split(':')[0];
            var parameters = param.Split(':')[1].Split(",");
            return (name, parameters);
        }
    }
}