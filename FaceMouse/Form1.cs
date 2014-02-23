using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using TouchlessLib;
using System.Diagnostics;
using System.Runtime.InteropServices;

using Hotkeys;

namespace FaceMouse
{
    public partial class Form1 : Form
    {
        private Hotkeys.GlobalHotkey ghk;

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
        int start_x = 0;
        int start_y = 0;
        double curent_x = 0;
        double curent_y = 0;
        public int stary_curent_x;
        public int stary_curent_y;
        double waga_x = 10;
        double waga_y = 10;
        int martwa_strefa = 4;
        bool flaga_mark=true;
        bool flaga_mouse = false;
        Marker Mark;
        public DateTime CurrTime = DateTime.Now;
        int czas_reakcji=4;
        public bool flaga_okna_myszy = false;
        int ilosc_markerow = 0;

        private TouchlessMgr _touchlessMgr;
        private static DateTime _dtFrameLast;
        private static int _nFrameCount;
        private static Point _markerCenter;
        private static float _markerRadius;
        private static Marker _markerSelected;
        private static bool _fAddingMarker;
        private static int _addedMarkerCount;
     //   private static bool _fChangingMode;
        private static bool _fUpdatingMarkerUI;
        private static Image _latestFrame;
        private static bool _drawSelectionAdornment;
        Form2 myForm;


