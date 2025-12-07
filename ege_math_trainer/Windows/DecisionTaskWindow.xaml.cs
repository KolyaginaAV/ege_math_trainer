using System.Windows;
using System.Windows.Media.Imaging;
using ege_math_trainer.Models;

namespace ege_math_trainer.Windows
{
    public partial class DecisionTaskWindow : Window
    {
        private AppContext _context;
        public DecisionTaskWindow(int currentTaskId, int currentNumberTaskId)
        {
            InitializeComponent();

            _context = new AppContext();

            if (currentNumberTaskId > 0 && currentNumberTaskId < 13)
            {
                PartOneTask currentTask = _context.PartOneTasks.FirstOrDefault(q => q.Id == currentTaskId);

                NameTaskDecision.Text = _context.Tasks.FirstOrDefault(q => q.Id == currentNumberTaskId).ToString();
                TextBlockDecisionCondition.Text = currentTask.Condition;
                TextBlockDecision.Text = currentTask.Decision;

                PanelDecisionAnswer.Visibility = Visibility.Visible;
                TextBlockDecisionRightAnswer.Text = currentTask.RightAnswer;

                if (!string.IsNullOrEmpty(currentTask.ConditionImage))
                {
                    ImageDecisionCondition.Source = new BitmapImage(new Uri(currentTask.ConditionImage, UriKind.RelativeOrAbsolute));
                    //BitmapImage - класс WPF для работы с изображениями (принимает Uri и загружает изображение по этому пути)
                    //Uri - адрес; UriKind.Relative - относительный путь (не полный); UriKind.Absolute - абсолютный адрес
                }
                if (!string.IsNullOrEmpty(currentTask.DecisionImagePath))
                {
                    ImageDecision.Source = new BitmapImage(new Uri(currentTask.DecisionImagePath, UriKind.RelativeOrAbsolute));
                }
            }
            else
            {
                PartTwoTask currentTask = _context.PartTwoTasks.FirstOrDefault(q => q.Id == currentTaskId);

                NameTaskDecision.Text = _context.Tasks.FirstOrDefault(q => q.Id == currentNumberTaskId).ToString();

                TextBlockDecisionCondition.Text = currentTask.Condition;
                if (!string.IsNullOrEmpty(currentTask.ConditionImage))
                {
                    ImageDecisionCondition.Source = new BitmapImage(new Uri(currentTask.ConditionImage, UriKind.RelativeOrAbsolute));
                    //BitmapImage - класс WPF для работы с изображениями (принимает Uri и загружает изображение по этому пути)
                    //Uri - адрес; UriKind.Relative - относительный путь (не полный); UriKind.Absolute - абсолютный адрес
                }
                if (currentTask.Decision != null)
                {
                    TextBlockDecision.Text = currentTask.Decision;
                }
                if (currentTask.DecisionImagePath != null)
                {
                    ImageDecision.MaxHeight = 900;
                    ImageDecision.MaxWidth = 800;
                    ImageDecision.Source = new BitmapImage(new Uri(currentTask.DecisionImagePath, UriKind.RelativeOrAbsolute));
                }
            }
        }

        private void ButtonDecisionCansel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
