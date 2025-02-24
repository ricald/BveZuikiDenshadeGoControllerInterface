namespace Ricald.ZuikiMasconInterface
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// 瑞起製電車でGO!!コントローラーのクラスです。
    /// </summary>
    public class ZuikiMascon
    {
        /// <summary>
        /// ジョイスティックの状態を保持します。
        /// </summary>
        private NativeMethods.JOYINFOEX joyInfo;

        /// <summary>
        /// クラスを初期化します。
        /// </summary>
        public ZuikiMascon()
        {
            this.joyInfo = new NativeMethods.JOYINFOEX();
            this.joyInfo.dwSize = (uint)Marshal.SizeOf(joyInfo);
            this.joyInfo.dwFlags = NativeMethods.JoyFlags.JOY_RETURNALL;
        }

        /// <summary>
        /// 状態を更新します。
        /// </summary>
        public void UpdateStatus()
        {
            // 最初に検出したジョイスティックを固定で取得します。
            int uJoyID = 0;
            NativeMethods.joyGetPosEx(uJoyID, ref this.joyInfo);
        }

        /// <summary>
        /// マスコンの状態を取得します。
        /// </summary>
        public string MasterControllerStatus
        {
            get
            {
                switch (this.joyInfo.dwYpos)
                {
                    case 0:
                        return "EB";
                    case 1280:
                        return "B8";
                    case 4864:
                        return "B7";
                    case 8192:
                        return "B6";
                    case 11776:
                        return "B5";
                    case 15360:
                        return "B4";
                    case 18687:
                        return "B3";
                    case 22271:
                        return "B2";
                    case 25855:
                        return "B1";
                    case 32767:
                        return "N";
                    case 40570:
                        return "P1";
                    case 46811:
                        return "P2";
                    case 52792:
                        return "P3";
                    case 59034:
                        return "P4";
                    case 65535:
                        return "P5";
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// 「Y」ボタンの押下中を示します。
        /// </summary>
        public bool Y
        {
            get
            {
                return (this.joyInfo.dwButtons & (1 << 0)) != 0;
            }
        }

        /// <summary>
        /// 「B」ボタンの押下中を示します。
        /// </summary>
        public bool B
        {
            get
            {
                return (this.joyInfo.dwButtons & (1 << 1)) != 0;
            }
        }

        /// <summary>
        /// 「A」ボタンの押下中を示します。
        /// </summary>
        public bool A
        {
            get
            {
                return (this.joyInfo.dwButtons & (1 << 2)) != 0;
            }
        }

        /// <summary>
        /// 「X」ボタンの押下中を示します。
        /// </summary>
        public bool X
        {
            get
            {
                return (this.joyInfo.dwButtons & (1 << 3)) != 0;
            }
        }

        /// <summary>
        /// 「L」ボタンの押下中を示します。
        /// </summary>
        public bool L
        {
            get
            {
                return (this.joyInfo.dwButtons & (1 << 4)) != 0;
            }
        }

        /// <summary>
        /// 「R」ボタンの押下中を示します。
        /// </summary>
        public bool R
        {
            get
            {
                return (this.joyInfo.dwButtons & (1 << 5)) != 0;
            }
        }

        /// <summary>
        /// 「ZL」ボタンの押下中を示します。
        /// </summary>
        public bool ZL
        {
            get
            {
                return (this.joyInfo.dwButtons & (1 << 6)) != 0;
            }
        }

        /// <summary>
        /// 「ZR」ボタンの押下中を示します。
        /// </summary>
        public bool ZR
        {
            get
            {
                return (this.joyInfo.dwButtons & (1 << 7)) != 0;
            }
        }

        /// <summary>
        /// 「-」ボタンの押下中を示します。
        /// </summary>
        public bool Minus
        {
            get
            {
                return (this.joyInfo.dwButtons & (1 << 8)) != 0;
            }
        }

        /// <summary>
        /// 「+」ボタンの押下中を示します。
        /// </summary>
        public bool Plus
        {
            get
            {
                return (this.joyInfo.dwButtons & (1 << 9)) != 0;
            }
        }

        /// <summary>
        /// 「Home」ボタンの押下中を示します。
        /// </summary>
        public bool Home
        {
            get
            {
                return (this.joyInfo.dwButtons & (1 << 12)) != 0;
            }
        }

        /// <summary>
        /// 「Shutter」ボタンの押下中を示します。
        /// </summary>
        public bool Shutter
        {
            get
            {
                return (this.joyInfo.dwButtons & (1 << 13)) != 0;
            }
        }

        /// <summary>
        /// 「↑」ボタンの押下中を示します。
        /// </summary>
        public bool Up
        {
            get
            {
                return this.joyInfo.dwPOV == 31500 || this.joyInfo.dwPOV == 0 || this.joyInfo.dwPOV == 4500;
            }
        }

        /// <summary>
        /// 「→」ボタンの押下中を示します。
        /// </summary>
        public bool Right
        {
            get
            {
                return this.joyInfo.dwPOV == 4500 || this.joyInfo.dwPOV == 9000 || this.joyInfo.dwPOV == 13500;
            }
        }

        /// <summary>
        /// 「↓」ボタンの押下中を示します。
        /// </summary>
        public bool Down
        {
            get
            {
                return this.joyInfo.dwPOV == 13500 || this.joyInfo.dwPOV == 18000 || this.joyInfo.dwPOV == 22500;
            }
        }

        /// <summary>
        /// 「→」ボタンの押下中を示します。
        /// </summary>
        public bool Left
        {
            get
            {
                return this.joyInfo.dwPOV == 22500 || this.joyInfo.dwPOV == 27000 || this.joyInfo.dwPOV == 31500;
            }
        }

        /// <summary>
        /// Windows API 関数や構造体を呼び出すためのネイティブメソッドを提供するユーティリティクラスです。
        /// </summary>
        private static class NativeMethods
        {
            /// <summary>
            /// 指定されたジョイスティックの現在の状態を取得します。
            /// </summary>
            /// <param name="uJoyID">ジョイスティックのIDを指定します。</param>
            /// <param name="pji">ジョイスティックの状態を格納する JOYINFOEX 構造体へのポインタです。</param>
            /// <returns>関数が成功した場合は JOYERR_NOERROR を返します。エラーが発生した場合はエラーコードを返します。</returns>
            [DllImport("winmm.dll")]
            public static extern int joyGetPosEx(int uJoyID, ref JOYINFOEX pji);

            /// <summary>
            /// ジョイスティックの状態を表す拡張情報を保持する構造体です。
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public struct JOYINFOEX
            {
                /// <summary>
                /// 構造体のサイズ（バイト単位）を表します。
                /// </summary>
                public uint dwSize;

                /// <summary>
                /// ジョイスティックの状態を示すフラグです。
                /// </summary>
                public JoyFlags dwFlags;

                /// <summary>
                /// X軸の現在位置を表します。
                /// </summary>
                public uint dwXpos;

                /// <summary>
                /// Y軸の現在位置を表します。
                /// </summary>
                public uint dwYpos;

                /// <summary>
                /// Z軸の現在位置を表します。
                /// </summary>
                public uint dwZpos;

                /// <summary>
                /// R軸の現在位置を表します。
                /// </summary>
                public uint dwRpos;

                /// <summary>
                /// U軸の現在位置を表します。
                /// </summary>
                public uint dwUpos;

                /// <summary>
                /// V軸の現在位置を表します。
                /// </summary>
                public uint dwVpos;

                /// <summary>
                /// ボタンの状態（ビットフィールド）を表します。
                /// </summary>
                public uint dwButtons;

                /// <summary>
                /// ボタンの数を表します。
                /// </summary>
                public uint dwButtonNumber;

                /// <summary>
                /// POVディレクションコントロールの現在の位置を表します。
                /// </summary>
                public uint dwPOV;

                /// <summary>
                /// 現在のX軸の加速度を表します。
                /// </summary>
                public uint dwXposVelocity;

                /// <summary>
                /// 現在のY軸の加速度を表します。
                /// </summary>
                public uint dwYposVelocity;

                /// <summary>
                /// 現在のZ軸の加速度を表します。
                /// </summary>
                public uint dwZposVelocity;

                /// <summary>
                /// 現在のR軸の加速度を表します。
                /// </summary>
                public int dwRposVelocity;

                /// <summary>
                /// 現在のU軸の加速度を表します。
                /// </summary>
                public int dwUposVelocity;

                /// <summary>
                /// 現在のV軸の加速度を表します。
                /// </summary>
                public int dwVposVelocity;

                /// <summary>
                /// 現在のPOVディレクションコントロールの加速度を表します。
                /// </summary>
                public int dwPOVVelocity;

                /// <summary>
                /// 予約済みです。使用しないでください。
                /// </summary>
                public uint dwReserved1;

                /// <summary>
                /// 予約済みです。使用しないでください。
                /// </summary>
                public uint dwReserved2;
            }

            /// <summary>
            /// ジョイスティックの状態を示すフラグを定義する列挙体です。
            /// </summary>
            [Flags]
            public enum JoyFlags : uint
            {
                /// <summary>
                /// X軸の値を返すフラグ
                /// </summary>
                JOY_RETURNX = 0x1,

                /// <summary>
                /// Y軸の値を返すフラグ
                /// </summary>
                JOY_RETURNY = 0x2,

                /// <summary>
                /// Z軸の値を返すフラグ
                /// </summary>
                JOY_RETURNZ = 0x4,

                /// <summary>
                /// R軸の値を返すフラグ
                /// </summary>
                JOY_RETURNR = 0x8,

                /// <summary>
                /// U軸の値を返すフラグ
                /// </summary>
                JOY_RETURNU = 0x10,

                /// <summary>
                /// V軸の値を返すフラグ
                /// </summary>
                JOY_RETURNV = 0x20,

                /// <summary>
                /// POV (POVディレクションコントロール) の値を返すフラグ
                /// </summary>
                JOY_RETURNPOV = 0x40,

                /// <summary>
                /// ボタンの状態を返すフラグ
                /// </summary>
                JOY_RETURNBUTTONS = 0x80,

                /// <summary>
                /// 生データを返すフラグ
                /// </summary>
                JOY_RETURNRAWDATA = 0x100,

                /// <summary>
                /// POVディレクションコントロールの中立位置が有効かどうかを返すフラグ
                /// </summary>
                JOY_RETURNPOVCTS = 0x200,

                /// <summary>
                /// 中立位置に戻された場合でも値を返すフラグ
                /// </summary>
                JOY_RETURNCENTERED = 0x400,

                /// <summary>
                /// デッドゾーンを使用するフラグ
                /// </summary>
                JOY_USEDEADZONE = 0x800,

                /// <summary>
                /// すべての値を返すフラグ (X, Y, Z, R, U, V, POV, ボタンの状態)
                /// </summary>
                JOY_RETURNALL = JOY_RETURNX | JOY_RETURNY | JOY_RETURNZ | JOY_RETURNR |
                                JOY_RETURNU | JOY_RETURNV | JOY_RETURNPOV | JOY_RETURNBUTTONS,
            }
        }
    }
}