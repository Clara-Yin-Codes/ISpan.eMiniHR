public class DraggableHelper
{
	private Control _target; // 被控制的物件
	private Control _boundary; // 父物件
	private Point _mouseDownPos; // 位置紀錄
	private bool _isDragging = false; // 移動註記
	private int _step; // 設定拖曳精準度（可調整）
	private Action<Point> _onPositionChanged; // 可選：位置改變時要執行的邏輯

	public DraggableHelper(Control target, Control boundary, int step = 5, Action<Point> onPositionChanged = null)
	{
		_target = target;
		_boundary = boundary;
		_step = step;
		_onPositionChanged = onPositionChanged;

		_target.MouseDown += Target_MouseDown;
		_target.MouseMove += Target_MouseMove;
		_target.MouseUp += Target_MouseUp;
	}

	/// <summary>
	/// 點下事件
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void Target_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			_isDragging = true;
			_mouseDownPos = e.Location;
			_target.Capture = true;
		}
	}

	/// <summary>
	/// 移動中事件
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void Target_MouseMove(object sender, MouseEventArgs e)
	{
		if (_isDragging && e.Button == MouseButtons.Left)
		{
			int offsetX = e.X - _mouseDownPos.X;
			int offsetY = e.Y - _mouseDownPos.Y;

			if (Math.Abs(offsetX) >= _step || Math.Abs(offsetY) >= _step)
			{
				int moveX = (offsetX / _step) * _step;
				int moveY = (offsetY / _step) * _step;

				Point newPos = _target.Location;
				newPos.X += moveX;
				newPos.Y += moveY;

				// 限制位置在範圍內
				newPos.X = Math.Max(-_target.Width + 20, Math.Min(newPos.X, _boundary.Width - 10));
				newPos.Y = Math.Max(-_target.Height + 20, Math.Min(newPos.Y, _boundary.Height - 10));

				_target.Location = newPos;
				_mouseDownPos = e.Location;

				_onPositionChanged?.Invoke(_target.Location); // 可選：回傳位移後位置
			}
		}
	}

	/// <summary>
	/// 結束事件
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void Target_MouseUp(object sender, MouseEventArgs e)
	{
		if (_isDragging)
		{
			_isDragging = false;
			_target.Capture = false;
		}
	}

	//private void PicEmpImg_MouseDown(object sender, MouseEventArgs e)
	//{
	//	if (e.Button == MouseButtons.Left)
	//	{
	//		_isDragging = true;
	//		_mouseDownPos = e.Location;
	//		picEmpImg.Capture = true;
	//	}
	//}

	//private void PicEmpImg_MouseMove(object sender, MouseEventArgs e)
	//{
	//	if (_isDragging && e.Button == MouseButtons.Left)
	//	{
	//		// 設定拖曳精準度（可調整）
	//		int step = 5;

	//		// 計算相對偏移量
	//		int offsetX = e.X - _mouseDownPos.X;
	//		int offsetY = e.Y - _mouseDownPos.Y;
	//		// 判斷是否超過一步距離（才移動）
	//		if (Math.Abs(offsetX) >= step || Math.Abs(offsetY) >= step)
	//		{
	//			// 四捨五入到最接近的 step 值
	//			int moveX = (offsetX / step) * step;
	//			int moveY = (offsetY / step) * step;

	//			// 新位置
	//			Point newPos = picEmpImg.Location;
	//			newPos.X += moveX;
	//			newPos.Y += moveY;

	//			// 限制不可整張圖片都超出 Panel（可依照你上面的需求搭配限制）
	//			newPos.X = Math.Max(-picEmpImg.Width + 20, Math.Min(newPos.X, pnlImg.Width - 10));
	//			newPos.Y = Math.Max(-picEmpImg.Height + 20, Math.Min(newPos.Y, pnlImg.Height - 10));

	//			// 更新圖片位置
	//			picEmpImg.Location = newPos;

	//			// 重設起始點（避免累加誤差）
	//			_mouseDownPos = e.Location;
	//		}
	//	}
	//}

	//private void PicEmpImg_MouseUp(object sender, MouseEventArgs e)
	//{
	//	if (_isDragging)
	//	{
	//		_isDragging = false;
	//		_justDragged = true;
	//		//DebugImageState(picEmpImg); // 圖片拖移錯誤處理
	//		picEmpImg.Capture = false;

	//		SaveImgToCurrent(picEmpImg.Location); // 儲存位置
	//	}

	//	// 用 Timer 清掉 _justDragged（避免一直阻擋載圖）
	//	if (_dragResetTimer == null)
	//	{
	//		_dragResetTimer = new Timer();
	//		_dragResetTimer.Interval = 300;
	//		_dragResetTimer.Tick += (s, ea) =>
	//		{
	//			_justDragged = false;
	//			_dragResetTimer.Stop();
	//		};
	//	}
	//	_dragResetTimer.Start();
	//}
}
