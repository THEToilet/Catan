using Catan.Scripts.Presenter;
using UnityEngine;
using UniRx.Async;
using Catan.Scripts.Player;
using Catan.Scripts.Card;

namespace Catan.Scripts.Manager
{
    /// <summary>
    /// 発展カード使用時のクラス
    /// </summary>
    enum SpecialCardState
    {
        Knight, MainRoad, Harvest, Monopolization, None
    }

    public class SpecialCardManeger : MonoBehaviour
    {

        public TheifManeger theifManeger;
        public RoadBasePresenter roadBasePresenter;
        public ToPleyerObject toPleyerObject;
        public PlayerTurnManeger playerTurnManeger;
        public ResourceCardSelectionPresenter resourceCardSelectionPresenter;
        public ToCardObject toCardObject;
        public ToCardWithCardTypeObject toCardWithCardTypeObject;
        public MonopolizationManeger monopolizationManeger;
        public UIRestrictionPresenter uIRestrictionPresenter;
        public PlayerNotificationPresenter playerNotificationPresenter;
        SpecialCardState specialCardState = SpecialCardState.None;
        [SerializeField] GameObject resourceSelectionPanel;

        private void Update()
        {
            switch (specialCardState)
            {
                case SpecialCardState.None:
                    break;
                case SpecialCardState.Harvest:
                    break;
                case SpecialCardState.Knight:
                    break;
                case SpecialCardState.MainRoad:
                    break;
                case SpecialCardState.Monopolization:
                    break;
            }
        }

        public void Knight()
        {
            uIRestrictionPresenter.TurnOffAll();
            Debug.Log("Knight");
            playerNotificationPresenter.DisplayNote("Knight");
            theifManeger.MoveTheif();
            DeleteSpecialCard(SpecialCardType.Knight); 
        }

        async public UniTask MainRoad()
        {
            
            uIRestrictionPresenter.TurnOffAll();
            // 路を二つ置く
            Debug.Log("MainRoad");
            playerNotificationPresenter.DisplayNote("MainRoad");
            roadBasePresenter.ShowPossiblePoint(playerTurnManeger._currentPlayerId.Value);
            var g = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
            int c = g.GetComponent<Belongings>().Road.Count;
            await CheckLocateRoad(c, g);
            Debug.Log("mainroad1");
            roadBasePresenter.EraseAll();
            roadBasePresenter.ShowPossiblePoint(playerTurnManeger._currentPlayerId.Value);
            c = g.GetComponent<Belongings>().Road.Count;
            await CheckLocateRoad(c, g);
            Debug.Log("mainroad2");
            roadBasePresenter.EraseAll();
            uIRestrictionPresenter.LetAction();
            DeleteSpecialCard(SpecialCardType.Road); 
        }

        async public UniTask Harvest()
        {
            uIRestrictionPresenter.TurnOffAll();
            Debug.Log("Harvest");
            playerNotificationPresenter.DisplayNote("Harvest");
            // HarveestPresenterに関数を作り使うカードを選ばせる
            resourceSelectionPanel.SetActive(true);
            await UniTask.WaitUntil(() => resourceCardSelectionPresenter.isPushed);
            Debug.Log("Harvest1");
            CardType r1 = resourceCardSelectionPresenter.GetResourceType();
            resourceCardSelectionPresenter.isPushed = false;
            resourceSelectionPanel.SetActive(true);
            await UniTask.WaitUntil(() => resourceCardSelectionPresenter.isPushed);
            Debug.Log("Harvest2");
            CardType r2 = resourceCardSelectionPresenter.GetResourceType();
            resourceCardSelectionPresenter.isPushed = false;

            // 資源カードを二枚もらえる
            var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
            var c = p.GetComponent<Belongings>().cards;
            c.Add(toCardWithCardTypeObject.ToCard(r1));
            c.Add(toCardWithCardTypeObject.ToCard(r2));

            uIRestrictionPresenter.LetAction();
            DeleteSpecialCard(SpecialCardType.Harvest); 

        }

        async public UniTask Monopolization() // バグ？
        {
            uIRestrictionPresenter.TurnOffAll();
            Debug.Log("Monopolization");
            playerNotificationPresenter.DisplayNote("Monopolization");
            // HarveestPresenterに関数を作り使うカードを選ばせる
            // 指定した資源一種類全部もらえる
            resourceSelectionPanel.SetActive(true);
            await UniTask.WaitUntil(() => resourceCardSelectionPresenter.isPushed);
            Debug.Log("ato Monopoli");
            resourceCardSelectionPresenter.isPushed = false;
            CardType r = resourceCardSelectionPresenter.GetResourceType();
            monopolizationManeger.monopoly(r);
            uIRestrictionPresenter.LetAction();
            DeleteSpecialCard(SpecialCardType.Monopolization); 
        }

        async UniTask CheckLocateRoad(int c, GameObject g)
        {
            await UniTask.WaitUntil(() => g.GetComponent<Belongings>().Road.Count > c);
        }

        void DeleteSpecialCard(SpecialCardType cost)
        {
            var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().scards;
            for(int i = 0; i < p.Count; i++)
            {
                if(p[i].GetComponent<SpecialCardEntity>().specialCardType == cost)
                {
                    p.RemoveAt(i);
                    break;
                }
            }
        }
    }
}