        public Form1()
        {
            InitializeComponent();
            myForm = new Form2(this);
            myForm.Show();
            myForm.Visible = false;
            ghk = new Hotkeys.GlobalHotkey(Constants.CTRL , Keys.Q, this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Make a new TouchlessMgr for library interaction
            _touchlessMgr = new TouchlessMgr();

            // Initialize some members
            _dtFrameLast = DateTime.Now;
            _fAddingMarker = false;
           // _fChangingMode = false;
       //     _markerSelected = null;
            _addedMarkerCount = 0;

            // Put the app in camera mode and select the first camera by default

            foreach (Camera cam in _touchlessMgr.Cameras)
                comboBoxCameras.Items.Add(cam);

            if (comboBoxCameras.Items.Count > 0)
            {
                comboBoxCameras.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Oops, this requires a Webcam. Please connect a Webcam and try again.");
                Environment.Exit(0);
            }

       //     _fChangingMode = true;
            pictureBoxDisplay.MouseDown += new MouseEventHandler(pictureBoxDisplay_MouseDown);
            pictureBoxDisplay.MouseMove += new MouseEventHandler(pictureBoxDisplay_MouseMove);
            pictureBoxDisplay.MouseUp += new MouseEventHandler(pictureBoxDisplay_MouseUp);


            if (ghk.Register())
                labelMarkerData.Text="Hotkey registered.";
            else
                labelMarkerData.Text="Hotkey failed to register";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dispose of the TouchlessMgr object
            if (_touchlessMgr != null)
            {
                _touchlessMgr.Dispose();
                _touchlessMgr = null;
            }
        }

        

        private void drawLatestImage(object sender, PaintEventArgs e)
        {
            if (_latestFrame != null)
            {
                // Draw the latest image from the active camera
                e.Graphics.DrawImage(_latestFrame, 0, 0, pictureBoxDisplay.Width, pictureBoxDisplay.Height);

                
                // Draw the selection adornment
                if (_drawSelectionAdornment)
                {
                    Pen pen = new Pen(Brushes.Red, 1);
                    e.Graphics.DrawEllipse(pen, _markerCenter.X - _markerRadius, _markerCenter.Y - _markerRadius, 2 * _markerRadius, 2 * _markerRadius);
                }

                
            }

        }

        /// <summary>
        /// Event handler from the active camera
        /// </summary>
        public void OnImageCaptured(object sender, CameraEventArgs args)
        {
            // Calculate FPS (only update the display once every second)
            _nFrameCount++;
            double milliseconds = (DateTime.Now.Ticks - _dtFrameLast.Ticks) / TimeSpan.TicksPerMillisecond;


            // Save the latest image for drawing
            if (!_fAddingMarker)
            {
                // Cause display update
                _latestFrame = args.Image;
                pictureBoxDisplay.Invalidate();
            }
        }

        /// <summary>
        /// Event Handler from the selected marker in the Marker Mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnSelectedMarkerUpdate(object sender, MarkerEventArgs args)
        {
            this.BeginInvoke(new Action<MarkerEventData>(UpdateMarkerDataInUI), new object[] { args.EventData });
        }

        /// <summary>
        /// Event Handler from the selected marker in the Marker Mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnSelectedMouseUpdate(object sender, MarkerEventArgs args)
        {
            this.BeginInvoke(new Action<MarkerEventData>(UpdateMouseDataInUI), new object[] { args.EventData });
        }

        private void UpdateMarkerDataInUI(MarkerEventData data)
        {
            if (data.Present)
            {
                labelMarkerData.Text =
                      "Center X:  " + data.X + "\n"
                    + "Center Y:  " + data.Y + "\n"
                    + "DX:        " + data.DX + "\n"
                    + "DY:        " + data.DY + "\n"
                    + "Area:      " + data.Area + "\n"
                    + "Left:      " + data.Bounds.Left + "\n"
                    + "Right:     " + data.Bounds.Right + "\n"
                    + "Top:       " + data.Bounds.Top + "\n"
                    + "Bottom:    " + data.Bounds.Bottom + "\n";
            }
            else
                labelMarkerData.Text = "Marker not present";
        }
        public double zwrot_x = SystemInformation.PrimaryMonitorSize.Width / 320;
        public double zwrot_y = SystemInformation.PrimaryMonitorSize.Height / 320;
        private void UpdateMouseDataInUI(MarkerEventData data)
        {
            if (ilosc_markerow != _touchlessMgr.Markers.Count)
            {
                start_x = _touchlessMgr.Markers[_touchlessMgr.Markers.Count -1].CurrentData.X;
                start_y = _touchlessMgr.Markers[_touchlessMgr.Markers.Count -1].CurrentData.Y;
                curent_x = MousePosition.X;
                curent_y = MousePosition.Y;
                ilosc_markerow = _touchlessMgr.Markers.Count;

                
            }
            int poz_x = 0;
            int poz_y = 0;

            poz_x = _touchlessMgr.Markers[0].CurrentData.X;
            poz_y = _touchlessMgr.Markers[0].CurrentData.Y;

            if (flaga_mouse == true)
            {

                poz_x = Mark.CurrentData.X;
                poz_y = Mark.CurrentData.Y;
                if (start_x > poz_x + martwa_strefa || start_x < poz_x - martwa_strefa)
                {
                    if (curent_x < SystemInformation.PrimaryMonitorSize.Width )
                    {
                        curent_x += (start_x - poz_x) * waga_x / 10;
                        if (Convert.ToInt32(curent_x) <= 10)
                            curent_x = 10;
                        SetCursorPos(Convert.ToInt32(curent_x), Convert.ToInt32(curent_y));
                        CurrTime = DateTime.Now;
                    }
                    else
                    {
                        curent_x -= 5;
                    }
                }
                

                if (start_y > poz_y + martwa_strefa || start_y < poz_y - martwa_strefa)
                {
                    if (curent_y < SystemInformation.PrimaryMonitorSize.Height - 20)
                    {
                        curent_y -= (start_y - poz_y) * waga_y / 10;
                        if (Convert.ToInt32(curent_y) <= 20)
                            curent_y = 10;
                        SetCursorPos(Convert.ToInt32(curent_x), Convert.ToInt32(curent_y));
                        CurrTime = DateTime.Now;
                    }
                    else
                    {
                        curent_y -= 5;
                    }
                } 

                if ((DateTime.Now.Second - CurrTime.Second) > czas_reakcji)
                {
                    if (flaga_okna_myszy == false)
                        stary_curent_x = Convert.ToInt32(curent_x);
                        stary_curent_y = Convert.ToInt32(curent_y);
                        myForm.Location = new Point(Convert.ToInt32(curent_x)-100, Convert.ToInt32(curent_y)-100);
                        myForm.Visible=true;
                }
            }

            
            
            labelMarkerData.Text = 
                  "pozycja przeliczona\t: x "+Convert.ToString(poz_x * zwrot_x) + "  y" + Convert.ToString(poz_y * zwrot_y) + "\n"
                + "pozycja obrazowa\t: x " + poz_x.ToString() + "  y" + poz_x.ToString() + "\n"
                + "pozycja startowa\t: x " + start_x + "  y" + start_y + "\n"
                + "pozycja obecna \t: x " + curent_x + "  y" + curent_y + "\n"
                + "pozycja kursora \t: x " + MousePosition.X + "  y" + MousePosition.Y + "\n"
                + "czas ruchu\t:" + CurrTime.Second+"\n"
                + "roznica czasow \t:"+(DateTime.Now.Second - CurrTime.Second)+"\n"
                + (poz_x - start_x) + "  " + (start_y - poz_y )+"\n"
                + ilosc_markerow ;


                //  this.Cursor = new Cursor(Cursor.Current.Handle);
                //  Cursor.Position = new Point(poz_x*zwrot_x, poz_y*zwrot_y);
                //   Cursor.Clip = new Rectangle(this.Location, this.Size);
            
        }


        private void checkBoxMarkerHighlight_CheckedChanged(object sender, EventArgs e)
        {
            if (flaga_mark)
                return;

            Mark.Highlight = checkBoxMarkerHighlight.Checked;
        }

        private void buttonMarkerAdd_Click(object sender, EventArgs e)
        {
            if (flaga_mark == false && _touchlessMgr.MarkerCount>0)
            {
                Mark = null;
                _touchlessMgr.RemoveMarker(0);
                ilosc_markerow = 0;
                flaga_mark = true;
                buttonMarkerAdd.Text = "Dodaj Marker";

                CurrTime = DateTime.Now;
                flaga_mouse = false;

                btMouse.Text = "Przechwytywanie myszy";

                //_fAddingMarker = false;

                checkBoxMarkerHighlight.Enabled = false;
                checkBoxMarkerSmoothing.Enabled = false;
                
            }
            else
            {
                _fAddingMarker = true;
                buttonMarkerAdd.Text ="Usun Marker" ;

                _fUpdatingMarkerUI = true;
                //   checkBoxMarkerHighlight.Checked = _markerSelected.Highlight;
                //   checkBoxMarkerSmoothing.Checked = _markerSelected.SmoothingEnabled;
                //    _fUpdatingMarkerUI = false;
                flaga_mark = false;

                checkBoxMarkerHighlight.Enabled = true;
                checkBoxMarkerSmoothing.Enabled = true;
            }

        }

        private void numericUpDownMarkerThresh_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCameras_DropDown(object sender, EventArgs e)
        {
            // Refresh the list of available cameras
            comboBoxCameras.Items.Clear();
            foreach (Camera cam in _touchlessMgr.Cameras)
                comboBoxCameras.Items.Add(cam);
        }

        private void comboBoxCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Early return if we've selected the current camera
            if (_touchlessMgr.CurrentCamera == (Camera)comboBoxCameras.SelectedItem)
                return;

            // Trash the old camera
            if (_touchlessMgr.CurrentCamera != null)
            {
                _touchlessMgr.CurrentCamera.OnImageCaptured -= new EventHandler<CameraEventArgs>(OnImageCaptured);
                _touchlessMgr.CurrentCamera.Dispose();
                _touchlessMgr.CurrentCamera = null;
                comboBoxCameras.Text = "Select A Camera";
                pictureBoxDisplay.Paint -= new PaintEventHandler(drawLatestImage);
            }

            if (comboBoxCameras.SelectedIndex < 0)
            {
                pictureBoxDisplay.Paint -= new PaintEventHandler(drawLatestImage);
                comboBoxCameras.Text = "Select A Camera";
                return;
            }

            try
            {
                Camera c = (Camera)comboBoxCameras.SelectedItem;
                c.OnImageCaptured += new EventHandler<CameraEventArgs>(OnImageCaptured);
                _touchlessMgr.CurrentCamera = c;
                _dtFrameLast = DateTime.Now;

               
                // TODO: allow immediate access to the demo if we already have some markers set?
                // radioButtonDemo.Enabled = false;

                pictureBoxDisplay.Paint += new PaintEventHandler(drawLatestImage);
            }
            catch (Exception ex)
            {
                comboBoxCameras.Text = "Select A Camera";
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBoxDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            // If we are adding a marker - get the marker center on mouse down
            if (_fAddingMarker)
            {
                _markerCenter = e.Location;
                _markerRadius = 0;

                // Begin drawing the selection adornment
                _drawSelectionAdornment = true;
            }
        }

        private void pictureBoxDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            // If we are adding a marker - get the marker radius on mouse up, add the marker
            if (_fAddingMarker)
            {
                
                int dx = e.X - _markerCenter.X;
                int dy = e.Y - _markerCenter.Y;
                _markerRadius = (float)Math.Sqrt(dx * dx + dy * dy);
                // Adjust for the image/display scaling (assumes proportional scaling)
                _markerCenter.X = (_markerCenter.X * _latestFrame.Width) / pictureBoxDisplay.Width;
                _markerCenter.Y = (_markerCenter.Y * _latestFrame.Height) / pictureBoxDisplay.Height;
                _markerRadius = (_markerRadius * _latestFrame.Height) / pictureBoxDisplay.Height;
                // Add the marker
                Mark = _touchlessMgr.AddMarker("Marker #" + ++_addedMarkerCount, (Bitmap)_latestFrame, _markerCenter, _markerRadius);
                

                // Restore the app to its normal state and clear the selection area adorment
                _fAddingMarker = false;
                _markerCenter = new Point();
                _drawSelectionAdornment = false;
                pictureBoxDisplay.Image = new Bitmap(pictureBoxDisplay.Width, pictureBoxDisplay.Height);

                if (_markerSelected != null)
                {
                   // labelMarkerData.Text = _markerSelected.ToString();
                    _markerSelected.OnChange -= new EventHandler<MarkerEventArgs>(OnSelectedMouseUpdate);
                }
              //  else
                {
                    labelMarkerData.Text = "Marker pobrał za małą gamme kolorów \nProsze sprubować ponownie dodać marker";
                    _markerSelected = (Marker)Mark;
                    _markerSelected.OnChange += new EventHandler<MarkerEventArgs>(OnSelectedMouseUpdate);
                    numericUpDownMarkerThresh.Value = _markerSelected.Threshold;
                    checkBoxMarkerHighlight.Checked = Mark.Highlight;
                    checkBoxMarkerSmoothing.Checked = Mark.SmoothingEnabled;
                }
                
            }
        }

