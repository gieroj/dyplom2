﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace FaceMouse
{
    public partial class Form2 : Form
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event
            (MouseEventType dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);

        bool flaga_trzymaj = false;

        Form1 myParent = null;
        public Form2(Form1 myParent)
        {
            InitializeComponent();
            this.myParent = myParent;
            button1.MouseEnter += new EventHandler(button1_MouseEnter);
            button2.MouseEnter += new EventHandler(button2_MouseEnter);
            button3.MouseEnter += new EventHandler(button3_MouseEnter);
            button4.MouseEnter += new EventHandler(button4_MouseEnter);
            this.TopMost = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           // button4.MouseLeave
        }
        

        public enum MouseEventType : int
        {
            LeftDown = 0x02,
            LeftUp = 0x04,
            RightDown = 0x08,
            RightUp = 0x10
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            SetCursorPos(myParent.stary_curent_x, myParent.stary_curent_y);
            myParent.zamknij_okno_myszy();
            mouse_event(MouseEventType.LeftDown, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            mouse_event(MouseEventType.LeftUp, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            myParent.CurrTime = DateTime.Now;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            myParent.zamknij_okno_myszy();
            mouse_event(MouseEventType.RightDown, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            mouse_event(MouseEventType.RightUp, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            myParent.CurrTime = DateTime.Now;
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            if (flaga_trzymaj == false)
            {
                mouse_event(MouseEventType.RightDown, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                flaga_trzymaj = true;
                button3.Text = "Upuść";
            }
            else
            {
                mouse_event(MouseEventType.RightUp, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                flaga_trzymaj = false;
                button3.Text = "Trzymaj Lewy";
            }
            myParent.zamknij_okno_myszy();
            myParent.CurrTime = DateTime.Now;
        }

        public void zwolnij()
        {
            if(flaga_trzymaj==true)
            {
                mouse_event(MouseEventType.RightUp, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                flaga_trzymaj = false;
                button3.Text = "Trzymaj Lewy";
            }
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            myParent.zamknij_okno_myszy();
            myParent.CurrTime = DateTime.Now;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
