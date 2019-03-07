using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseComponent;

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


    [System.STAThread]
    static void Main(string[] args)
    {
        // Altseedを初期化する。
        asd.Engine.Initialize("CameraObject2D_Basic", 640, 800, new asd.EngineOption());

        // 画像を読み込む。
        var tex0 = asd.Engine.Graphics.CreateTexture2D("test.png");

        // テクスチャを描画するオブジェクトを設定する。
        var font = asd.Engine.Graphics.CreateDynamicFont("", 15, new asd.Color(255, 0, 0, 255), 1, new asd.Color(255, 255, 255, 255));

        int i = 0;
        foreach (Animation.Easing item in Enum.GetValues(typeof(Animation.Easing)))
        {
            // 文字描画オブジェクトを生成する。
            var obj = new asd.TextObject2D();
            // 描画に使うフォントを設定する。
            obj.Font = font;
            // 描画位置を指定する。
            obj.Position = new asd.Vector2DF(50, 50 + i * 18);
            // 描画する文字列を指定する。
            obj.Text = item.ToString();

            var component = new AnimationComponent();
            var anm = new Animation();
            anm.Alpha(0, 0, 1);
            anm.Sleep(180 * i);
            anm.Alpha(0, 255, 60, item);
            anm.MoveTo(obj.Position + new asd.Vector2DF(400, 0), 70, item);
            anm.RotateTo(360, 40, item);
            anm.MoveTo(obj.Position, 70, item);
            component.AddAnimation(obj, anm);
            var anm2 = new Animation();
            anm2.Sleep(180 * i + 61);
            anm2.ScaleTo(new asd.Vector2DF(3,3), 70, item);
            anm2.Sleep(40);
            anm2.ScaleTo(new asd.Vector2DF(1,1), 70, item);
            component.AddAnimation(obj, anm2, 1);
            obj.AddComponent(component, "animation");

            // 文字描画オブジェクトのインスタンスをエンジンへ追加する。
            asd.Engine.AddObject2D(obj);

            i++;
        }

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