using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
	public GameObject[] characters;
	public GameObject[] accuracyBars;
	public GameObject[] zoomBars;
	public int selectedCharacter = 0;

	public void NextCharacter()
	{
		characters[selectedCharacter].SetActive(false);
		accuracyBars[selectedCharacter].SetActive(false);
		zoomBars[selectedCharacter].SetActive(false);

		selectedCharacter = (selectedCharacter + 1) % characters.Length;

		characters[selectedCharacter].SetActive(true);
		accuracyBars[selectedCharacter].SetActive(true);
		zoomBars[selectedCharacter].SetActive(true);
	}

	public void PreviousCharacter()
	{
		characters[selectedCharacter].SetActive(false);
		accuracyBars[selectedCharacter].SetActive(false);
		zoomBars[selectedCharacter].SetActive(false);

		selectedCharacter--;
		if (selectedCharacter < 0)
		{
			selectedCharacter += characters.Length;
		}


		characters[selectedCharacter].SetActive(true);
		accuracyBars[selectedCharacter].SetActive(true);
		zoomBars[selectedCharacter].SetActive(true);
	}

	public void StartGame()
	{	
		PlayerPrefs.SetInt("currWeapon", selectedCharacter);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
