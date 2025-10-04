    namespace _4._3
    {
        public interface IStudent
        {
            double GetAverageGrade();    // Определение среднего балла
            string GetCourseInfo();      // Получение информации о курсе
        }

        // Студент 1 курса
        public class FirstYearStudent : IStudent
        {
            private string name;
            private double averageGrade;
            private string faculty;

            public FirstYearStudent(string name, double averageGrade, string faculty)
            {
                this.name = name;
                this.averageGrade = averageGrade;
                this.faculty = faculty;
            }

            public double GetAverageGrade()
            {
                return averageGrade;
            }

            public string GetCourseInfo()
            {
                return $"Студент 1 курса: {name}, Факультет: {faculty}";
            }
        }

        // Студент 2 курса
        public class SecondYearStudent : IStudent
        {
            private string name;
            private double averageGrade;
            private string specialization;

            public SecondYearStudent(string name, double averageGrade, string specialization)
            {
                this.name = name;
                this.averageGrade = averageGrade;
                this.specialization = specialization;
            }

            public double GetAverageGrade()
            {
                return averageGrade;
            }

            public string GetCourseInfo()
            {
                return $"Студент 2 курса: {name}, Специализация: {specialization}";
            }
        }

        // Студент 3 курса
        public class ThirdYearStudent : IStudent
        {
            private string name;
            private double averageGrade;
            private string researchTopic;

            public ThirdYearStudent(string name, double averageGrade, string researchTopic)
            {
                this.name = name;
                this.averageGrade = averageGrade;
                this.researchTopic = researchTopic;
            }

            public double GetAverageGrade()
            {
                return averageGrade;
            }

            public string GetCourseInfo()
            {
                return $"Студент 3 курса: {name}, Тема исследования: {researchTopic}";
            }
        }

        // Студент 4 курса
        public class FourthYearStudent : IStudent
        {
            private string name;
            private double averageGrade;
            private string diplomaTopic;

            public FourthYearStudent(string name, double averageGrade, string diplomaTopic)
            {
                this.name = name;
                this.averageGrade = averageGrade;
                this.diplomaTopic = diplomaTopic;
            }

            public double GetAverageGrade()
            {
                return averageGrade;
            }

            public string GetCourseInfo()
            {
                return $"Студент 4 курса: {name}, Тема диплома: {diplomaTopic}";
            }
        }

        // Демонстрация работы
        class Program
        {
            static void Main()
            {
                // Создаем студентов разных курсов
                List<IStudent> students = new List<IStudent>
            {
                new FirstYearStudent("Иван Иванов", 4.2, "Информатика"),
                new SecondYearStudent("Петр Петров", 4.7, "Программная инженерия"),
                new ThirdYearStudent("Мария Сидорова", 4.9, "Машинное обучение"),
                new FourthYearStudent("Анна Козлова", 4.5, "Разработка мобильных приложений")
            };

                // Выводим информацию о студентах
                Console.WriteLine("Система учета студентов университета:");
                Console.WriteLine("======================================");

                foreach (IStudent student in students)
                {
                    string courseInfo = student.GetCourseInfo();
                    double averageGrade = student.GetAverageGrade();

                    Console.WriteLine($"{courseInfo}");
                    Console.WriteLine($"Средний балл: {averageGrade:F1}");
                    Console.WriteLine("------------------------");
                }

                // Подсчитываем общий средний балл
                Console.WriteLine("\nОбщая статистика:");
                double totalAverage = 0;
                foreach (IStudent student in students)
                {
                    totalAverage += student.GetAverageGrade();
                }
                double overallAverage = totalAverage / students.Count;
                Console.WriteLine($"Средний балл всех студентов: {overallAverage:F1}");
            }
        }
    }
