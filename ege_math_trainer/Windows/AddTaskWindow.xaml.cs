using System.Windows;
using System.Windows.Media.Imaging;
using ege_math_trainer.Models;
using Microsoft.Win32;


namespace ege_math_trainer.Windows
{
    public partial class AddTaskWindow : Window
    {
        private AppContext _context;
        public int currentTaskId;
        public string AddImageCondition;
        public string AddImageDecision;
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
                        if (!string.IsNullOrEmpty(AddImageCondition))
                        {
                            if (!string.IsNullOrEmpty(AddImageDecision))
                            {
                                PartOneTask newPartOneTask = new PartOneTask
                                {
                                    Condition = BoxAddTaskCondition.Text,
                                    Decision = BoxAddTaskDecision.Text,
                                    ConditionImage = AddImageCondition,
                                    DecisionImagePath = AddImageDecision,
                                    RightAnswer = BoxAddTaskRightAnswer.Text,
                                    TaskId = currentTaskId,
                                    Users = new List<User>()
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
                                    ConditionImage = AddImageCondition,
                                    RightAnswer = BoxAddTaskRightAnswer.Text,
                                    TaskId = currentTaskId,
                                    Users = new List<User>()
                                };

                                _context.PartOneTasks.Add(newPartOneTask);
                                _context.SaveChanges();

                                DialogResult = true;
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(AddImageDecision))
                            {
                                PartOneTask newPartOneTask = new PartOneTask
                                {
                                    Condition = BoxAddTaskCondition.Text,
                                    Decision = BoxAddTaskDecision.Text,
                                    DecisionImagePath = AddImageDecision,
                                    RightAnswer = BoxAddTaskRightAnswer.Text,
                                    TaskId = currentTaskId,
                                    Users = new List<User>()
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
                                    RightAnswer = BoxAddTaskRightAnswer.Text,
                                    TaskId = currentTaskId,
                                    Users = new List<User>()
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
                    MessageBox.Show("Заполните обязательные поля: 'Условие', 'Решение', 'Правильный ответ'.");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(BoxAddTaskCondition.Text) && !string.IsNullOrEmpty(BoxAddTaskIndCriteria.Text))
                {
                    PartTwoTask? provPartTwoTask = _context.PartTwoTasks.FirstOrDefault(q => q.Condition == BoxAddTaskCondition.Text);
                    if (provPartTwoTask == null)
                    {
                        if (!string.IsNullOrEmpty(AddImageCondition))
                        {
                            if (!string.IsNullOrEmpty(BoxAddTaskDecision.Text))
                            {
                                if (!string.IsNullOrEmpty(AddImageDecision))
                                {
                                    PartTwoTask newPartTwoTask = new PartTwoTask
                                    {
                                        Condition = BoxAddTaskCondition.Text,
                                        Decision = BoxAddTaskDecision.Text,
                                        ConditionImage = AddImageCondition,
                                        DecisionImagePath = AddImageDecision,
                                        IndEvaluationCriteria = BoxAddTaskIndCriteria.Text,
                                        TaskId = currentTaskId,
                                        CriteriaId = currentTaskId
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
                                        ConditionImage = AddImageCondition,
                                        IndEvaluationCriteria = BoxAddTaskIndCriteria.Text,
                                        TaskId = currentTaskId,
                                        CriteriaId = currentTaskId
                                    };
                                    _context.PartTwoTasks.Add(newPartTwoTask);
                                    _context.SaveChanges();

                                    DialogResult = true;
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(AddImageDecision))
                                {
                                    PartTwoTask newPartTwoTask = new PartTwoTask
                                    {
                                        Condition = BoxAddTaskCondition.Text,
                                        ConditionImage = AddImageCondition,
                                        DecisionImagePath = AddImageDecision,
                                        IndEvaluationCriteria = BoxAddTaskIndCriteria.Text,
                                        TaskId = currentTaskId,
                                        CriteriaId = currentTaskId
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
                                        ConditionImage = AddImageCondition,
                                        IndEvaluationCriteria = BoxAddTaskIndCriteria.Text,
                                        TaskId = currentTaskId,
                                        CriteriaId = currentTaskId
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
                                if (!string.IsNullOrEmpty(AddImageDecision))
                                {
                                    PartTwoTask newPartTwoTask = new PartTwoTask
                                    {
                                        Condition = BoxAddTaskCondition.Text,
                                        Decision = BoxAddTaskDecision.Text,
                                        DecisionImagePath = AddImageDecision,
                                        IndEvaluationCriteria = BoxAddTaskIndCriteria.Text,
                                        TaskId = currentTaskId,
                                        CriteriaId = currentTaskId
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
                                        IndEvaluationCriteria = BoxAddTaskIndCriteria.Text,
                                        TaskId = currentTaskId,
                                        CriteriaId = currentTaskId
                                    };
                                    _context.PartTwoTasks.Add(newPartTwoTask);
                                    _context.SaveChanges();

                                    DialogResult = true;
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(AddImageDecision))
                                {
                                    PartTwoTask newPartTwoTask = new PartTwoTask
                                    {
                                        Condition = BoxAddTaskCondition.Text,
                                        DecisionImagePath = AddImageDecision,
                                        IndEvaluationCriteria = BoxAddTaskIndCriteria.Text,
                                        TaskId = currentTaskId,
                                        CriteriaId = currentTaskId
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
                                        IndEvaluationCriteria = BoxAddTaskIndCriteria.Text,
                                        TaskId = currentTaskId,
                                        CriteriaId = currentTaskId
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
                    MessageBox.Show("Заполните обязательные поля: 'Условие', 'Индивидуальные критерии'.");
                }
            }
        }

        private void ButtonAddConditionImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Images (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png", //что видит пользователь|фильтр для системы
                Title = "Выберите картинку для условия",
                Multiselect = false //можно выбрать только 1 файл
            };

            if (openFileDialog.ShowDialog() == true)
            {
                AddImageCondition = openFileDialog.FileName;
                ImageCondition.Source = new BitmapImage(new Uri(AddImageCondition, UriKind.RelativeOrAbsolute));
                //BitmapImage - класс WPF для работы с изображениями (принимает Uri и загружает изображение по этому пути)
                //Uri - адрес; UriKind.Relative - относительный путь (не полный); UriKind.Absolute - абсолютный адрес
            }
        }

        private void ButtonAddDecisionImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Images (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png", //что видит пользователь|фильтр для системы
                Title = "Выберите картинку для решения",
                Multiselect = false //можно выбрать только 1 файл
            };

            if (openFileDialog.ShowDialog() == true)
            {
                AddImageDecision = openFileDialog.FileName;
                ImageDecision.Source = new BitmapImage(new Uri(AddImageDecision, UriKind.RelativeOrAbsolute));
                //BitmapImage - класс WPF для работы с изображениями (принимает Uri и загружает изображение по этому пути)
                //Uri - адрес; UriKind.Relative - относительный путь (не полный); UriKind.Absolute - абсолютный адрес
            }
        }
    }
}
