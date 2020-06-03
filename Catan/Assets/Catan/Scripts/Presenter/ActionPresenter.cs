using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Catan.Scripts.Manager;

namespace Catan.Scripts.Presenter
{
  public class ActionPresenter : MonoBehaviour
  {
    [SerializeField] private Button turnEndButton;

    [SerializeField] private Button constructionButton;

    [SerializeField] private Button aboutCardButton;

    [SerializeField] private Button tradeButton;

    [SerializeField] private Button negotiationButton;

    [SerializeField] private Button drawCardButton;

    public GameStateManeger gameStateManeger;
    public PlayerTurn playerTurn;



    // Start is called before the first frame update
    void Start()
    {

      constructionButton.OnClickAsObservable()  // 建設する
      .Subscribe(_ =>
      {
        gameStateManeger._currentGameState
                  .SetValueAndForceNotify(GameState.Construction);
      });

      aboutCardButton.OnClickAsObservable()  // カードを使う　
      .Subscribe(_ =>
      {
        gameStateManeger._currentGameState
                  .SetValueAndForceNotify(GameState.AboutCard);
      });


      drawCardButton.OnClickAsObservable()
      .Subscribe(_ =>
      {
        gameStateManeger._currentGameState
                  .SetValueAndForceNotify(GameState.AboutCard);
      });

      tradeButton.OnClickAsObservable()
      .Subscribe(_ =>
      {
        gameStateManeger._currentGameState
                  .SetValueAndForceNotify(GameState.Trade);
      });

      negotiationButton.OnClickAsObservable()
      .Subscribe(_ =>
      {
        gameStateManeger._currentGameState
                  .SetValueAndForceNotify(GameState.Negotiation);
      });

      turnEndButton.OnClickAsObservable()
      .Subscribe(_ =>
      {
        playerTurn.isActive = true;
      });

    }

  }
}