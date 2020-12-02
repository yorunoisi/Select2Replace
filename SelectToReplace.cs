using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class SelectToReplace : EditorWindow {

    private const float WINDOWSIZE_W = 500.0f;          //ウィンドウサイズ横幅
    private const float WINDOWSIZE_H = 300.0f;          //ウィンドウサイズ縦幅
    //string Name="";
    Vector2 scrollPosition = new Vector2(0, 0);
    bool AddMode;
    bool AddChild;
    Object BaseObject;
    string PrefabPath;
    [SerializeField]
    List<GameObject> TargetObject = new List<GameObject>();

    [MenuItem("Utils/Select2Replace")]
    static void Open() {

        var window = EditorWindow.GetWindow<SelectToReplace>();
        //ウィンドウサイズ設定(minとmaxを=しているのはウィンドウサイズを固定するため)
        window.minSize = new Vector2(WINDOWSIZE_W, WINDOWSIZE_H);
        
    }
    private void OnGUI() {
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
        //Name = EditorGUILayout.TextField("Name", Name);

        AddMode = EditorGUILayout.Toggle("置換後オブジェクトを残す",AddMode);
        AddChild = EditorGUILayout.Toggle("オブジェクトを子として追加",AddChild);

        if (GUILayout.Button("選択中のオブジェクトを取得")) {
            TargetObject.Clear();
            //Debug.Log("FindObject");
            foreach (GameObject go in Selection.gameObjects) {
                //Debug.Log(go.name);
                TargetObject.Add(go);
                //EditorGUILayout.ObjectField(TargetObject);
            }
             
        }
        if (GUILayout.Button("置換")) {
            //PrefabPath = AssetDatabase.GetAssetPath(BaseObject);
            int i, len = TargetObject.Count;
            for (i = 0; i < len; ++i) {
                if (AddChild == true) { AddMode = true; }
                //Debug.Log(TargetObject[i].name);
                GameObject Parent = TargetObject[i].transform.parent.gameObject;

                GameObject ReplacedObject = PrefabUtility.InstantiatePrefab(BaseObject) as GameObject;
                //ReplacedObject = BaseObject;

                ReplacedObject.GetComponent<Transform>().position = TargetObject[i].GetComponent<Transform>().position;
                ReplacedObject.GetComponent<Transform>().rotation = TargetObject[i].GetComponent<Transform>().rotation;
                ReplacedObject.GetComponent<Transform>().localScale = TargetObject[i].GetComponent<Transform>().localScale;

                if (AddChild == true) { Parent = TargetObject[i]; }

                ReplacedObject.transform.parent = Parent.transform;

                if (AddMode == false) { Object.DestroyImmediate(TargetObject[i]); }

                Undo.RegisterCreatedObjectUndo(ReplacedObject, "Replace");
            }
            TargetObject.Clear();

        }

        EditorGUILayout.LabelField("コピー元");

        BaseObject = EditorGUILayout.ObjectField(BaseObject, typeof(Object), true) as Object;
        
        EditorGUILayout.LabelField("選択中のコピー先");
        // 自身のSerializedObjectを取得
        var so = new SerializedObject(this);

        so.Update();

        // 第二引数をtrueにしたPropertyFieldで描画
        EditorGUILayout.PropertyField(so.FindProperty("TargetObject"), true);

        so.ApplyModifiedProperties();


        EditorGUILayout.EndScrollView();
        /*
        int i, len = TargetObject.Count;

        // 折りたたみ表示
        EditorGUILayout.Foldout(true, "選択");
        // リスト表示
        for (i = 0; i < len; ++i) {
            //Debug.Log(TargetObject[i].name);
            TargetObject[i] = EditorGUILayout.ObjectField(TargetObject[i], typeof(GameObject), true) as GameObject;
        }*/
        
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
