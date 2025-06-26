/*
 * namespace : 名前空間 (クラス等所属先) を定義
 * 
 * using : 名前空間内の要素に接頭辞を省略してアクセス可能
 */
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/*
 * private (省略可能) : 同クラスからアクセス可能
 * 
 * protected : 同クラス, サブクラス (継承先) からアクセス可能
 * 
 * public : 全クラスからアクセス可能 (インスペクタから設定可能)
 * 
 * MonoBehaviour クラス : スクリプトをコンポーネントとしてアタッチ可能にするフレームワーク, ゲームオブジェクトを制御する機能等を提供
 */
public class PlayerController : MonoBehaviour   // PlayerController (MonoBehaviour 継承) クラスを public として定義
{
    /*
     * 値型 (Value Type) : データ (値) を保持
     * 
     * 参照型 (Reference Type) : アドレス (参照) を保持
     */
    Rigidbody rb;   // Rigidbody 型 (参照型) のフィールド (rb) を private として定義
    public float speed; // float 型 (値型) のフィールド (speed) を public として定義 (インスペクタ : 10)
    int count;  // int 型 (値型) のフィールド (count) を private として定義
    public TextMeshProUGUI countText;   // TextMeshProUGUI 型 (参照型) のフィールド (countText) を public として定義 (インスペクタ : CountText (Text Mesh Pro UGUI))
    AudioSource getSE;  // AudioSource 型 (参照型) のフィールド (getSE) を private として定義

    /*
     * MonoBehaviour.Start() : 全コンポーネントの MonoBehaviour.Awake() 終了後, 本コンポーネントとアタッチされているゲームオブジェクトの両方が有効な場合に 1 回だけ実行されるメソッド
     */
    void Start()
    {
        /* 
         * this.gameObject.GetComponent<T>()
         * this (省略可能) : 本コンポーネント (参照)
         * gameObject (省略可能) : ゲームオブジェクト (参照)
         * 本コンポーネントがアタッチされているゲームオブジェクトの T コンポーネント (参照) を取得 (取得不可能 → null)
         *
         * Rigidbody コンポーネント : ゲームオブジェクトに物理特性を追加
         */
        rb = GetComponent<Rigidbody>(); // ゲームオブジェクト (Player) の Rigidbody コンポーネントを取得
        count = 0;  // 初期化
        SetCountText(); // テキスト (アイテム取得数) を UI に表示
        /*
         * AudioSource コンポーネント : ゲームオブジェクトにオーディオ再生機能を追加
         */
        getSE = GetComponent<AudioSource>();    // ゲームオブジェクト (Player) の AudioSource コンポーネントを取得
    }

    /*
     * MonoBehaviour.Update() : 全コンポーネントの MonoBehaviour.Start() 終了後, フレーム (不定, 性能依存) 毎に 1 回だけ実行されるメソッド
     */
    // void Update()
    // {
    //     /*
    //      * Input.GetAxis("Horizontal")
    //      * Horizontal : Input Manager からキー設定可能
    //      * 移動キー (A, ←) を押している長さに応じて小数の戻り値を返却 (0 ~ -1)
    //      * 移動キー (D, →) を押している長さに応じて小数の戻り値を返却 (0 ~ 1)
    //      */
    //     float moveH = Input.GetAxis("Horizontal");  // x 軸方向 (左右) の入力値を格納 (-1 ~ 1)
    //     /*
    //      * Input.GetAxis("Vertical")
    //      + Vertical : Input Manager からキー設定可能
    //      * 移動キー (S, ↓) を押している長さに応じて小数の戻り値を返却 (0 ~ -1)
    //      * 移動キー (W, ↑) を押している長さに応じて小数の戻り値を返却 (0 ~ 1)
    //      */
    //     float moveV = Input.GetAxis("Vertical");    // z 軸方向 (前後) の入力値を格納 (-1 ~ 1)
    //     /*
    //      * Vector3 型 : (x, y, z)
    //      * 
    //      * new 演算子 : クラス, 構造体, 配列等のインスタンス (新規オブジェクト) を生成
    //      */
    //     Vector3 move = new Vector3(moveH, 0, moveV);    // 初期化
    //     /*
    //      * Rigidbody.AddForce(Vector3 force)
    //      * force : 力 (ワールド空間)
    //      * ゲームオブジェクト (Rigidbody.gameObject) に力 (ワールド空間) を付与
    //      */
    //     rb.AddForce(move * speed);  // ゲームオブジェクト (Player) に力 (move * speed) を付与
    // }

