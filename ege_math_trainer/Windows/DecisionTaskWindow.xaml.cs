using System.Windows;
using System.Windows.Media.Imaging;
using ege_math_trainer.Models;

namespace ege_math_trainer.Windows
{
    public partial class DecisionTaskWindow : Window
    {
        private AppContext _context;
        public DecisionTaskWindow(int currentTaskId, int currentTaskPart)
        {
            InitializeComponent();

            _context = new AppContext();

            if (currentTaskPart == 1)
            {
                PartOneTask currentTask = _context.PartOneTasks.FirstOrDefault(q => q.Id == currentTaskId);
                TextBlockDecisionCondition.Text = currentTask.Decision;

                PanelDecisionAnswer.Visibility = Visibility.Visible;
                TextBlockDecisionRightAnswer.Text = currentTask.RightAnswer;

                if (!string.IsNullOrEmpty(currentTask.ConditionImage))
                {
                    ImageDecisionCondition.Source = new BitmapImage(new Uri(currentTask.ConditionImage, UriKind.Relative));
                    //BitmapImage - класс WPF для работы с изображениями (принимает Uri и загружает изображение по этому пути)
                    //Uri - адрес; UriKind.Relative - относительный путь (не полный); UriKind.Absolute - абсолютный адрес
                }
            }
            //else
            //{
            //    PartTwoTask currentTask = _context.PartTwoTasks.FirstOrDefault(q => q.Id == currentTaskId);
            //    TextBlockDecisionCondition.Text = currentTask.Decision;
            //    if (!string.IsNullOrEmpty(currentTask.ConditionImage))
            //    {
            //        ImageDecisionCondition.Source = new BitmapImage(new Uri(currentTask.DecisionImagePath, UriKind.Relative));
            //        //BitmapImage - класс WPF для работы с изображениями (принимает Uri и загружает изображение по этому пути)
            //        //Uri - адрес; UriKind.Relative - относительный путь (не полный); UriKind.Absolute - абсолютный адрес
            //    }
            //}
            
        }

        private void ButtonDecisionCansel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
