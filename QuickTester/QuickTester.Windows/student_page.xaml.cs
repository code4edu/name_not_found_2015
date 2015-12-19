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

// Документацию по шаблону элемента "Основная страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=234237

namespace QuickTester
{
    /// <summary>
    /// Основная страница, которая обеспечивает характеристики, являющимися общими для большинства приложений.
    /// </summary>
    public sealed partial class student_page : Page
    {

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


        public student_page()
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

        Dictionary<string, object> data = new Dictionary<string, object>();
        Dictionary<string, List<string>> real_questions = new Dictionary<string, List<string>>();
        Dictionary<string, int> right = new Dictionary<string, int>();

        


        public void GetData()
        {
            foreach(var el in Windows.Storage.ApplicationData.Current.LocalSettings.Values)
            {
                if (!data.ContainsKey(el.Key))
                    data.Add(el.Key, el.Value);
            }
        }
            

        private void get_result_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void load_test_Click(object sender, RoutedEventArgs e)
        {
            GetData();

            #region
            int countOfQuestions = 5;

            
            MyClass[] items = new MyClass[countOfQuestions];

            for (int i = 0; i < items.Length; i++)
                items[i] = new MyClass();

            //for (int i = 0; i < items.Count; i++)
            //    items[i] = new MyClass();

            int counter = 0;
            do
            {
                foreach(var el in data)
                {
                    string t = (string)el.Value;
                    if (t.Contains("#"))
                    {
                        if (!t.Contains("Номер правильного ответа"))
                        { 
                        string[] answers = t.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                        items[counter].question = el.Key;

                        items[counter].rightanswer = int.Parse(answers[answers.Length - 1]);
                        for (int j = 0; j < answers.Length - 1; j++)
                        {
                            items[counter].answers[j] = answers[j];
                        }
                    }
                    }
                    
                }
                counter++;
                
            } while (counter < 5);
            #endregion

            StackPanel[] tests = new StackPanel[5];
            CheckBox[] checks = new CheckBox[4];
            TextBlock[] blocks = new TextBlock[5];
            for (int i = 0; i < checks.Length; i++)
                checks[i] = new CheckBox();

            for (int i = 0; i < tests.Length; i++)
            {
                tests[i] = new StackPanel();
                blocks[i] = new TextBlock();
            }
            TextBlock first_q = new TextBlock();
            first_q.Text = items[0].question;
            for(int i = 0; i < 4; i++)
            {
                checks[i].Content = items[0].answers[i];
            }
            StackPanel pt = new StackPanel();
            pt.Children.Add(first_q);
            for (int i = 0; i < 4; i++)
            {
                pt.Children.Add(checks[i]);
            }
            place_for_test.Children.Add(pt);

        }


    }

    public class MyClass
    {
        public string question;
        public string[] answers = new string[4];
        public int rightanswer;
        public MyClass() { }
    }
}
