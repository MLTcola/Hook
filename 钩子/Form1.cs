using CSharpKeyboardHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 钩子
{
    public partial class Form1 : Form
    {
        private KeyboardHookLib _keyboardHook = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //安装勾子

            _keyboardHook = new KeyboardHookLib();

            _keyboardHook.InstallHook(this.KeyPress);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //取消勾子

            if (_keyboardHook != null) _keyboardHook.UninstallHook();
        }

        /// <summary>

        /// 客户端键盘捕捉事件.

        /// </summary>

        /// <param name="hookStruct">由Hook程序发送的按键信息</param>

        /// <param name="handle">是否拦截</param>
        /// 
        public void KeyPress(KeyboardHookLib.HookStruct hookStruct, out bool handle)
        {

            handle = false; //预设不拦截任何键



            if (hookStruct.vkCode == 91) // 截获左win(开始菜单键)
            {

                handle = true;

            }



            if (hookStruct.vkCode == 92)// 截获右win
            {

                handle = true;

            }



            //截获Ctrl+Esc

            if (hookStruct.vkCode == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Control)
            {

                handle = true;

            }



            //截获alt+f4

            if (hookStruct.vkCode == (int)Keys.F4 && (int)Control.ModifierKeys == (int)Keys.Alt)
            {

                handle = true;

            }



            //截获alt+tab

            if (hookStruct.vkCode == (int)Keys.Tab && (int)Control.ModifierKeys == (int)Keys.Alt)
            {

                handle = true;

            }



            //截获F1

            if (hookStruct.vkCode == (int)Keys.F1)
            {

                handle = true;

            }



            //截获Ctrl+Alt+Delete

            if ((int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Alt + (int)Keys.Delete)
            {

                handle = true;

            }



            //如果键A~Z

            if (hookStruct.vkCode >= (int)Keys.A && hookStruct.vkCode <= (int)Keys.Z)
            {

                //挡掉G键，想要挡掉哪些键就把下面的G换成那个要挡掉的键，同理可以挡多个

                if (hookStruct.vkCode == (int)Keys.G)

                    hookStruct.vkCode = (int)Keys.None; //设键为0



                handle = true;

            }



            Keys key = (Keys)hookStruct.vkCode;

            label1.Text = "你按下:" + (key == Keys.None ? "" : key.ToString());

            textBox2.AppendText( (key == Keys.None ? "" : key.ToString()));

        }
    }
}
