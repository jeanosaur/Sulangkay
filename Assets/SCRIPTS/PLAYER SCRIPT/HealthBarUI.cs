using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [Header("Heart Sprites")]
    public Sprite fullHeartSprite;
    public Sprite emptyHeartSprite;

    [Header("References")]
    public HealthSystem playerHealth;  // Reference to your player's health system
    public GameObject heartPrefab;     // UI prefab with an Image component
    public Transform heartsContainer;  // Parent object for all hearts

    private List<Image> heartImages = new List<Image>();

    private void Start()
    {
        if (playerHealth == null)
        {
            Debug.LogWarning("HealthHeartsUI: PlayerHealth not assigned!");
            return;
        }

        CreateHearts();
    }

    private void Update()
    {
        UpdateHearts();
    }

    private void CreateHearts()
    {
        // Clear any existing hearts
        foreach (Transform child in heartsContainer)
        {
            Destroy(child.gameObject);
        }
        heartImages.Clear();

        // Create hearts equal to PlayerMaxHealth
        for (int i = 0; i < playerHealth.PlayerMaxHealth; i++)
        {
            GameObject newHeart = Instantiate(heartPrefab, heartsContainer);
            Image heartImage = newHeart.GetComponent<Image>();
            heartImages.Add(heartImage);
        }
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < heartImages.Count; i++)
        {
            if (i < playerHealth.PlayerHealth)
            {
                heartImages[i].sprite = fullHeartSprite;
            }
            else
            {
                heartImages[i].sprite = emptyHeartSprite;
            }
        }
    }
}