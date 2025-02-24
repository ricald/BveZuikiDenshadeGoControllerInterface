namespace Ricald.ZuikiMasconInterface
{
    using System.Collections.Generic;
    using Mackoy.Bvets;

    /// <summary>
    /// 瑞起製電車でGO!!コントローラー用のInputDeviceクラスです。
    /// </summary>
    public class ZuikiMasconInputDevice : IInputDevice
    {
        /// <summary>マスコン状態をキー、InputEventArgsを値としたコレクションです。</summary>
        private readonly static Dictionary<string, InputEventArgs> MasterControllerStatusToInputEventArgsDictionary = new Dictionary<string, InputEventArgs>
        {
            { "EB", new InputEventArgs(3, -99) },
            { "B8", new InputEventArgs(3, -8) },
            { "B7", new InputEventArgs(3, -7) },
            { "B6", new InputEventArgs(3, -6) },
            { "B5", new InputEventArgs(3, -5) },
            { "B4", new InputEventArgs(3, -4) },
            { "B3", new InputEventArgs(3, -3) },
            { "B2", new InputEventArgs(3, -2) },
            { "B1", new InputEventArgs(3, -1) },
            { "N", new InputEventArgs(3, 0) },
            { "P1", new InputEventArgs(3, 1) },
            { "P2", new InputEventArgs(3, 2) },
            { "P3", new InputEventArgs(3, 3) },
            { "P4", new InputEventArgs(3, 4) },
            { "P5", new InputEventArgs(3, 99) },
        };

        /// <summary>瑞起製電車でGO!!コントローラーのクラスです。</summary>
        private ZuikiMascon zuikiMascon;

        /// <summary>マスコンの状態を保持します。</summary>
        private string masterControllerStatus;

        /// <summary>「Y」ボタンの状態を保持します。</summary>
        private bool y;

        /// <summary>「B」ボタンの状態を保持します。</summary>
        private bool b;

        /// <summary>「A」ボタンの状態を保持します。</summary>
        private bool a;

        /// <summary>「X」ボタンの状態を保持します。</summary>
        private bool x;

        /// <summary>「↑」ボタンの状態を保持します。</summary>
        private bool up;

        /// <summary>「↓」ボタンの状態を保持します。</summary>
        private bool down;

        /// <summary>「-」ボタンの状態を保持します。</summary>
        private bool minus;

        /// <summary>「Home」ボタンの状態を保持します。</summary>
        private bool home;

        /// <summary>レバーサの状態を保持します。</summary>
        private int leverserStatus;

        /// <summary>レバーが動いたときに発生するイベントです。</summary>
        public event InputEventHandler LeverMoved;

        /// <summary>キーが押されたときに発生するイベントです。</summary>
        public event InputEventHandler KeyDown;

        /// <summary>キーが離されたときに発生するイベントです。</summary>
        public event InputEventHandler KeyUp;

        /// <summary>マスコンの状態を設定/取得します。</summary>
        public string MasterControllerStatus
        {
            get
            {
                return this.masterControllerStatus;
            }
            set
            {
                if (this.masterControllerStatus != value)
                {
                    this.masterControllerStatus = value;
                    InputEventArgs eventArgs;
                    if (ZuikiMasconInputDevice.MasterControllerStatusToInputEventArgsDictionary.TryGetValue(value, out eventArgs))
                    {
                        if (this.LeverMoved != null)
                        {
                            this.LeverMoved.Invoke(this, eventArgs);
                        }
                    }
                }
            }
        }

        /// <summary>「Y」ボタンの状態を設定/取得します。</summary>
        public bool Y
        {
            get
            {
                return this.y;
            }
            set
            {
                if (this.y != value)
                {
                    this.y = value;

                    // 定速運転
                    var eventArgs = new InputEventArgs(-1, 2);

                    if (value)
                    {
                        if (this.KeyDown != null)
                        {
                            this.KeyDown.Invoke(this, eventArgs);
                        }
                    }
                    else
                    {
                        if (this.KeyUp != null)
                        {
                            this.KeyUp.Invoke(this, eventArgs);
                        }
                    }
                }
            }
        }

        /// <summary>「B」ボタンの状態を設定/取得します。</summary>
        public bool B
        {
            get
            {
                return this.b;
            }
            set
            {
                if (this.b != value)
                {
                    this.b = value;

                    // 電笛
                    var eventArgs = new InputEventArgs(-1, 0);

                    if (value)
                    {
                        if (this.KeyDown != null)
                        {
                            this.KeyDown.Invoke(this, eventArgs);
                        }
                    }
                    else
                    {
                        if (this.KeyUp != null)
                        {
                            this.KeyUp.Invoke(this, eventArgs);
                        }
                    }
                }
            }
        }

        /// <summary>「A」ボタンの状態を設定/取得します。</summary>
        public bool A
        {
            get
            {
                return this.a;
            }
            set
            {
                if (this.a != value)
                {
                    this.a = value;

                    // 空笛
                    var eventArgs = new InputEventArgs(-1, 1);

                    if (value)
                    {
                        if (this.KeyDown != null)
                        {
                            this.KeyDown.Invoke(this, eventArgs);
                        }
                    }
                    else
                    {
                        if (this.KeyUp != null)
                        {
                            this.KeyUp.Invoke(this, eventArgs);
                        }
                    }
                }
            }
        }

        /// <summary>「X」ボタンの状態を設定/取得します。</summary>
        public bool X
        {
            get
            {
                return this.x;
            }
            set
            {
                if (this.x != value)
                {
                    this.x = value;

                    // EBリセット
                    var eventArgs = new InputEventArgs(-2, 2);

                    if (value)
                    {
                        if (this.KeyDown != null)
                        {
                            this.KeyDown.Invoke(this, eventArgs);
                        }
                    }
                    else
                    {
                        if (this.KeyUp != null)
                        {
                            this.KeyUp.Invoke(this, eventArgs);
                        }
                    }
                }
            }
        }

        /// <summary>「↑」ボタンの状態を設定/取得します。</summary>
        public bool Up
        {
            get
            {
                return this.up;
            }
            set
            {
                if (this.up != value)
                {
                    this.up = value;

                    if (value)
                    {
                        this.LeverserStatus++;
                    }
                }
            }
        }

        /// <summary>「↓」ボタンの状態を設定/取得します。</summary>
        public bool Down
        {
            get
            {
                return this.down;
            }
            set
            {
                if (this.down != value)
                {
                    this.down = value;

                    if (value)
                    {
                        this.LeverserStatus--;
                    }
                }
            }
        }

        /// <summary>「-」ボタンの状態を設定/取得します。</summary>
        public bool Minus
        {
            get
            {
                return this.minus;
            }
            set
            {
                if (this.minus != value)
                {
                    this.minus = value;

                    // 時刻表表示切り替え
                    var eventArgs = new InputEventArgs(-3, 8);

                    if (value)
                    {
                        if (this.KeyDown != null)
                        {
                            this.KeyDown.Invoke(this, eventArgs);
                        }
                    }
                    else
                    {
                        if (this.KeyUp != null)
                        {
                            this.KeyUp.Invoke(this, eventArgs);
                        }
                    }
                }
            }
        }

        /// <summary>「Home」ボタンの状態を設定/取得します。</summary>
        public bool Home
        {
            get
            {
                return this.home;
            }
            set
            {
                if (this.home != value)
                {
                    this.home = value;

                    // ATS復帰
                    var eventArgs = new InputEventArgs(-2, 3);

                    if (value)
                    {
                        if (this.KeyDown != null)
                        {
                            this.KeyDown.Invoke(this, eventArgs);
                        }
                    }
                    else
                    {
                        if (this.KeyUp != null)
                        {
                            this.KeyUp.Invoke(this, eventArgs);
                        }
                    }
                }
            }
        }

        /// <summary>レバーサの状態を設定/取得します。</summary>
        public int LeverserStatus
        {
            get
            {
                return this.leverserStatus;
            }
            set
            {
                if (this.leverserStatus != value &&
                    -1 <= value && value <= 1)
                {
                    this.leverserStatus = value;
                    if (this.LeverMoved != null)
                    {
                        this.LeverMoved.Invoke(this, new InputEventArgs(0, value));
                    }
                }
            }
        }

        /// <summary>
        /// 構成を設定するためのウィンドウを指定したオーナーウィンドウのモーダルダイアログとして表示します。
        /// </summary>
        /// <param name="owner">オーナーウィンドウとして使用するウィンドウのインターフェース</param>
        public void Configure(System.Windows.Forms.IWin32Window owner)
        {
        }

        /// <summary>
        /// ロード処理を行います。
        /// </summary>
        /// <param name="settingsPath">設定フォルダへのパス</param>
        public void Load(string settingsPath)
        {
            this.zuikiMascon = new ZuikiMascon();
        }

        /// <summary>
        /// 軸の範囲を設定します。
        /// </summary>
        /// <param name="ranges">軸の範囲を表す整数の2次元配列。各要素は、[最小値, 最大値]の形式で指定します。</param>
        public void SetAxisRanges(int[][] ranges) { }

        /// <summary>
        /// フレーム毎の処理を行います。デバイスの状態を更新し、状態に応じたイベントを発生させます。
        /// </summary>
        public void Tick()
        {
            if (this.zuikiMascon == null)
            {
                return;
            }

            this.zuikiMascon.UpdateStatus();
            this.MasterControllerStatus = this.zuikiMascon.MasterControllerStatus;
            this.Y = this.zuikiMascon.Y;
            this.B = this.zuikiMascon.B;
            this.A = this.zuikiMascon.A;
            this.X = this.zuikiMascon.X;
            this.Up = this.zuikiMascon.Up;
            this.Down = this.zuikiMascon.Down;
            this.Minus = this.zuikiMascon.Minus;
            this.Home = this.zuikiMascon.Home;
        }

        /// <summary>
        /// オブジェクトのリソースを解放します。
        /// </summary>
        public void Dispose()
        {
            this.zuikiMascon = null;
        }
    }
}