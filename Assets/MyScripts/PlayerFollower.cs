/*
 * namespace : 名前空間 (クラス等所属先) を定義
 * 
 * using : 名前空間内の要素に接頭辞を省略してアクセス可能
 */
using UnityEngine;

/*
 * private (省略可能) : 同クラスからアクセス可能
 * 
 * protected : 同クラス, サブクラス (継承先) からアクセス可能
 * 
 * public : 全クラスからアクセス可能 (インスペクタから設定可能)
 * 
 * MonoBehaviour クラス : スクリプトをコンポーネントとしてアタッチ可能にするフレームワーク, ゲームオブジェクトを制御する機能等を提供
 */
public class PlayerFollower : MonoBehaviour // PlayerFollower (MonoBehaviour 継承) クラスを public として定義
{
    /*
     * 値型 (Value Type) : データ (値) を保持
     * 
     * 参照型 (Reference Type) : アドレス (参照) を保持
     */
    public GameObject player;   // GameObject 型 (参照型) のフィールド (player) を public として定義 (インスペクタ : Player)
    Vector3 offset; // Vector3 型 (値型) のフィールド (offset) を private として定義

    /*
     * MonoBehaviour.Start() : 全コンポーネントの MonoBehaviour.Awake() 終了後, 本コンポーネントとアタッチされているゲームオブジェクトの両方が有効な場合に 1 回だけ実行されるメソッド
     */
    void Start()
    {
        /*
         * Vector3 型 : (x, y, z)
         * 
         * Transform コンポーネント : ゲームオブジェクトの座標, 回転, スケール, 親子関係を管理, 全ゲームオブジェクトが所持 (インスペクタ : ローカル空間)
         * 
         * 親子関係 : 親オブジェクトが移動, 回転, 拡大縮小 → 子オブジェクトも移動, 回転, 拡大縮小
         * 
         * ローカル空間 (ローカル座標 (transform.localPosition), ローカル回転 (transform.localRotation), ローカルスケール (transform.localScale)) : 親オブジェクト基準
         * 
         * ワールド空間 (ワールド座標 (transform.position), ワールド回転 (transform.rotation), ローカルスケール (transform.localScale)) : シーン基準
         * 
         * 親オブジェクト == シーン → ローカル空間 == ワールド空間
         * 
         * プロパティ : アクセス (クラス外 → メンバ) を制御するメソッド
         * 
         * Component.gameObject{ get; } : 全コンポーネントはプロパティを用いてアタッチされているゲームオブジェクト (参照) を取得可能
         *
         * this.gameObject.transform.position
         * this (省略可能) : 本コンポーネント (参照)
         * gameObject (省略可能) : ゲームオブジェクト (参照)
         * transform : Transform コンポーネント (参照)
         * position : ワールド座標 (値)
         * 本コンポーネントがアタッチされているゲームオブジェクトのワールド座標 (値) を取得
         * 
         * GameObject.transform.position
         * GameObject : ゲームオブジェクト (参照)
         * transform : Transform コンポーネント (参照)
         * position : ワールド座標 (値)
         * ゲームオブジェクトのワールド座標 (値) を取得
         */
        offset = this.transform.position - player.transform.position;   // ゲームオブジェクト間 (Main Camera, Player) の距離 (オフセット) を計算
    }

    /*
     * MonoBehaviour.Update() : 全コンポーネントの MonoBehaviour.Start() 終了後, フレーム (不定, 性能依存) 毎に 1 回だけ実行されるメソッド
     */
    // void Update()
    // {
    //     this.transform.position = player.transform.position + offset;    // ゲームオブジェクト間 (Main Camera, Player) の距離 (オフセット) を保持
    // }

    /*
     * MonoBehaviour.LateUpdate() : 全コンポーネントの MonoBehaviour.Update() 終了毎に 1 回だけ実行されるメソッド
     */
    void LateUpdate()   // Player → Main Camera
    {
        this.transform.position = player.transform.position + offset;   // ゲームオブジェクト間 (Main Camera, Player) の距離 (オフセット) を保持
    }
}
