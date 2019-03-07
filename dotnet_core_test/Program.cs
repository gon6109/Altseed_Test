﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// カメラを用いた描画空間の一部を切り取って描画するサンプルを表示する。
/// </summary>
public class CameraObject2D_Basic
{
    public string Description
    {
        get { return "カメラを用いて描画空間の一部を切り取って描画するサンプルです。"; }
    }

    public string Title
    {
        get { return "カメラの基本"; }
    }
    public string ClassName
    {
        get { return "CameraObject2D_Basic"; }
    }

  
    static void Main(string[] args)
    {
        // Altseedを初期化する。
        asd.Engine.Initialize("CameraObject2D_Basic", 640, 480, new asd.EngineOption());

        // 画像を読み込む。
        var tex0 = asd.Engine.Graphics.CreateTexture2D("test.png");

        // テクスチャを描画するオブジェクトを設定する。
        var obj0 = new asd.TextureObject2D();
        obj0.Texture = tex0;
        obj0.Position = new asd.Vector2DF(10, 10);
        obj0.Scale = new asd.Vector2DF(0.7f, 0.7f);
        asd.Engine.AddObject2D(obj0);

        //画面全体を写すカメラを設定する。(オブジェクトをそのまま描画する。)
        //var entityCamera = new asd.CameraObject2D();
        //entityCamera.Src = new asd.RectI(0, 0, 640, 480);
        //entityCamera.Dst = new asd.RectI(0, 0, 640, 480);
        //asd.Engine.AddObject2D(entityCamera);

        //テクスチャの左上から縦横150ピクセルを切り取って描画するカメラを設定する。
        var camera = new asd.CameraObject2D();
        camera.Src = new asd.RectI(10, 10, 150, 150);
        camera.Dst = new asd.RectI(450, 10, 150, 150);
        asd.Engine.AddObject2D(camera);

        // Altseedのウインドウが閉じられていないか確認する。
        while (asd.Engine.DoEvents())
        {
            // Altseedを更新する。
            asd.Engine.Update();
        }

        // Altseedを終了する。
        asd.Engine.Terminate();
    }
}