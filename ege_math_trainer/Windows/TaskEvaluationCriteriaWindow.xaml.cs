using System.Windows;
using ege_math_trainer.Models;

namespace ege_math_trainer.Windows
{
    public partial class TaskEvaluationCriteriaWindow : Window
    {
        private AppContext _context;
        public TaskEvaluationCriteriaWindow(int currentTaskId, int currentTaskPart)
        {
            InitializeComponent();

            _context = new AppContext();


            PartTwoTask currentTask = _context.PartTwoTasks.FirstOrDefault(q => q.Id == currentTaskId);

            int number = currentTask.TaskId;
            NameCriteriaTask.Text = _context.Tasks.FirstOrDefault(q => q.Id == number).ToString();

            Criteria criteria = _context.Criterias.FirstOrDefault(q => q.Id == number);
            TextBlockCriteria.Text = criteria.EvaluationCriteria;

            TextBlockIndCriteria.Text = currentTask.IndEvaluationCriteria;

        }

        private void ButtonDecisionCansel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
