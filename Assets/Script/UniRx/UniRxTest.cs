using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Operators;
using UnityEngine.UI;
using System;


public class UniRxTest : MonoBehaviour
{


    [SerializeField]
    private Button btnUniRx;
    



    // Start is called before the first frame update
    void Start()
    {

        InitButtonCallback();
        this.TestUniRx();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InitButtonCallback() {
        btnUniRx.OnClickAsObservable().Subscribe(_ => Debug.Log("ニャンコ"));
        
    }

    private void TestUniRx()
    {

        var maru = new Subject<int>();
        maru.Subscribe(
            msg => { Debug.Log("onnext_"); },
            () => { Debug.Log("onComplete"); }
            );
        maru.OnNext(20);




        //引数にstringが渡せるSubjectを作成(intやboolなど他の型でもOK)
        var sub = new Subject<string>();

        //Subscribeを使って処理を登録する

        sub.Subscribe(
  onNext: text => Debug.Log("テキスト！ : " + text),
  onError: error => Debug.Log("エラー！ : " + error),
  onCompleted: () => Debug.Log("完了!")
);

        //"テキスト"というstringを渡して、処理を実行(ログが表示される)
        sub.OnNext("UniRxですぞ");

        /*
        sub.Where(text => text.Length < 10) //10文字未満の時だけ、これ以降の処理をする
  .Select(text => text + text[0])   //1文字目を最後尾に追加
  .Subscribe(text => Debug.Log(text));
        */


        var subb = new Subject<int>();
        subb.
            Where(no => no > 10).
            

            Subscribe(

            onNext:
            no =>
            {
                Debug.Log("バイク");
                Debug.Log(no);
            },
            onError: error => Debug.LogError(error)
            ,
            onCompleted: () =>
            {
                Debug.Log("ミッションコンプリート");
            }
            );


        /*
        subb.Subscribe(

            onNext:
            no => {
                Debug.Log("バイク");
                Debug.Log(no);
            },
            onError: error => Debug.LogError(error)
            ,
            onCompleted: () => {
                Debug.Log("ミッションコンプリート");
            }
            );
        */



        subb.OnNext(2);
        //subb.OnCompleted();
        //subb.OnError(new System.Exception("えりゃ〜"));
        subb.OnNext(33);

        //2秒後に処理が実行されるIObservableを作成
        IObservable<long> observable = Observable.Timer(TimeSpan.FromSeconds(2));

        //処理を登録
        observable.Subscribe(_ => Debug.Log("2秒遅れて実行"));


        IObservable<long> aobservable = Observable.Timer(TimeSpan.FromSeconds(3));
        aobservable.Subscribe(_ =>
        {
            Debug.Log("待ったれよ!");
        });





    }
}