using QuickTester.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using QuickTester.Questions;

// Документацию по шаблону элемента "Основная страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=234237

namespace QuickTester
{
    /// <summary>
    /// Основная страница, которая обеспечивает характеристики, являющимися общими для большинства приложений.
    /// </summary>
    public sealed partial class teacher_page : Page
    {

        private Dictionary<byte, StructAnswer> answers = new Dictionary<byte, StructAnswer>(4);
        private string quest = "";
        private bool[] right = new bool[4];

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// Эту настройку можно изменить на модель строго типизированных представлений.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper используется на каждой странице для облегчения навигации и 
        /// управление жизненным циклом процесса
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public teacher_page()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// Заполняет страницу содержимым, передаваемым в процессе навигации. Любое сохраненное состояние также является
        /// при повторном создании страницы из предыдущего сеанса.
        /// </summary>
        /// <param name="sender">
        /// Источник события; обычно <see cref="Common.NavigationHelper"/>
        /// </param>
        /// <param name="e">Данные события, предоставляющие параметр навигации, который передается
        /// <see cref="Frame.Navigate(Type, Object)"/> при первоначальном запросе этой страницы, и
        /// словарь состояния, сохраненного этой страницей в ходе предыдущего
        /// сеансом. Состояние будет равно значению NULL при первом посещении страницы.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Сохраняет состояние, связанное с данной страницей, в случае приостановки приложения или
        /// удаления страницы из кэша навигации.  Значения должны соответствовать требованиям сериализации
        /// требования <see cref="Common.SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">Источник события; обычно <see cref="Common.NavigationHelper"/></param>
        /// <param name="e">Данные события, которые предоставляют пустой словарь для заполнения
        /// сериализуемым состоянием.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region Регистрация NavigationHelper

        /// Методы, предоставленные в этом разделе, используются исключительно для того, чтобы
        /// NavigationHelper для отклика на методы навигации страницы.
        /// 
        /// Логика страницы должна быть размещена в обработчиках событий для 
        /// <see cref="Common.NavigationHelper.LoadState"/>
        /// и <see cref="Common.NavigationHelper.SaveState"/>.
        /// Параметр навигации доступен в методе LoadState 
        /// в дополнение к состоянию страницы, сохраненному в ходе предыдущего сеанса.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(addaccount));
        }
        TextBox question = new TextBox();
        TextBox[] txt = new TextBox[4];
        TextBox right_answer = new TextBox();

        private void create_question_Click(object sender, RoutedEventArgs e)
        {

            question.Text = "Введите вопрос";
            create_question.Visibility = Visibility.Collapsed;
            button1.Visibility = Visibility.Visible;

            question.Width = 500;
            question.Height = 50;
            content_sp.Children.Add(question);

            for (int i = 0; i < txt.Length; i++)
                txt[i] = new TextBox();

            for (int i = 0; i < 4; i++)
            {
                txt[i].Name = i.ToString();
                txt[i].Text = String.Format("Ответ {0}", (i + 1).ToString());
                txt[i].Width = 500;
                txt[i].Height = 50;
                content_sp.Children.Add(txt[i]);
            }

            right_answer.Text = "Номер правильного ответа";
            right_answer.Width = 500;
            right_answer.Height = 50;
            content_sp.Children.Add(right_answer);

            button1.Click += Button1_Click;
        }
        

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string key = question.Text;
            string value = "";

            for(int i = 0; i < 4; i++)
            {
                value = value + txt[i].Text + "#";
            }

            value += right_answer.Text;

            Windows.Storage.ApplicationData.Current.LocalSettings.Values[key] = value;

            question.Text = "Введите вопрос";

            for (int i = 0; i < 4; i++)
            {                
                txt[i].Text = String.Format("Ответ {0}", (i + 1).ToString());                
            }
            right_answer.Text = "Номер правильного ответа";
          

            create_question.Visibility = Visibility.Visible;
            button1.Visibility = Visibility.Visible;

            content_sp.Children.Remove(question);

            for (int i = 0; i < 4; i++)
            {
                content_sp.Children.Remove(txt[i]);
            }
            content_sp.Children.Remove(right_answer);

        }        
    }
}
