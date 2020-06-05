using UnityEngine;
using TMPro;

public class AbilityHoverScript : MonoBehaviour
{
    public GameObject infoTextPanel;
    public TextMeshProUGUI infoText;

    public void HoverOverAbility()
    {
        if (gameObject.name == "Stun")
        {
            infoTextPanel.SetActive(true);
            infoText.text = "   + Get skill check when hit by boss for second chance, - boss switches faster between locations *cooldown*";
        }
        else if (gameObject.name == "SmallRadius")
        {
            infoTextPanel.SetActive(true);
            infoText.text = "   + Makes alerting radius smaller, - boss footstep sound is almost silent *passive*";
        }
        else if (gameObject.name == "Engeneers hands")
        {
            infoTextPanel.SetActive(true);
            infoText.text = "   + Escaping wait timers are shorter, - walking speed is slower *passive*";
        }
        else if (gameObject.name == "Feathery feet")
        {
            infoTextPanel.SetActive(true);
            infoText.text = "   + Gives short speed boost when e is pressed, - boss normal walk is faster *cooldown*";
        }
        else if (gameObject.name == "Golden Sight")
        {
            infoTextPanel.SetActive(true);
            infoText.text = "   + Shows u whare the closest object is when e is pressed, - makes load noice that alerts the boss *cooldown*";
        }
        else if (gameObject.name == "Coming Soon")
        {
            infoTextPanel.SetActive(true);
            infoText.text = "Ability coming soon";
        }
    }

    public void ExitHover()
    {
        infoTextPanel.SetActive(false);
    }
}
