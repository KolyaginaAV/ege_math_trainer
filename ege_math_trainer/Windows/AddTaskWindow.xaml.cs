using System.Windows;
using ege_math_trainer.Models;


namespace ege_math_trainer.Windows
{
    public partial class AddTaskWindow : Window
    {
        private AppContext _context;
        public int currentTaskId;
        public AddTaskWindow(int taskId)
        {
            InitializeComponent();

            _context = new AppContext(); //создаем

            currentTaskId = taskId;

            NameTaskAdd.Text = _context.Tasks.FirstOrDefault(q => q.Id == taskId).ToString();

            if (taskId > 12 &&  taskId < 20)
            {
                PanelAddTaskCriteria.Visibility = Visibility.Visible;
            }
            else
            {
                PanelAddTaskRightAnswer.Visibility = Visibility.Visible;
            }
        }

        private void ButtonAddTaskCansel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ButtonAddTaskSave(object sender, RoutedEventArgs e)
        {
            if (currentTaskId > 0 && currentTaskId < 13)
            {
                if (!string.IsNullOrEmpty(BoxAddTaskCondition.Text) && !string.IsNullOrEmpty(BoxAddTaskDecision.Text) && !string.IsNullOrEmpty(BoxAddTaskRightAnswer.Text))
                {
                    PartOneTask? provPartOneTask = _context.PartOneTasks.FirstOrDefault(q => q.Condition == BoxAddTaskCondition.Text);
                    if (provPartOneTask == null)
                    {
                        if (!string.IsNullOrEmpty(BoxAddTaskImageCondition.Text))
                        {
                            if (!string.IsNullOrEmpty(BoxAddTaskImageDecision.Text))
                            {
                                PartOneTask newPartOneTask = new PartOneTask
                                {
                                    Condition = BoxAddTaskCondition.Text,
                                    Decision = BoxAddTaskDecision.Text,
                                    ConditionImage = BoxAddTaskImageCondition.Text,
                                    DecisionImagePath = BoxAddTaskImageDecision.Text,
                                    RightAnswer = BoxAddTaskRightAnswer.Text
                                };

                                _context.PartOneTasks.Add(newPartOneTask);
                                _context.SaveChanges();

                                DialogResult = true;
                            }
                            else
                            {
                                PartOneTask newPartOneTask = new PartOneTask
                                {
                                    Condition = BoxAddTaskCondition.Text,
                                    Decision = BoxAddTaskDecision.Text,
                                    ConditionImage = BoxAddTaskImageCondition.Text,
                                    RightAnswer = BoxAddTaskRightAnswer.Text
                                };

                                _context.PartOneTasks.Add(newPartOneTask);
                                _context.SaveChanges();

                                DialogResult = true;
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(BoxAddTaskImageDecision.Text))
                            {
                                PartOneTask newPartOneTask = new PartOneTask
                                {
                                    Condition = BoxAddTaskCondition.Text,
                                    Decision = BoxAddTaskDecision.Text,
                                    DecisionImagePath = BoxAddTaskImageDecision.Text,
                                    RightAnswer = BoxAddTaskRightAnswer.Text
                                };

                                _context.PartOneTasks.Add(newPartOneTask);
                                _context.SaveChanges();

                                DialogResult = true;
                            }
                            else
                            {
                                PartOneTask newPartOneTask = new PartOneTask
                                {
                                    Condition = BoxAddTaskCondition.Text,
                                    Decision = BoxAddTaskDecision.Text,
                                    RightAnswer = BoxAddTaskRightAnswer.Text
                                };

                                _context.PartOneTasks.Add(newPartOneTask);
                                _context.SaveChanges();

                                DialogResult = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Задание с таким условием уже есть.");
                    }
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены.");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(BoxAddTaskCondition.Text) && !string.IsNullOrEmpty(BoxAddTaskIndCriteria.Text))
                {
                    PartTwoTask? provPartTwoTask = _context.PartTwoTasks.FirstOrDefault(q => q.Condition == BoxAddTaskCondition.Text);
                    if (provPartTwoTask == null)
                    {
                        if (!string.IsNullOrEmpty(BoxAddTaskImageCondition.Text))
                        {
                            if (!string.IsNullOrEmpty(BoxAddTaskDecision.Text))
                            {
                                if (!string.IsNullOrEmpty(BoxAddTaskImageDecision.Text))
                                {
                                    PartTwoTask newPartTwoTask = new PartTwoTask
                                    {
                                        Condition = BoxAddTaskCondition.Text,
                                        Decision = BoxAddTaskDecision.Text,
                                        ConditionImage = BoxAddTaskImageCondition.Text,
                                        DecisionImagePath = BoxAddTaskImageDecision.Text,
                                        IndEvaluationCriteria = BoxAddTaskImageDecision.Text
                                    };
                                    _context.PartTwoTasks.Add(newPartTwoTask);
                                    _context.SaveChanges();

                                    DialogResult = true;
                                }
                                else
                                {
                                    PartTwoTask newPartTwoTask = new PartTwoTask
                                    {
                                        Condition = BoxAddTaskCondition.Text,
                                        Decision = BoxAddTaskDecision.Text,
                                        ConditionImage = BoxAddTaskImageCondition.Text,
                                        IndEvaluationCriteria = BoxAddTaskImageDecision.Text
                                    };
                                    _context.PartTwoTasks.Add(newPartTwoTask);
                                    _context.SaveChanges();

                                    DialogResult = true;
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(BoxAddTaskImageDecision.Text))
                                {
                                    PartTwoTask newPartTwoTask = new PartTwoTask
                                    {
                                        Condition = BoxAddTaskCondition.Text,
                                        ConditionImage = BoxAddTaskImageCondition.Text,
                                        DecisionImagePath = BoxAddTaskImageDecision.Text,
                                        IndEvaluationCriteria = BoxAddTaskImageDecision.Text
                                    };
                                    _context.PartTwoTasks.Add(newPartTwoTask);
                                    _context.SaveChanges();

                                    DialogResult = true;
                                }
                                else
                                {
                                    PartTwoTask newPartTwoTask = new PartTwoTask
                                    {
                                        Condition = BoxAddTaskCondition.Text,
                                        ConditionImage = BoxAddTaskImageCondition.Text,
                                        IndEvaluationCriteria = BoxAddTaskImageDecision.Text
                                    };
                                    _context.PartTwoTasks.Add(newPartTwoTask);
                                    _context.SaveChanges();

                                    DialogResult = true;
                                }
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(BoxAddTaskDecision.Text))
                            {
                                if (!string.IsNullOrEmpty(BoxAddTaskImageDecision.Text))
                                {
                                    PartTwoTask newPartTwoTask = new PartTwoTask
                                    {
                                        Condition = BoxAddTaskCondition.Text,
                                        Decision = BoxAddTaskDecision.Text,
                                        DecisionImagePath = BoxAddTaskImageDecision.Text,
                                        IndEvaluationCriteria = BoxAddTaskImageDecision.Text
                                    };
                                    _context.PartTwoTasks.Add(newPartTwoTask);
                                    _context.SaveChanges();

                                    DialogResult = true;
                                }
                                else
                                {
                                    PartTwoTask newPartTwoTask = new PartTwoTask
                                    {
                                        Condition = BoxAddTaskCondition.Text,
                                        Decision = BoxAddTaskDecision.Text,
                                        IndEvaluationCriteria = BoxAddTaskImageDecision.Text
                                    };
                                    _context.PartTwoTasks.Add(newPartTwoTask);
                                    _context.SaveChanges();

                                    DialogResult = true;
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(BoxAddTaskImageDecision.Text))
                                {
                                    PartTwoTask newPartTwoTask = new PartTwoTask
                                    {
                                        Condition = BoxAddTaskCondition.Text,
                                        DecisionImagePath = BoxAddTaskImageDecision.Text,
                                        IndEvaluationCriteria = BoxAddTaskImageDecision.Text
                                    };
                                    _context.PartTwoTasks.Add(newPartTwoTask);
                                    _context.SaveChanges();

                                    DialogResult = true;
                                }
                                else
                                {
                                    PartTwoTask newPartTwoTask = new PartTwoTask
                                    {
                                        Condition = BoxAddTaskCondition.Text,
                                        IndEvaluationCriteria = BoxAddTaskImageDecision.Text
                                    };
                                    _context.PartTwoTasks.Add(newPartTwoTask);
                                    _context.SaveChanges();

                                    DialogResult = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Задание с таким условием уже есть.");
                    }
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены.");
                }
            }
        }
    }
}
