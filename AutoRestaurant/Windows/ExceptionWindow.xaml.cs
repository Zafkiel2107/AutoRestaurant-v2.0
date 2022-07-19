using AutoRestaurant.Models.ControlModels;
using System;
using System.Windows;

namespace AutoRestaurant.Windows
{
    public partial class ExceptionWindow : Window
    {
        private ExceptionLoggerControl Logger { get; set; }
        public ExceptionWindow(Exception ex)
        {
            InitializeComponent();

            Logger = new ExceptionLoggerControl();
            Logger.CreateLog(ex);

            exceptionMessage.Text = ex.Message;
        }
    }
}
