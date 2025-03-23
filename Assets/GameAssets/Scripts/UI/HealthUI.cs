using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class HealthUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image[] playerHealthImages;

    [Header("Images")]
    [SerializeField] private Sprite playerHealthySprite;
    [SerializeField] private Sprite playerUnHealtySprite;

    [Header("Settings")]
    [SerializeField] private float scaleDuration;

    private RectTransform[] playerHealthTransform;

    private void Awake()
    {
        playerHealthTransform = new RectTransform[playerHealthImages.Length];
        for(int i = 0; i < playerHealthImages.Length; i++){
            playerHealthTransform[i] = playerHealthImages[i].gameObject.GetComponent<RectTransform>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)){
            AnimateDamage();
        }
        else if (Input.GetKeyDown(KeyCode.P)){
            AnimateDamageAll();
        }
    }

    public void AnimateDamage(){
        for(int i = 0; i < playerHealthImages.Length; i++){
            if(playerHealthImages[i].sprite == playerHealthySprite){
                AnimateDamageSprite(playerHealthImages[i], playerHealthTransform[i]);
                break;
            }
        }
    }

    public void AnimateDamageAll(){
        for(int i = 0; i < playerHealthImages.Length; i++){
            AnimateDamageSprite(playerHealthImages[i], playerHealthTransform[i]);
        }
    }

    private void AnimateDamageSprite(Image activeImage, RectTransform activeImageTransform){
        activeImageTransform.DOScale(0f, scaleDuration).SetEase(Ease.InBack).OnComplete(() => {
            activeImage.sprite = playerUnHealtySprite;
            activeImageTransform.DOScale(1f, scaleDuration).SetEase(Ease.OutBack);
        });
    }
}
