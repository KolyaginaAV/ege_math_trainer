using System.Windows;
using System.Windows.Media.Imaging;
using ege_math_trainer.Models;

namespace ege_math_trainer.Windows
{
    public partial class TaskEvaluationCriteriaWindow : Window
    {
        private AppContext _context;
        public TaskEvaluationCriteriaWindow(PartTwoTask currentTask, int currentNumberTaskId)
        {
            InitializeComponent();

            _context = new AppContext();

            NameCriteriaTask.Text = _context.Tasks.FirstOrDefault(q => q.Id == currentNumberTaskId).ToString();

            Criteria criteria = _context.Criterias.FirstOrDefault(q => q.Id == currentNumberTaskId);

            TextBlockCriteria.Text = criteria.EvaluationCriteria;

            TextBlockIndCriteria.Text = currentTask.IndEvaluationCriteria;
            ImageCriteria.Source = new BitmapImage(new Uri(criteria.ImageEvaluationCriteriaPath, UriKind.RelativeOrAbsolute));
            //BitmapImage - класс WPF для работы с изображениями (принимает Uri и загружает изображение по этому пути)
            //Uri - адрес; UriKind.Relative - относительный путь (не полный); UriKind.Absolute - абсолютный адрес
        }

        private void ButtonDecisionCansel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
