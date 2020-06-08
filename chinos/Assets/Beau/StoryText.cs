using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StoryText : MonoBehaviour
{
    public TextMeshProUGUI storyText;

    private void Start()
    {
        print(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            StartCoroutine(Level1Info());
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            StartCoroutine(Level2Info());
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            StartCoroutine(Level3Info());
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            StartCoroutine(Level4Info());
        }
    }
    IEnumerator Level1Info()
    {
        storyText.text = "Finally, i'm here";
        yield return new WaitForSeconds(3);
        storyText.text = "I know this house is haunted by something";
        yield return new WaitForSeconds(5);
        storyText.text = "But it has stolen something from me";
        yield return new WaitForSeconds(5);
        storyText.text = "And i need to get it back";
        yield return new WaitForSeconds(3);
        storyText.text = "It's really important";
        yield return new WaitForSeconds(3);
        storyText.text = "(Hint: Find item's to start the generator)";
        yield return new WaitForSeconds(5);
        storyText.text = "(Phone, Energy Box, Generator)";
        yield return new WaitForSeconds(5);
        storyText.text = "";
    }
    IEnumerator Level2Info()
    {
        storyText.text = "I know he has hidden it somewhere";
        yield return new WaitForSeconds(5);
        storyText.text = "But I need to look further";
        yield return new WaitForSeconds(3);
        storyText.text = "I need to have it back";
        yield return new WaitForSeconds(3);
        storyText.text = "(Hint: Find item's to break open the blocked door, and unlock the door";
        yield return new WaitForSeconds(6);
        storyText.text = "(Crowbar, Tape, Key)";
        yield return new WaitForSeconds(5);
        storyText.text = "";
    }
    IEnumerator Level3Info()
    {
        storyText.text = "I can almost smell it";
        yield return new WaitForSeconds(3);
        storyText.text = "I'm so close";
        yield return new WaitForSeconds(3);
        storyText.text = "(Hint: Find item's to open the trap door)";
        yield return new WaitForSeconds(5);
        storyText.text = "(Lever, Gear, Trap door)";
        yield return new WaitForSeconds(5);
        storyText.text = "";
    }
    IEnumerator Level4Info()
    {
        storyText.text = "It's here I know it";
        yield return new WaitForSeconds(3);
        storyText.text = "The last time i'm stuck in this house";
        yield return new WaitForSeconds(3);
        storyText.text = "(Hint: Find the button's and press them in the good order to get the key)";
        yield return new WaitForSeconds(5);
        storyText.text = "(6 Buttons, Box with Key)";
        yield return new WaitForSeconds(5);
        storyText.text = "";
    }
}
