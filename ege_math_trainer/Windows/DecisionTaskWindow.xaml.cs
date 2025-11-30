using System.Threading.Tasks;
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

                int number = currentTask.TaskId;
                NameTaskDecision.Text = _context.Tasks.FirstOrDefault(q => q.Id == number).ToString();

                TextBlockDecisionCondition.Text = currentTask.Condition;
                TextBlockDecision.Text = currentTask.Decision;

                PanelDecisionAnswer.Visibility = Visibility.Visible;
                TextBlockDecisionRightAnswer.Text = currentTask.RightAnswer;

                if (!string.IsNullOrEmpty(currentTask.ConditionImage))
                {
                    ImageDecisionCondition.Source = new BitmapImage(new Uri(currentTask.ConditionImage, UriKind.Relative));
                    //BitmapImage - класс WPF для работы с изображениями (принимает Uri и загружает изображение по этому пути)
                    //Uri - адрес; UriKind.Relative - относительный путь (не полный); UriKind.Absolute - абсолютный адрес
                }
                if (!string.IsNullOrEmpty(currentTask.DecisionImagePath))
                {
                    ImageDecision.Source = new BitmapImage(new Uri(currentTask.ConditionImage, UriKind.Relative));
                }
            }
            else
            {
                PartTwoTask currentTask = _context.PartTwoTasks.FirstOrDefault(q => q.Id == currentTaskId);

                int number = currentTask.TaskId;
                NameTaskDecision.Text = _context.Tasks.FirstOrDefault(q => q.Id == number).ToString();

                TextBlockDecisionCondition.Text = currentTask.Condition;
                if (!string.IsNullOrEmpty(currentTask.ConditionImage))
                {
                    ImageDecisionCondition.Source = new BitmapImage(new Uri(currentTask.ConditionImage, UriKind.Relative));
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
                    ImageDecision.Source = new BitmapImage(new Uri(currentTask.DecisionImagePath, UriKind.Relative));
                }
            }
        }

        private void ButtonDecisionCansel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
