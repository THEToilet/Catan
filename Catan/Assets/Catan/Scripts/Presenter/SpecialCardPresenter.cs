using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Player;
using Catan.Scripts.Card;
using UnityEngine.UI;
using Catan.Scripts.Manager;
using DG.Tweening;
using System.Threading;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;

namespace Catan.Scripts.Presenter
{

    public class SpecialCardPresenter : MonoBehaviour
    {
        public ToPleyerObject toPleyerObject;
        public ToCardObject toCardObject;
        public SpecialCardManeger specialCardManeger;
        [SerializeField] GameObject specialHnad;
        [SerializeField] GameObject actionsPanel;
        [SerializeField] Button cancelButton;
        [SerializeField] Button actionButton;
        public void CreateCard(PlayerId playerId)
        {
            // 生成
            var p = toPleyerObject.ToPlayer(playerId);
            foreach (GameObject g in p.GetComponent<Belongings>().scards)
            {
                GameObject go = GameObject.Instantiate(g, specialHnad.transform.position, Quaternion.identity);
                go.transform.SetParent(specialHnad.transform); 
                var cardType = g.GetComponent<SpecialCardEntity>().specialCardType;
                go.GetComponent<Button>().onClick.AddListener(() => actionsPanel.GetComponent<DOTweenAnimation>().DOPlayBackwards());
                go.GetComponent<Button>().onClick.AddListener(() => cancelButton.gameObject.SetActive(false));
                go.GetComponent<Button>().onClick.AddListener(() => actionButton.gameObject.SetActive(true));
                switch (cardType)
                {
                    case SpecialCardType.Harvest:
                        go.GetComponent<Button>().onClick.AddListener(() => specialCardManeger.Harvest().Forget());
                        break;
                    case SpecialCardType.Knight:
                        go.GetComponent<Button>().onClick.AddListener(() => specialCardManeger.Knight());
                        break;
                    case SpecialCardType.Monopolization:
                        go.GetComponent<Button>().onClick.AddListener(() => specialCardManeger.Monopolization().Forget());
                        break;
                    case SpecialCardType.Road:
                        go.GetComponent<Button>().onClick.AddListener(() => specialCardManeger.MainRoad().Forget());
                        break;
                    case SpecialCardType.Wining:
                        break;
                    default:
                        break;
                }
            }
        }

        public void DeleateCard(PlayerId playerId)
        {
            // 取得
            foreach (Transform n in specialHnad.transform)
            {
                GameObject.Destroy(n.gameObject);
            }
        }
    }

}