/*
 * namespace : 名前空間 (クラス等所属先) を定義
 * 
 * using : 名前空間内の要素に接頭辞を省略してアクセス可能
 */
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * private (省略可能) : 同クラスからアクセス可能
 * 
 * protected : 同クラス, サブクラス (継承先) からアクセス可能
 * 
 * public : 全クラスからアクセス可能 (インスペクタから設定可能)
 * 
 * MonoBehaviour クラス : スクリプトをコンポーネントとしてアタッチ可能にするフレームワーク, ゲームオブジェクトを制御する機能等を提供
 */
public class GoalChecker : MonoBehaviour    // GoalChecker (MonoBehaviour 継承) クラスを public として定義
{
    /*
     * 値型 (Value Type) : データ (値) を保持
     * 
     * 参照型 (Reference Type) : アドレス (参照) を保持
     */
    public GameObject unitychan;    // GameObject 型 (参照型) のフィールド (unitychan) を public として定義 (インスペクタ : SD_unitychan_humanoid)
    public AudioSource gameBgm; // AudioSource 型 (参照型) のフィールド (gameBgm) を public として定義 (インスペクタ : neuson_06 (Audio Source))
    public AudioSource goalBgm; // AudioSource 型 (参照型) のフィールド (goalBgm) を public として定義 (インスペクタ : electro (Audio Source))
    public GameObject retryButton;  // GameObject 型 (参照型) のフィールド (retryButton) を public として定義 (インスペクタ : Button)
    public Button buttonImage;  // Button 型 (参照型) のフィールド (buttonImage) を public として定義 (インスペクタ : Button (Button))
    public TextMeshProUGUI buttonText;  // TextMeshProUGUI 型 (参照型) のフィールド (buttonText) を public として定義 (インスペクタ : Text (TMP) (Text Mesh Pro UGUI))

    /*
     * MonoBehaviour.Start() : 全コンポーネントの MonoBehaviour.Awake() 終了後, 本コンポーネントとアタッチされているゲームオブジェクトの両方が有効な場合に 1 回だけ実行されるメソッド
     */
    void Start()
    {
        /*
         * GameObject.SetActive(bool value)
         * value : ブール値 (true, false)
         * ゲームオブジェクトのアクティブ状態を設定
         */
        retryButton.SetActive(false);   // ゲームオブジェクト (Button) を無効化
    }

    /*
     * MonoBehaviour.Update() : 全コンポーネントの MonoBehaviour.Start() 終了後, フレーム (不定, 性能依存) 毎に 1 回だけ実行されるメソッド
     */
    void Update()
    {
        
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
         * Collider.gameObject.GetComponent<T>()
         * Collider : Collider コンポーネント (参照)
         * gameObject (省略可能) : ゲームオブジェクト (参照)
         * Collider コンポーネントがアタッチされているゲームオブジェクトの T コンポーネント (参照) を取得 (取得不可能 → null)
         * 
         * Rigidbody コンポーネント : ゲームオブジェクトに物理特性を追加
         */
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;  // 相手のゲームオブジェクト (Player) の Rigidbody コンポーネントを取得 → 物理特性を無効化
        /*
         * GameObject.transform.LookAt(Transform target)
         * GameObject : ゲームオブジェクト (参照)
         * transform : Transform コンポーネント (参照)
         * target : 注視対象 (参照)
         * ゲームオブジェクトを注視対象 (参照) の方向に回転
         * 
         * Camera.main.transform : ゲームオブジェクト (タグ : MainCamera) の Transform コンポーネント (参照)
         */
        unitychan.transform.LookAt(Camera.main.transform);  // ゲームオブジェクト (SD_unitychan_humanoid) をゲームオブジェクト (Main Camera) の方向に回転
        /*
         * Animator コンポーネント : ゲームオブジェクトのアニメーションを管理 (Animator Controller 使用)
         * 
         * Animator.SetTrigger(string name) : トリガ型パラメータ (name) を 1 回だけ有効化
         */
        unitychan.GetComponent<Animator>().SetTrigger("Goal");  // ゲームオブジェクト (SD_unitychan_humanoid) の Animator コンポーネントを取得 → トリガ型パラメータ (Goal) を有効化
        /*
         * AudioSource コンポーネント : ゲームオブジェクトにオーディオ再生機能を追加
         * 
         * AudioSource.Stop() ; Audio Resurce を停止
         */
        gameBgm.Stop(); // Audio Resurce (neuson_06) を停止
        /*
         * AudioSource.Play()
         * Audio Resurce を再生
         * 重複再生 (AudioSource.Play() の並列処理) 不可能
         */
        goalBgm.Play(); // Audio Resurce (electro) を再生
        retryButton.SetActive(true);    // ゲームオブジェクト (Button) を有効化
        /*
         * Event System オブジェクト : UI 操作を管理, シーン毎に 1 オブジェクト
         * 
         * Canvas オブジェクト : UI 要素 (ボタン, 画像, テキスト等) の表示領域 (親オブジェクト)
         * 
         * Button オブジェクト : ボタンをキャンバスに表示 (子オブジェクト)
         * 
         * Image オブジェクト : 画像をキャンバスに表示 (子オブジェクト)
         */
        buttonImage.GetComponent<Image>().enabled = true;   // ゲームオブジェクト (Button) の Image コンポーネントを取得 → 有効化
        /*
         * Text オブジェクト : テキストをキャンバスに表示 (子オブジェクト)
         */
        buttonText.text = "RETRY";  // テキスト (RETRY) を UI に表示
    }

    public void RetryStage()    // ゲームオブジェクト (Button) がクリックされた場合に 1 回だけ実行されるメソッド (インスペクタ (onClick) : GoalChecker.RetryStage())
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // シーンをリロード (リスタート)
    }
}
