using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Meiro : MonoBehaviour
{
    /// <summary>横幅</summary>
    public int _field_x;//横幅、棒倒し法のルールとして5以上の奇数。
    /// <summary>縦幅</summary>
    public int _field_z;//縦幅、棒倒し法のルールとして5以上の奇数。
    /// <summary></summary>
    int _row;//横の要素番号
    /// <summary></summary>
    int _column;//縦の要素番号
    /// <summary></summary>
    int _r;//乱数

    GameObject wall;
    GameObject item;
    GameObject goal;
    GameObject bake;
    GameObject generationwall;
    GameObject generationitem;
    GameObject generationgoal;
    NavMeshSurface navmeshsurface;

    // Start is called before the first frame update
    void Start()
    {
        navmeshsurface = GetComponent<NavMeshSurface>();
        Zidou();
        navmeshsurface.BuildNavMesh();
    }
    void Zidou()
    {
        int[,] field = new int[_field_z, _field_x];//ｘ、0が通路、ｚ、1が壁。縦横。入力された幅の二次元配列。
        wall = (GameObject)Resources.Load("Wall");//Resourcesファイル内のWallと名の付くobjectを読み込む。
        item = (GameObject)Resources.Load("item1");
        goal = (GameObject)Resources.Load("Goalgate");
        bake = GameObject.Find("Bake");

        for (_column = 0; _column < _field_z; _column++)//縦幅の数だけループ
        {
            //左右の外壁（1）の生成
            field[_column, 0] = 1;
            field[_column, _field_x - 1] = 1;
        }
        for (_row = 0; _row < _field_x; _row++)//横幅の数だけループ
        {
            //上下の外壁（1）の生成
            field[0, _row] = 1;
            field[_field_z - 1, _row] = 1;
        }
        Zidou1(field);
    }
    void Zidou1(int[,] field)
    {
        for (_column = 2; _column < _field_z - 1; _column += 2)
        {
            for (_row = 2; _row < _field_x - 1; _row += 2)//
            {
                if (_column == 2)
                {
                    _r = Random.Range(1, 13);//ランダムな値（1～12）を与える。３ずつ分けて上下左右が壁かどうかを確認している。
                }
                else
                {
                    _r = Random.Range(4, 13);
                }
                field[_column, _row] = 1;
                if (_r <= 3)
                {
                    if (field[_column - 1, _row] == 0)//上に壁が無ければ
                    {
                        field[_column - 1, _row] = 1;//壁を置く場所として二次元配列をつくる
                    }
                    else if (field[_column - 1, _row] == 1)//壁があったら
                    {
                        _row -= 2; //戻ってやり直す
                    }
                }
                if (_r >= 4 && _r <= 6)
                {
                    if (field[_column + 1, _row] == 0)//下に壁が無ければ
                    {
                        field[_column + 1, _row] = 1;
                    }
                    else if (field[_column + 1, _row] == 1)
                    {
                        _row -= 2;
                    }
                }
                if (_r >= 7 && _r <= 9)
                {
                    if (field[_column, _row - 1] == 0)//左に壁が無ければ
                    {
                        field[_column, _row - 1] = 1;
                    }
                    else if (field[_column, _row - 1] == 1)
                    {
                        _row -= 2;
                    }
                }
                if (_r >= 10)
                {
                    if (field[_column, _row + 1] == 0)//右に壁が無ければ
                    {
                        field[_column, _row + 1] = 1;
                    }
                    else if (field[_column, _row + 1] == 1)
                    {
                        _row -= 2;
                    }
                }
            }
        }
        Zidou2(field);      
    }
    void Zidou2(int[,] field)
    {
        field[0, 1] = 0; //スタート地点（固定）
        field[_field_z - 1, _field_x - 2] = 0;//ゴール地点（固定）
        for (_column = 0; _column < _field_z; _column++) //フィールドの縦幅の分だけループする。
        {
            for (_row = 0; _row < _field_x; _row++) //フィールドの横幅の分だけループする。
            {
                if (field[_column, _row] == 1)//壁なら
                {
                    generationwall = Instantiate(wall, new Vector3(5.0f * _row, 2.5f, 5.0f * _column), Quaternion.identity); //壁を配置する。
                    generationwall.transform.parent = bake.transform;//子オブジェクトとして生成
                }
                else if (field[_column, _row] == 0)
                {
                    //generationitem =
                    Instantiate(item, new Vector3(5.0f * _row, 1.0f, 5.0f * _column), Quaternion.identity);
                }
            }
        }
    }
}
