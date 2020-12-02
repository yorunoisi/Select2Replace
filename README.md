# Select2Replace
Unity用置換拡張
オブジェクトのTransformと親子維持したまま置換するエディタ拡張です。<br>
Unityエディタ拡張の練習もかねて作ったのでコピペが結構あります。<br>
Unityでオブジェクトまとめて置換したり追加したいよって人向け。<br>


# 使い方
1. メニューバーのUtil/Select2Replaceをクリックでウィンドウが開きます。
2. ヒエラルキーで置換したいオブジェクトを選択した状態でウィンドウ内の[**選択中のオブジェクトを取得**]ボタンを押すと
選択されたオブジェクトが**選択中のコピー先**内の**TargetObject**に追加されます。
3. **コピー元**に置き換えたいPrefabやゲームオブジェクトを設定します。
4. [**置換**]ボタンを押して置換を実行します。

# オプション
- **置換後オブジェクトを残す**<br>
選択されたオブジェクトの座標にコピー元のオブジェクトを設置した後選択されたオブジェクトを残します。(その処理はもはや置換じゃなくない？)
- **オブジェクトを子として追加**<br>
選択されたオブジェクトの子としてコピー元のオブジェクトを追加します。(だから、それもう置換じゃないって!)<br>
この機能を使うときは置換後オブジェクトを残すにチェックを入れてください。
