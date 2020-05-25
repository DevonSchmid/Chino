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
            infoText.text = "Do a skillCheck when catched by the killer to have a second chance";
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