        private void pictureBoxDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // If the user is selecting a marker, draw a circle of their selection as a selection adornment
            if (_fAddingMarker && !_markerCenter.IsEmpty)
            {
                // Get the current radius
                int dx = e.X - _markerCenter.X;
                int dy = e.Y - _markerCenter.Y;
                _markerRadius = (float)Math.Sqrt(dx * dx + dy * dy);

                // Cause display update
                pictureBoxDisplay.Invalidate();
            }
        }

        private void buttonCameraProperties_Click(object sender, EventArgs e)
        {
            if (comboBoxCameras.SelectedIndex < 0)
                return;

            Camera c = (Camera)comboBoxCameras.SelectedItem;
            c.ShowPropertiesDialog(this.Handle);
        }

        private void checkBoxMarkerSmoothing_CheckedChanged(object sender, EventArgs e)
        {
            if (flaga_mark)
                return;

            Mark.SmoothingEnabled = checkBoxMarkerSmoothing.Checked;
        }          

        private void btMouse_Click(object sender, EventArgs e)
        {
            CurrTime = DateTime.Now;

            if (flaga_mouse == false)
            {
                btMouse.Text = "Zwolnij mysze";
                if (checkAmini.Checked == true)
                    this.WindowState = FormWindowState.Minimized;
            }
            else
            {

                btMouse.Text = "Przechwytywanie myszy";

                myForm.zwolnij();
                
            }
            flaga_mouse = !flaga_mouse;

            

        }



        private void numericUpDownMarkerThresh_ValueChanged_1(object sender, EventArgs e)
        {
              Mark.Threshold = (int)numericUpDownMarkerThresh.Value;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            martwa_strefa = (int)numericUpDown4.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            waga_x = (int)numericUpDown2.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            waga_y = (int)numericUpDown3.Value;
        }

       
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            czas_reakcji = (int)numericUpDown1.Value;
        }
        public void zamknij_okno_myszy()
        {
            myForm.Visible = false;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Hotkeys.Constants.WM_HOTKEY_MSG_ID)
            {
                CurrTime = DateTime.Now;

                if (flaga_mouse == false)
                {
                    btMouse.Text = "Zwolnij mysze";
                }
                else
                {
                    btMouse.Text = "Przechwytywanie myszy";
                    myForm.zwolnij();
                    this.WindowState = FormWindowState.Normal;
                }
                flaga_mouse = !flaga_mouse;
            }
            base.WndProc(ref m);
        }

        private void pictureBoxDisplay_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
