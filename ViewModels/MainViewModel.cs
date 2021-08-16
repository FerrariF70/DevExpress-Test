using DevExpress.Mvvm;
using DevExpress.Xpf.Grid;
using DXApplication1.Export;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Test.ViewModels;

namespace DXApplication1.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private IExport _exportService;
        public DelegateCommand<object> SelectedRowCommand { get; private set; }
        public AsyncCommand ExportToCsvCommand { get; private set; }
        public AsyncCommand ExportToTxtCommand { get; private set; }
        private IList BufferList { get; set; }
        public ObservableCollection<CarModel> ListOfCars
        {
            get => GetValue<ObservableCollection<CarModel>>();
            private set => SetValue(value);
        }

        public MainViewModel()
        {
            InitializeList();
            InitializeCommand();
        }

        public MainViewModel(IExport exportService)
        {
            Application.Current.Resources["DI IExport"] = exportService;
        }

        /// <summary>
        /// Инициализация комманд
        /// </summary>
        private void InitializeCommand()
        {
            SelectedRowCommand = new DelegateCommand<object>(SelectedRow, true);
            ExportToCsvCommand = new AsyncCommand(ExportToCSVFile, CanExportFile);
            ExportToTxtCommand = new AsyncCommand(ExportToTxtFile, CanExportFile);
        }

        /// <summary>
        /// Инициализация данных
        /// </summary>
        private void InitializeList()
        {
            ListOfCars = new ObservableCollection<CarModel>
            {
                new CarModel(1, "Ferrari F12", new DateTime(2016, 1, 25).ToString("dd/MM/yyyy"), 250000),
                new CarModel(2, "Honda Civic", new DateTime(1998, 2, 16).ToString("dd/MM/yyyy"), 20000),
                new CarModel(3, "Chevrolet", new DateTime(2020, 10, 10).ToString("dd/MM/yyyy"), 18000),
                new CarModel(4, "Ford", new DateTime(2018, 5, 7).ToString("dd/MM/yyyy"), 24100),
                new CarModel(5, "Lada", new DateTime(2008, 3, 15).ToString("dd/MM/yyyy"), 7890),
                new CarModel(6, "Suzuki", new DateTime(1987, 4, 12).ToString("dd/MM/yyyy"), 45500),
                new CarModel(7, "Mercedec", new DateTime(2003, 9, 24).ToString("dd/MM/yyyy"), 10000),
                new CarModel(8, "B.M.W", new DateTime(2001, 12, 5).ToString("dd/MM/yyyy"), 13789)
            };
        }

        /// <summary>
        /// Метод принимающий список из выбранных элементов
        /// </summary>
        private void SelectedRow(object obj)
        {
            BufferList = obj as IList;
        }

        /// <summary>
        /// Экспорт списка в формат CSV
        /// </summary>
        private async Task ExportToCSVFile()
        {
            _exportService = GetDIService();
            MessageBox.Show(await _exportService.ExportFile($"{Guid.NewGuid()}.csv", BufferList));
        }

        /// <summary>
        /// Экспорт списка в формат TXT
        /// </summary>
        private async Task ExportToTxtFile()
        {
            _exportService = GetDIService();
            MessageBox.Show(await _exportService.ExportFile($"{Guid.NewGuid()}.txt", BufferList));
        }

        private IExport GetDIService()
        {
            return Application.Current.Resources["DI IExport"] as IExport;
        }

        private bool CanExportFile
        {
            get
            {
                if (BufferList != null && BufferList.Count > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}