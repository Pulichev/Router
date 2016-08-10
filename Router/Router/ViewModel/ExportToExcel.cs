using System.Linq;
using Router.Model;
using MOIExcel = Microsoft.Office.Interop.Excel;
using System.Collections.ObjectModel;

namespace Router.ViewModel
{
	class ExportToExcel
	{
		private ObservableCollection<SuperModel> _tableElements;
		private MOIExcel.Application excelApp;
		private MOIExcel.Worksheet excelWorkSheet;
		private MOIExcel.Workbook excelWorkBook;

		public ExportToExcel(ObservableCollection<SuperModel> tableElements)
		{
			_tableElements = tableElements;
			excelApp = new Microsoft.Office.Interop.Excel.Application();
			excelWorkBook = excelApp.Workbooks.Add(System.Reflection.Missing.Value);
			excelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet) excelWorkBook.Sheets[1];
		}

		public void ExecuteExport()
		{
			FormattingColumns();

			for (int i = 0; i < _tableElements.Count(); i++)
			{
				excelWorkSheet.Cells[i + 2, 1] = _tableElements[i].Id;
				excelWorkSheet.Cells[i + 2, 2] = _tableElements[i].Location;
				excelWorkSheet.Cells[i + 2, 3] = _tableElements[i].TerritoryType;
				excelWorkSheet.Cells[i + 2, 4] = _tableElements[i].Company;
				excelWorkSheet.Cells[i + 2, 5] = _tableElements[i].Head;
				excelWorkSheet.Cells[i + 2, 6] = _tableElements[i].Phone;
				excelWorkSheet.Cells[i + 2, 7] = _tableElements[i].EMail;
				excelWorkSheet.Cells[i + 2, 8] = _tableElements[i].State;
			}

			excelApp.Visible = true;
			excelApp.UserControl = true;
		}

		public void FormattingColumns()
		{
			excelWorkSheet.Columns[1].ColumnWidth = 6;
			excelWorkSheet.Columns[2].ColumnWidth = 20;
			excelWorkSheet.Columns[3].ColumnWidth = 15;
			excelWorkSheet.Columns[4].ColumnWidth = 22;
			excelWorkSheet.Columns[5].ColumnWidth = 28;
			excelWorkSheet.Columns[6].ColumnWidth = 15;
			excelWorkSheet.Columns[7].ColumnWidth = 25;
			excelWorkSheet.Columns[8].ColumnWidth = 15;

			excelWorkSheet.get_Range((MOIExcel.Range)excelWorkSheet.Cells[1, 1], (MOIExcel.Range)excelWorkSheet.Cells[_tableElements.Count(), 8]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
			excelWorkSheet.get_Range((MOIExcel.Range) excelWorkSheet.Cells[1, 1],
				(MOIExcel.Range)excelWorkSheet.Cells[_tableElements.Count(), 8]).WrapText = true;

			excelWorkSheet.ListObjects.Add(MOIExcel.XlListObjectSourceType.xlSrcRange,
				excelWorkSheet.get_Range((MOIExcel.Range) excelWorkSheet.Cells[1, 1],
					(MOIExcel.Range)excelWorkSheet.Cells[_tableElements.Count(), 8]), MOIExcel.XlYesNoGuess.xlYes).Name =
				"Таблица1";
			excelWorkSheet.get_Range("Таблица1").Select();
			excelWorkSheet.ListObjects["Таблица1"].TableStyle = "TableStyleDark2";

			excelWorkSheet.Cells[1, 1] = "Id";
			excelWorkSheet.Cells[1, 2] = "Расположен";
			excelWorkSheet.Cells[1, 3] = "Тип территории";
			excelWorkSheet.Cells[1, 4] = "Компания";
			excelWorkSheet.Cells[1, 5] = "Руководитель";
			excelWorkSheet.Cells[1, 6] = "Телефон(раб)";
			excelWorkSheet.Cells[1, 7] = "E-Mail";
			excelWorkSheet.Cells[1, 8] = "Статус";
		}
	}
}
