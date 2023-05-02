/* UserInterface.cs
 * Author: Calvin Beechner
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.PuzzleTrainer
{
    /// <summary>
    /// UserInterface class. Used for the display.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// A const int giving the number of rows in the grid.
        /// </summary>
        private const int _rows = 5;

        /// <summary>
        /// A const int giving the number of columns in the grid.
        /// </summary>
        private const int _columns = 11;

        /// <summary>
        /// A (int, int)[] giving the locations within the grid of the panels containing Labels.
        /// </summary>
        private static readonly (int, int)[] _labelLocations = new (int, int)[6] { (0, 8), (2, 10), (4, 8), (4, 2), (2, 0), (0, 2) };

        /// <summary>
        /// A (int,int){} giving the locations within the grid of the panels containing Buttons.
        /// </summary>
        private static readonly (int, int)[] _nodeLocations = new (int, int)[7] { (2, 5), (0, 7), (2, 9), (4, 7), (4, 3), (2, 1), (0, 3) };

        /// <summary>
        /// A (int,int)[] giving the locations within the grid of the panels containing lines along their main diagonals.
        /// </summary>
        private static readonly (int, int)[] _mainDiagonalLocatoins = new (int, int)[4] { (1, 4), (1, 8), (3, 2), (3, 6) };

        /// <summary>
        /// A (int,int)[] giving the locations within the grid of panels containing lines along their off diagonals.
        /// </summary>
        private static readonly (int, int)[] _offDiagonalLocatoins = new (int, int)[4] { (1, 2), (1, 6), (3, 4), (3, 8) };

        /// <summary>
        /// A (int,int)[] giving the locations within the grid of the panels containing horizontal lines.
        /// </summary>
        private static readonly (int, int)[] _horizontalLineLocatoins = new (int, int)[12] { (0, 4), (0, 5), (0, 6), (2, 2), (2, 3), (2, 4), (2, 6), (2, 7), (2, 8), (4, 4), (4, 5), (4, 6) };

        /// <summary>
        /// A Pen giving the pen to use in drawing the lines connecting the buttons.
        /// </summary>
        private static readonly Pen _pen = new Pen(Color.Black, 2);

        /// <summary>
        /// An int giving the font size in pixels to use for the Buttons and Labels.
        /// </summary>
        private const int _fontSize = 20;

        /// <summary>
        /// A Font giving the font to use for the Buttons and Labels.
        /// </summary>
        private static readonly Font _font = new Font(FontFamily.GenericSansSerif, _fontSize, GraphicsUnit.Pixel);

        /// <summary>
        /// A Size giving the size of each Panel.
        /// </summary>
        private static readonly Size _panelSize = new Size(_fontSize * 2, _fontSize * 3);

        /// <summary>
        /// A Button[] to contain the Buttons on the form.
        /// </summary>
        private readonly Button[] _buttons = new Button[_nodeLocations.Length];

        /// <summary>
        /// A Dictionary<Configuration, int> storing the distance information.
        /// </summary>
        private static readonly Dictionary<Configuration, int> _distances = Puzzle.Distances();

        /// <summary>
        /// A Configuration giving the current configuration of the puzzle.
        /// </summary>
        private Configuration _currentConfiguration;

        /// <summary>
        /// A Stack<Configuration> giving the history of configurations in the current (partial) solution.
        /// </summary>
        private Stack<Configuration> _history = new Stack<Configuration>();

        /// <summary>
        /// An int indicating which puzzle node is currently empty.
        /// </summary>
        private int _emptyNode;

        /// <summary>
        /// An int giving the number of moves in an optimal solution of the puzzle.
        /// </summary>
        private int _optimal;

        /// <summary>
        /// Diables all buttons. 1/10 additional methods.
        /// </summary>
        private void DisableAllButtons() 
        {
            for (int i = 0; i < _buttons.Length; i++) //5
            {
                _buttons[i].Enabled = false;
            }
        }

        /// <summary>
        /// Enables buttons adjacent to the empty node. 2/10 additionall methods.
        /// </summary>
        private void EnableAdjacentButtons()
        {
            foreach (int i in Puzzle.AdjacentPuzzleNodes(_emptyNode))
            {
                _buttons[i].Enabled = true;
            }
        }

        /// <summary>
        /// Acts as steps 2 through 7 for 6.4.4. 3/10 additional methods.
        /// </summary>
        /// <param name="temp">The configuration of the part being changed.</param>
        private void StepsTwoThroughSeven(Configuration temp)
        {
            _buttons[_emptyNode].Text = _buttons[temp.EmptyNode].Text; //2
            _buttons[temp.EmptyNode].Text = ""; //3
            _emptyNode = temp.EmptyNode; //4
            DisableAllButtons(); //5
            EnableAdjacentButtons();
            _currentConfiguration = temp; //6
            uxToolStripTextBoxNum.Text = _history.Count().ToString(); //7
        }

        /// <summary>
        /// Message displayed at the end of the game. 4/10 additional methods.
        /// </summary>
        private void EndOfGameMessage()
        {
            MessageBox.Show("You solved the puzzle in " + uxToolStripTextBoxNum.Text + " moves.\nThe optimal solution was " + _optimal.ToString() + " moves.");
        }

        /// <summary>
        /// Checks if the game has ended and if so the end game message is displayed. 5/10 additional methods.
        /// </summary>
        private void EndofGameCheck()
        {
            if (_distances[_currentConfiguration] == 0)
            {
                EndOfGameMessage();
            }
        }

        /// <summary>
        /// Makes a move during the solution phase. 6/10 additional methods.
        /// </summary>
        /// <param name="temp">The configurartion of the new move being made.</param>
        private void MakeAMove(Configuration temp)
        {
            _history.Push(_currentConfiguration);
            StepsTwoThroughSeven(temp);
            uxUndoToolStripMenuItem.Enabled = true;
            EndofGameCheck();
        }

        /// <summary>
        /// Handles what happens when a node is clicked during the setup phase. 7/10 additional methods.
        /// </summary>
        /// <param name="buttonClicked"></param>
        private void SetupPhase(Button buttonClicked)
        {
            buttonClicked.Text = uxToolStripTextBoxNum.Text;
            if (Convert.ToInt16(buttonClicked.Text) < _labelLocations.Length)
            {
                uxToolStripTextBoxNum.Text = (Convert.ToInt16(uxToolStripTextBoxNum.Text) + 1).ToString();
                buttonClicked.Enabled = false;
            }
            else
            {
                uxToolStripTextBoxPlace.Text = "Moves:";
                uxToolStripTextBoxNum.Text = "0";
                int[] temp = new int[_buttons.Length];
                for (int i = 0; i < _buttons.Length; i++)
                {
                    if (_buttons[i].Text == "")
                    {
                        temp[i] = 0;
                        _emptyNode = i;
                    }
                    else
                    {
                        temp[i] = Convert.ToInt16(_buttons[i].Text);
                    }
                }
                _currentConfiguration = new Configuration(temp);
                DisableAllButtons();
                EnableAdjacentButtons();
                uxRestartToolStripMenuItem.Enabled = true;
                _optimal = _distances[_currentConfiguration];
                EndofGameCheck();
            }
        }

        /// <summary>
        /// Handles what happens when a node is clicked during the solution phase. 8/10 additional methods.
        /// </summary>
        /// <param name="buttonClicked"></param>
        private void SolutionPhase(Button buttonClicked)
        {
            int nameClicked = Convert.ToInt16(buttonClicked.Name);
            Configuration temp = new Configuration(_currentConfiguration, nameClicked);
            if (_distances[temp] >= _distances[_currentConfiguration]) //if suboptimal
            {
                DialogResult dialogResult = MessageBox.Show("This move is suboptimal. Do you really want to make it?", "Suboptimal Move", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) //if the user still wants to do a suboptimal move
                {
                    MakeAMove(temp);
                }
            }
            else
            {
                MakeAMove(temp);
            }
        }

        /// <summary>
        /// Sets up the FlowLayoutPanels, Panels, Labels, and Buttons for the display. 9/10 additional methods.
        /// </summary>
        private void SetupDisplay()
        {
            for (int i = 0; i < _rows; i++) //Add FlowLayoutPanels
            {
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.AutoSize = true;
                flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                flowLayoutPanel.WrapContents = false;
                flowLayoutPanel.Margin = new Padding(0);
                uxFlowLayoutPanel1.Controls.Add(flowLayoutPanel);
                for (int j = 0; j < _columns; j++) //Add Panels
                {
                    Panel panel = new Panel();
                    panel.Size = _panelSize;
                    panel.Margin = new Padding(0);
                    flowLayoutPanel.Controls.Add(panel);
                }
            }
            for (int i = 0; i < _labelLocations.Length; i++) //Add Labels
            {
                System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                label.Text = (i + 1).ToString();
                label.Font = _font;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                label.Dock = DockStyle.Fill;
                uxFlowLayoutPanel1.Controls[_labelLocations[i].Item1].Controls[_labelLocations[i].Item2].Controls.Add(label);
            }
            for (int i = 0; i < _buttons.Length; i++)
            {
                Button button = new Button();
                button.Font = _font;
                button.Dock = DockStyle.Fill;
                button.Name = i.ToString();
                button.Click += NodeClick;
                _buttons[i] = button;
                uxFlowLayoutPanel1.Controls[_nodeLocations[i].Item1].Controls[_nodeLocations[i].Item2].Controls.Add(button);
            }
        }

        /// <summary>
        /// Determines if the puzzle is in setup phase or not. 10/10 additional methods.
        /// </summary>
        /// <param name="button">The button used to determine the puzzle's phase.</param>
        /// <returns>Returns a bool representing whether the puzzle is in setup phase or not.</returns>
        private bool IsInSetupPhase(Button button)
        {
            if (button.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Event handler for the "New Puzzle" menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newPuzzleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uxUndoToolStripMenuItem.Enabled = false;
            uxRestartToolStripMenuItem.Enabled = false;
            uxToolStripTextBoxNum.Text = "1";
            uxToolStripTextBoxPlace.Text = "Place:";
            while (_history.Count > 0)
            {
                _history.Pop();
            }
            foreach (Button b in _buttons)
            {
                b.Text = "";
                b.Enabled = true;
            }
        }

        /// <summary>
        /// Evenet handler for the "Undo" menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuration goal = _history.Pop(); //1
            StepsTwoThroughSeven(goal); //2-7
            if (_history.Count() == 0) //8
            {
                uxUndoToolStripMenuItem.Enabled = false;
            }
        }

        /// <summary>
        /// Event handler for the "Restart" menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxRestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (uxUndoToolStripMenuItem.Enabled == true)
            {
                undoToolStripMenuItem_Click(sender, e);
            }
            EndofGameCheck();
        }
        
        /// <summary>
        /// Event handler for the buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeClick(object sender, EventArgs e) //sender refers to the button clicked
        {
            Button buttonClicked = (Button)sender;
            if (IsInSetupPhase(buttonClicked)) //the puzzle is in setup phase.
            {
                SetupPhase(buttonClicked);
            }
            else //the puzzle is in solution phase.
            {
                SolutionPhase(buttonClicked);
            }
        }
        
        /// <summary>
        /// Paint event handler to draw along a Control's main diagonal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainDiagonalPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(_pen, 0, 0, _panelSize.Width, _panelSize.Height);
        }

        /// <summary>
        /// Paint event handler to draw along a Control's off diagonal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OffDiagonalPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(_pen, _panelSize.Width, 0, 0, _panelSize.Height);
        }

        /// <summary>
        /// Paint event handler to draw along a Control's main diagonal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HorizontalPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(_pen, 0, _panelSize.Height/2, _panelSize.Width, _panelSize.Height/2);
        }

        /// <summary>
        /// Adds paint event handlers to the Panels.
        /// </summary>
        /// <param name="paint"></param>
        /// <param name="locations"></param>
        private void AddPaint(PaintEventHandler paint, (int, int)[] locations)
        {
            foreach ((int, int) panel in locations)
            {
                uxFlowLayoutPanel1.Controls[panel.Item1].Controls[panel.Item2].Paint += paint;
            }
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
            SetupDisplay();
            AddPaint(MainDiagonalPaint, _mainDiagonalLocatoins);
            AddPaint(OffDiagonalPaint, _offDiagonalLocatoins);
            AddPaint(HorizontalPaint, _horizontalLineLocatoins);
        }

    }
}
