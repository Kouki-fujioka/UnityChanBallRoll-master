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
public class Rotator : MonoBehaviour    // Rotator (MonoBehaviour 継承) クラスを public として定義
{
    /*
     * MonoBehaviour.Start() : 全コンポーネントの MonoBehaviour.Awake() 終了後, 本コンポーネントとアタッチされているゲームオブジェクトの両方が有効な場合に 1 回だけ実行されるメソッド
     */
    void Start()
    {
        
    }

    /*
     * MonoBehaviour.Update() : 全コンポーネントの MonoBehaviour.Start() 終了後, フレーム (不定, 性能依存) 毎に 1 回だけ実行されるメソッド
     */
    void Update()
    {
        /*
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
         * Vector3 型 : (x, y, z)
         * 
         * new 演算子 : クラス, 構造体, 配列等のインスタンス (新規オブジェクト) を生成
         * 
         * プロパティ : アクセス (クラス外 → メンバ) を制御するメソッド
         * 
         * Component.gameObject{ get; } : 全コンポーネントはプロパティを用いてアタッチされているゲームオブジェクト (参照) を取得可能
         * 
         * this.gameObject.transform.Rotate(Vector3 eulers, Space relativeTo = Space.Self)
         * this (省略可能) : 本コンポーネント (参照)
         * gameObject (省略可能) : ゲームオブジェクト (参照)
         * transform : Transform コンポーネント (参照)
         * eulers : 回転量 (値)
         * relativeTo : 使用空間 (値)
         * relativeTo == Space.Self → ローカル空間 (子オブジェクト == 本コンポーネント, 親オブジェクト == ゲームオブジェクト)
         * relativeTo == Space.World → ワールド空間
         * 本コンポーネントがアタッチされているゲームオブジェクトに回転量 (値) を付与
         * 
         * Time.deltaTime : 前フレームからの経過時間 (秒)
         * 
         * 60FPS (フレーム / 秒) の場合
         * Time.deltaTime = 1 / 60 ≒ 0.01667 (無次元数)
         * Vector3(15, 30, 45) * 0.01667 ≒ (0.25, 0.5, 0.75) (角度 / フレーム)
         * (0.25, 0.5, 0.75) * 60 = (15, 30, 45) (角度 / 秒)
         * 
         * 30FPS (フレーム / 秒) の場合
         * Time.deltaTime = 1 / 30 ≒ 0.03333 (無次元数)
         * Vector3(15, 30, 45) * 0.03333 ≒ (0.5, 1, 1.5) (角度 / フレーム)
         * (0.25, 0.5, 0.75) * 30 = (15, 30, 45) (角度 / 秒)
         */
        this.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);    // ゲームオブジェクト (Item) を 1 秒間に (15, 30, 45) 度回転
    }
}
