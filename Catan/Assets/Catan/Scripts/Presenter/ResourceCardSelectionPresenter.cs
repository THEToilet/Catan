using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Catan.Scripts.Card;
using Catan.Scripts.Manager;

/// <summary>
/// 発展カード使用時に使用
/// </summary>
public class ResourceCardSelectionPresenter : MonoBehaviour
{
    [SerializeField] Button woodButton;
    [SerializeField] Button woolButton;
    [SerializeField] Button wheatButton;
    [SerializeField] Button ironOreButton;
    [SerializeField] Button brickButton;
    [SerializeField] GameObject resourcePanel;
    private CardType resource;
    public PlayerTurnManeger playerTurnManeger;
    public bool isPushed = false;

    private void Start()
    {
        woodButton.OnClickAsObservable().Subscribe(_ =>
       {
           resource = CardType.Wood;
           isPushed = true;
           resourcePanel.SetActive(false);
       });
        woodButton.OnClickAsObservable().Subscribe(_ =>
       {
           resource = CardType.Wool;
           isPushed = true;
           resourcePanel.SetActive(false);
       });
        wheatButton.OnClickAsObservable().Subscribe(_ =>
       {
           resource = CardType.Wheat;
           isPushed = true;
           resourcePanel.SetActive(false);
       });
        ironOreButton.OnClickAsObservable().Subscribe(_ =>
       {
           resource = CardType.IronOre;
           isPushed = true;
           resourcePanel.SetActive(false);
       });
        brickButton.OnClickAsObservable().Subscribe(_ =>
       {
           resource = CardType.Brick;
           isPushed = true;
           resourcePanel.SetActive(false);
       });
    }
    public CardType GetResourceType()
    {
        return resource;
    }
}
