using UnityEngine;

public class JournalUIPanel : MonoBehaviour
{
    public GameObject journalPanel;

    private bool isOpen = false;

    void Start()
    {
        if (journalPanel != null)
            journalPanel.SetActive(false); // Hide panel when the game starts
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            TogglePanel();
        }
    }

    public void TogglePanel()
    {
        if (journalPanel == null) return;

        isOpen = !isOpen;
        journalPanel.SetActive(isOpen);
    }
}
