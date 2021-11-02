/*
 * Created by SharpDevelop.
 * User: Microsan84
 * Date: 2017-03-30
 * Time: 10:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;


namespace Microsan
{
	/// <summary>
	/// Description of SelectionRectangleHelper.
	/// </summary>
	public class SelectionRectangle
	{
		public Boolean bHaveMouse;
		public Point ptOriginal = new Point();
		public Point ptLast = new Point();
		public Control ctrl;
		public Color LineColor; 
		
		public SelectionRectangle(Control ctrl, Color lineColor)
		{
			this.ctrl = ctrl;
            LineColor = lineColor;
		}
		
		// Called when the left mouse button is pressed. 
		public void MyMouseDown( MouseEventArgs e )
		{
			if (e.Button != MouseButtons.Left) return;
			
			// Make a note that we "have the mouse".
			bHaveMouse = true;
			// Store the "starting point" for this rubber-band rectangle.
			ptOriginal.X = e.X;
			ptOriginal.Y = e.Y;
			// Special value lets us know that no previous
			// rectangle needs to be erased.
			ptLast.X = -1;
			ptLast.Y = -1;
			
			
		}
		
		// Convert and normalize the points and draw the reversible frame.
		public void MyDrawReversibleRectangle( Point p1, Point p2 )
		{
			Rectangle rc = new Rectangle();
			
			// Convert the points to screen coordinates.
			p1 = ctrl.PointToScreen( p1 );
			p2 = ctrl.PointToScreen( p2 );
			// Normalize the rectangle.
			if( p1.X < p2.X )
			{
				rc.X = p1.X;
				rc.Width = p2.X - p1.X;
			}
			else
			{
				rc.X = p2.X;
				rc.Width = p1.X - p2.X;
			}
			if( p1.Y < p2.Y )
			{
				rc.Y = p1.Y;
				rc.Height = p2.Y - p1.Y;
			}
			else
			{
				rc.Y = p2.Y;
				rc.Height = p1.Y - p2.Y;
			}
			// Draw the reversible frame.
			Rectangle rcOuter = Rectangle.Inflate(rc, 1, 1);
			;
			ControlPaint.DrawSelectionFrame(ctrl.CreateGraphics(), true, rcOuter, rc, Color.Black);//.DrawReversibleFrame( rc, LineColor, FrameStyle.Dashed );
		}
		
		// Called when the left mouse button is released.
		public void MyMouseUp( MouseEventArgs e )
		{
			// Set internal flag to know we no longer "have the mouse".
			bHaveMouse = false;
			// If we have drawn previously, draw again in that spot
			// to remove the lines.
			if( ptLast.X != -1 )
			{
				Point ptCurrent = new Point( e.X, e.Y );
				MyDrawReversibleRectangle( ptOriginal, ptLast );
			}
			// Set flags to know that there is no "previous" line to reverse.
			ptLast.X = -1;
			ptLast.Y = -1;
			ptOriginal.X = -1;
			ptOriginal.Y = -1;
		}
		
		// Called when the mouse is moved.
		public void MyMouseMove( MouseEventArgs e )
		{
			//if (e.Button != MouseButtons.Left) return;
			
			// If we "have the mouse", then we draw our lines.
			if (!bHaveMouse) return;
			
			Point ptCurrent = new Point( e.X, e.Y );
			
			
			// If we have drawn previously, draw again in
			// that spot to remove the lines.
			if( ptLast.X != -1 )
			{
				MyDrawReversibleRectangle( ptOriginal, ptLast );
			}
			// Update last point.
			ptLast = ptCurrent;
			// Draw new lines.
			MyDrawReversibleRectangle( ptOriginal, ptCurrent );
			
		}
	}
}
