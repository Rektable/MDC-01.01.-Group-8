using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using OfficeOpenXml;
using System.IO;
using System.Windows.Input;
using Microsoft.Win32; // Для SaveFileDialog

namespace Oknoreg
{

    public class MainViewModel : INotifyPropertyChanged
    {
        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName != value)
                {
                    userName = value;
                    OnPropertyChanged(nameof(UserName));
                }
            }
        }
        public ICommand SaveToExcelCommand { get; private set; }
        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<StudentRanking> StudentsRankings { get; set; }
        public ObservableCollection<StudentSummary> SummaryReport { get; set; }
        public MainViewModel()
        {
            // Инициализация данных
            LoadStudents();
            LoadRankings();
            LoadSummaryReport();
            SaveToExcelCommand = new RelayCommand(SaveToExcelExecute);
        }

        private void LoadStudents()
        {
            Students = new ObservableCollection<Student>
            {
                new Student
                {
                    FullName = "Иванов Иван",
                    Age = 20,
                    Group = 31,
                    Direction = "Программирование",
                    Grades = new List<Grade>
                    {
                        new Grade { Subject = "Математика", Score = 4.5 },
                        new Grade { Subject = "Программирование", Score = 5.0 },
                        new Grade { Subject = "Физика", Score = 4.0 }
                    }
                },
                new Student
                {
                    FullName = "Петров Петр",
                    Age = 21,
                    Group = 31,
                    Direction = "Программирование",
                    Grades = new List<Grade>
                    {
                        new Grade { Subject = "Математика", Score = 3.5 },
                        new Grade { Subject = "Программирование", Score = 4.0 },
                        new Grade { Subject = "Физика", Score = 4.5 }
                    }
                },
                new Student
                {
                    FullName = "Сидорова Мария",
                    Age = 22,
                    Group = 32,
                    Direction = "Информационные технологии",
                    Grades = new List<Grade>
                {
                    new Grade { Subject = "Математика", Score = 4.0 },
                    new Grade { Subject = "Программирование", Score = 5.0 },
                    new Grade { Subject = "Базы данных", Score = 4.5 }
                }
            },
                new Student
                {
                    FullName = "Кузнецов Алексей",
                    Age = 19,
                    Group = 32,
                    Direction = "Кибербезопасность",
                    Grades = new List<Grade>
                {
                    new Grade { Subject = "Математика", Score = 4.2 },
                    new Grade { Subject = "Сетевые технологии", Score = 4.8 },
                    new Grade { Subject = "Программирование", Score = 4.5 }
                }
            },
                new Student
                {
                    FullName = "Лебедева Анна",
                    Age = 20,
                    Group = 33,
                    Direction = "Информационные технологии",
                    Grades = new List<Grade>
                {
                    new Grade { Subject = "Алгоритмы", Score = 5.0 },
                    new Grade { Subject = "Программирование", Score = 4.7 },
                    new Grade { Subject = "Операционные системы", Score = 4.9 }
                }
            },
                new Student
                {       
                    FullName = "Александрова Ольга",
                    Age = 20,
                    Group = 35,
                    Direction = "Информационные технологии",
                    Grades = new List<Grade>
                    {
                        new Grade { Subject = "Базы данных", Score = 4.6 },
                        new Grade { Subject = "Программирование", Score = 4.8 },
                        new Grade { Subject = "Операционные системы", Score = 4.7 }
                    }
            },
                new Student
                {
                    FullName = "Яковлев Антон",
                    Age = 19,
                    Group = 36,
                    Direction = "Программирование",
                    Grades = new List<Grade>
                {
                    new Grade { Subject = "Математика", Score = 4.3 },
                    new Grade { Subject = "Программирование", Score = 5.0 },
                    new Grade { Subject = "Физика", Score = 4.2 }
                }
            }
        };
        }

        private void LoadRankings()
        {
            // Сортировка студентов по среднему баллу
            StudentsRankings = new ObservableCollection<StudentRanking>(
                Students.Select(s => new StudentRanking
                {
                    FullName = s.FullName,
                    Group = s.Group,
                    Direction = s.Direction,
                    AverageGrade = s.AverageGrade
                }).OrderByDescending(r => r.AverageGrade));
        }
        private void LoadSummaryReport()
        {
            // Формирование сводной ведомости
            SummaryReport = new ObservableCollection<StudentSummary>(
                Students.Select(s => new StudentSummary
                {
                    FullName = s.FullName,
                    Group = s.Group,
                    Direction = s.Direction,
                    AverageGrade = s.AverageGrade
                }));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class Student
        {
            public string FullName { get; set; }
            public int Age { get; set; }
            public int Group { get; set; } // 31 или 32
            public string Direction { get; set; } // Например, "Робототехника", "Программирование", "Администрирование"
            public List<Grade> Grades { get; set; }
            public double AverageGrade => Grades.Count > 0 ? Grades.Average(g => g.Score) : 0;
        }
        public class StudentRanking
        {
            public string FullName { get; set; }
            public int Group { get; set; }
            public string Direction { get; set; }
            public double AverageGrade { get; set; }
        }
        public class StudentSummary
        {
            public string FullName { get; set; }
            public int Group { get; set; }
            public string Direction { get; set; }
            public double AverageGrade { get; set; }
        }
        public class Grade
        {
            public string Subject { get; set; } // Название предмета
            public double Score { get; set; } // Оценка
        }

        public void SaveToExcel(string filePath)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Students");
                // Заголовки
                worksheet.Cells[1, 1].Value = "ФИО";
                worksheet.Cells[1, 2].Value = "Возраст";
                worksheet.Cells[1, 3].Value = "Группа";
                worksheet.Cells[1, 4].Value = "Направление";
                worksheet.Cells[1, 5].Value = "Предмет";
                worksheet.Cells[1, 6].Value = "Оценка";
                int row = 2;
                foreach (var student in Students)
                {
                    worksheet.Cells[row, 1].Value = student.FullName;
                    worksheet.Cells[row, 2].Value = student.Age;
                    worksheet.Cells[row, 3].Value = student.Group;
                    worksheet.Cells[row, 4].Value = student.Direction;
                    foreach (var grade in student.Grades)
                    {
                        worksheet.Cells[row, 5].Value = grade.Subject;
                        worksheet.Cells[row, 6].Value = grade.Score;
                        row++;
                    }
                }
                // Сохранение файла
                FileInfo file = new FileInfo(filePath);
                package.SaveAs(file);
            }
        }
        private void SaveToExcelExecute()
        {
            // Создаем и настраиваем диалоговое окно для сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*",
                Title = "Сохранить файл как"
            };
            // Если пользователь нажал "Сохранить" в диалоговом окне
            if (saveFileDialog.ShowDialog() == true)
            {
                // Получаем путь к файлу
                string filePath = saveFileDialog.FileName;
                SaveToExcel(filePath);
            }
        }


    }
}