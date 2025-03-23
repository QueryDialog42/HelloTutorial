using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class PlayerStateUI : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField] private PlayerControl playerController;
    [SerializeField] private RectTransform playerWalkingTransform;
    [SerializeField] private RectTransform playerSlidingTransform;
    [SerializeField] private RectTransform boosterSpeedTransform;
    [SerializeField] private RectTransform boosterJumpTransform;
    [SerializeField] private RectTransform boosterDarkTransform;


    [Header("Images")]
    [SerializeField] private Image goldenWheatBooster;
    [SerializeField] private Image holyWheatBooster;
    [SerializeField] private Image darkWheatBooster;

    public RectTransform GetBoosterSpeedTransform => boosterSpeedTransform;
    public RectTransform GetBoosterJumpTransform => boosterJumpTransform;
    public RectTransform GetBoosterDarkTransform => boosterDarkTransform;
    public Image GetGoldenWheatBoosterImage => goldenWheatBooster;
    public Image GetHolyWheatBoosterImage => holyWheatBooster;
    public Image GetDarkWheatBoosterImage => darkWheatBooster;


    [Header("Sprites")]
    [SerializeField] private Sprite playerWalkingActiveSprite;
    [SerializeField] private Sprite playerWalkingPassiveSprite;
    [SerializeField] private Sprite playerSlidingActiveSprite;
    [SerializeField] private Sprite playerSlidingPassiveSprite;

    [Header("Animation Settings")]
    [SerializeField] private float moveDuration;
    [SerializeField] private Ease moveEase;
    private Image playerWalkingImage;
    private Image playerSlidingImage;

    void Awake()
    {
        playerWalkingImage = playerWalkingTransform.GetComponent<Image>();
        playerSlidingImage = playerSlidingTransform.GetComponent<Image>();
    }

    private void Start()
    {
        playerController.OnPlayerStateChanged += PlayerController_OnPlayerStateChanged;
        SetStateUI(playerWalkingActiveSprite, playerSlidingPassiveSprite, playerWalkingTransform, playerSlidingTransform);
    }

    private void PlayerController_OnPlayerStateChanged(PlayerState state)
    {
        switch(state){
            case PlayerState.Idle:
            case PlayerState.Move:
                SetStateUI(playerWalkingActiveSprite, playerSlidingPassiveSprite, playerWalkingTransform, playerSlidingTransform);
                break;
            case PlayerState.SlideIdle:
            case PlayerState.Slide:
                SetStateUI(playerWalkingPassiveSprite, playerSlidingActiveSprite, playerSlidingTransform, playerWalkingTransform);
                break;
        }
    }

    private void SetStateUI(
        Sprite playerWalkingSprite,
        Sprite playerSlidingSprite,
        RectTransform activeTransform,
        RectTransform passiveTransform)
    {
        playerWalkingImage.sprite = playerWalkingSprite;
        playerSlidingImage.sprite = playerSlidingSprite;

        activeTransform.DOAnchorPosX(-25f, moveDuration).SetEase(moveEase);
        passiveTransform.DOAnchorPosX(-90f, moveDuration).SetEase(moveEase);
    }

    private IEnumerator SetBoosterUI(
        RectTransform activeTransform,
        Image boosterImage,
        Image wheatImage,
        Sprite activeSprite,
        Sprite passiveSprite,
        Sprite activeWheatSprite,
        Sprite passiveWheatSprite,
        float duration)
    {
        boosterImage.sprite = activeSprite;
        wheatImage.sprite = activeWheatSprite;
        activeTransform.DOAnchorPosX(25f, moveDuration).SetEase(moveEase);

        yield return new WaitForSeconds(duration); // waits for duration time

        boosterImage.sprite = passiveSprite;
        wheatImage.sprite = passiveWheatSprite;
        activeTransform.DOAnchorPosX(90f, moveDuration).SetEase(moveEase);
    }

    public void PlayBoosterUI(
        RectTransform activeTransform,
        Image boosterImage,
        Image wheatImage,
        Sprite activeSprite,
        Sprite passiveSprite,
        Sprite activeWheatSprite,
        Sprite passiveWheatSprite,
        float duration){
            StartCoroutine(SetBoosterUI(activeTransform,
            boosterImage,
            wheatImage,
            activeSprite,
            passiveSprite,
            activeWheatSprite,
            passiveWheatSprite,
            duration));
        }
}
