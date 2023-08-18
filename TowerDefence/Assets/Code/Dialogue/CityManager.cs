using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Dialogue
{
    public class CityManager : MonoBehaviour
    {
        public void EnterTavern()
        {
            SceneManager.LoadScene("TavernScene");
            Debug.Log("Enter Tavern");
        }
    }
}