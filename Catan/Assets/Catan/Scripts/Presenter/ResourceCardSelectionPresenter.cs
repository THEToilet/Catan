using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Catan.Scripts.Card;
using DG.Tweening;

public class ResourceCardSelectionPresenter : MonoBehaviour
{
    [SerializeField] Button woodButton;
    [SerializeField] Button woolButton;
    [SerializeField] Button wheatButton;
    [SerializeField] Button ironOreButton;
    [SerializeField] Button brickButton;
    [SerializeField] GameObject resourcePanel;
    private CardType resource;
    public bool isPushed;

    private void Start()
    {
        woodButton.OnClickAsObservable().Subscribe(_ =>
       {
           resource = CardType.Wood;
       });
        woodButton.OnClickAsObservable().Subscribe(_ =>
       {
           resource = CardType.Wool;
       });
        wheatButton.OnClickAsObservable().Subscribe(_ =>
       {
           resource = CardType.Wheat;
       });
        ironOreButton.OnClickAsObservable().Subscribe(_ =>
       {
           resource = CardType.IronOre;
       });
        brickButton.OnClickAsObservable().Subscribe(_ =>
       {
           resource = CardType.Brick;
       });
    }

    public void ShowPanel()
    {
       resourcePanel.transform.DOLocalMove(new Vector3(0, -300f,0), 0.5f);
    }
    public void ErasePanel()
    {
       resourcePanel.transform.DOLocalMove(new Vector3(0, -1700f,0), 0.5f);
        isPushed = false;
    }

    public CardType GetResourceType()
    {
        return resource;
    }
}