    /*
     * MonoBehaviour.FixedUpdate() : 全コンポーネントの MonoBehaviour.Start() 終了後, フレーム (一定) 毎に 1 回だけ実行されるメソッド
     */
    void FixedUpdate()
    {
        /*
         * Input.GetAxis("Horizontal")
         * Horizontal : Input Manager からキー設定可能
         * 移動キー (A, ←) を押している長さに応じて小数の戻り値を返却 (0 ~ -1)
         * 移動キー (D, →) を押している長さに応じて小数の戻り値を返却 (0 ~ 1)
         */
        float moveH = Input.GetAxis("Horizontal");  // x 軸方向 (左右) の入力値を格納 (-1 ~ 1)
        /*
         * Input.GetAxis("Vertical")
         * Vertical : Input Manager からキー設定可能
         * 移動キー (S, ↓) を押している長さに応じて小数の戻り値を返却 (0 ~ -1)
         * 移動キー (W, ↑) を押している長さに応じて小数の戻り値を返却 (0 ~ 1)
         */
        float moveV = Input.GetAxis("Vertical");    // z 軸方向 (前後) の入力値を格納 (-1 ~ 1)
        /*
         * Vector3 型 : (x, y, z)
         * 
         * new 演算子 : クラス, 構造体, 配列等のインスタンス (新規オブジェクト) を生成
         */
        Vector3 move = new Vector3(moveH, 0, moveV);    // 初期化
        /*
         * 物理演算 : MonoBehaviour.FixedUpdate() 内処理推奨
         * 
         * Rigidbody.AddForce(Vector3 force)
         * force : 力 (ワールド空間)
         * ゲームオブジェクト (Rigidbody.gameObject) に力 (ワールド空間) を付与
         */
        rb.AddForce(move * speed);  // ゲームオブジェクト (Player) に力 (move * speed) を付与
    }

    /*
     * Collider コンポーネント : ゲームオブジェクトに当たり判定等を追加
     * トリガ機能 (isTrigger == true) → Rigidbody の衝突判定無効, トリガイベント (OnTrigger) 発生
     * 衝突機能 (isTrigger == false) → Rigidbody の衝突判定有効, 衝突イベント (OnCollision) 発生
     * 
     * MonoBehaviour.OnTriggerEnter(Collider other)
     * other : 相手の Collider コンポーネント (参照)
     * ゲームオブジェクト (両方) : Collider コンポーネント必須
     * ゲームオブジェクト (片方) : Rigidbody コンポーネント, トリガ機能必須
     * ゲームオブジェクト (トリガ機能) の領域侵入時に 1 回だけ実行されるメソッド
     */
    private void OnTriggerEnter(Collider other)
    {
        /*
         * プロパティ : アクセス (クラス外 → メンバ) を制御するメソッド
         * 
         * Component.gameObject{ get; } : 全コンポーネントはプロパティを用いてアタッチされているゲームオブジェクト (参照) を取得可能
         * 
         * Collider.gameObject.CompareTag(string tag)
         * Collider : Collider コンポーネント (参照)
         * gameObject (省略可能) : ゲームオブジェクト (参照)
         * tag : タグ (値)
         * gameObject.tag == tag → true
         * gameObject.tag != tag → false
         */
        if (other.gameObject.CompareTag("Item"))    // 相手のゲームオブジェクトのタグが Item (インスペクタから設定) の場合
        {
            /*
             * GameObject.SetActive(bool value)
             * value : ブール値 (true, false)
             * ゲームオブジェクトのアクティブ状態を設定
             */
            other.gameObject.SetActive(false);  // 相手のゲームオブジェクト (Item) を無効化
            count = count + 1;  // インクリメント
            // Debug.Log(count);   // コンソールにアイテム取得数を表示
            SetCountText(); // テキスト (アイテム取得数) を UI に表示
            /*
             * AudioSource.Play()
             * Audio Resurce を再生
             * 重複再生 (AudioSource.Play() の並列処理) 不可能
             */
            getSE.Play();   // Audio Resurce (ItemGet) を再生
        }
        else if (other.gameObject.CompareTag("Bottom")) // 相手のゲームオブジェクトのタグが Bottom (インスペクタから設定) の場合
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // シーンをリロード (リスタート)
        }
    }

    void SetCountText()
    {
        /*
         * Event System オブジェクト : UI 操作を管理, シーン毎に 1 オブジェクト
         * 
         * Canvas オブジェクト : UI 要素 (ボタン, 画像, テキスト等) の表示領域 (親オブジェクト)
         * 
         * Text オブジェクト : テキストをキャンバスに表示 (子オブジェクト)
         */
        countText.text = "GetNum : " + count.ToString();  // テキスト (アイテム取得数) を UI に表示
    }
}
