using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacePrototype.Components.Pages
{
    internal class SignalList : IEnumerable<SensorSignal>
    {
        public readonly Dictionary<string, SensorSignal> signals = new Dictionary<string, SensorSignal>()
        {
            { "Предплечье левое мах", new SensorSignal("Предплечье левое мах",Position.Left,true) }, //C3
            { "Предплечье левое первое", new SensorSignal("Предплечье левое первое",Position.Left) }, //C4
            { "Предплечье правое мах", new SensorSignal("Предплечье правое мах",Position.Right,true) }, //C5
            { "Предплечье правое первое", new SensorSignal("Предплечье правое первое",Position.Right) }, //C6
            { "Печень центр мах", new SensorSignal("Печень центр мах",Position.Center,true) }, //C7
            { "Печень центр 1", new SensorSignal("Печень центр 1") },
            { "Сердце мах", new SensorSignal("Сердце мах",Position.Center,true) }, //C9
            { "Сердце 1", new SensorSignal("Сердце 1") },
            { "Тонкий кишечник лоб центр", new SensorSignal("Тонкий кишечник лоб центр") }, //C12
            { "Толстый кишеч лоб справа мах", new SensorSignal("Толстый кишеч лоб справа мах",Position.Right) },

            { "Толстый кишеч лоб справа 1", new SensorSignal("Толстый кишеч лоб справа 1",Position.Right) },
            { "Толстый кишечник лоб слева", new SensorSignal("Толстый кишечник лоб слева",Position.Left) },
            { "ОМТ центр", new SensorSignal("ОМТ центр") }, //C16
            { "Матка/ папа лоб центр", new SensorSignal("Матка/ папа лоб центр") }, //C17
            { "Щитовидка центр мах %", new SensorSignal("Щитовидка центр мах %") },
            { "Щитовидка центр 1", new SensorSignal("Щитовидка центр 1") },
            { "Ней-Гуань на левой руке", new SensorSignal("Ней-Гуань на левой руке",Position.Left) }, //C20
            { "Ней-Гуань на правой руке", new SensorSignal("Ней-Гуань на правой руке",Position.Right) }, //C21
            { "Бедро левое", new SensorSignal("Бедро левое",Position.Left) },
            { "Бедро правое", new SensorSignal("Бедро правое",Position.Right) },

            { "Висок слева", new SensorSignal("Висок слева",Position.Left) }, //C25
            { "Висок справа", new SensorSignal("Висок справа",Position.Right) }, //C26
            { "Грудина слева", new SensorSignal("Грудина слева",Position.Left) },
            { "Грудина справа", new SensorSignal("Грудина справа",Position.Right) },
            { "желудок тело центр", new SensorSignal("желудок тело центр") },
            { "Запястье левое", new SensorSignal("Запястье левое",Position.Left) }, //C30
            { "Запястье правое", new SensorSignal("Запястье правое",Position.Right) }, //C31
            { "Затылок центр", new SensorSignal("Затылок центр") },
            { "Ладонь левая", new SensorSignal("Ладонь левая",Position.Left) },
            { "Ладонь правая", new SensorSignal("Ладонь правая",Position.Right) },

            { "Левая лопатка", new SensorSignal("Левая лопатка") },
            { "Лопатка правая", new SensorSignal("Лопатка правая",Position.Right) },
            { "Мочевой шея центр", new SensorSignal("Мочевой шея центр") },
            { "Над ключицей слева", new SensorSignal("Над ключицей слева",Position.Left) },
            { "Над ключицей справа", new SensorSignal("Над ключицей справа",Position.Right) },
            { "надпочечник слева шея", new SensorSignal("надпочечник слева шея",Position.Left) },
            { "надпочечник справа шея", new SensorSignal("надпочечник справа шея",Position.Right) },
            { "Надпочечники бровь левая", new SensorSignal("Надпочечники бровь левая",Position.Left) },
            { "Надпочечники бровь правая", new SensorSignal("Надпочечники бровь правая",Position.Right) },
            { "Подреберье правое", new SensorSignal("Подреберье правое",Position.Right) }, //C44

            { "Подреберье левое", new SensorSignal("Подреберье левое",Position.Left) },
            { "Позвоночник грудина слева", new SensorSignal("Позвоночник грудина слева",Position.Left) },
            { "Позвоночник грудина справа", new SensorSignal("Позвоночник грудина справа",Position.Right) },
            { "Позвоночник шея центр", new SensorSignal("Позвоночник шея центр") },
            { "Почка слева /глаз", new SensorSignal("Почка слева /глаз",Position.Left) }, //C49
            { "Почка справа / глаз", new SensorSignal("Почка справа / глаз",Position.Right) }, //C50
            { "Почки спина слева", new SensorSignal("Почки спина слева",Position.Left) }, //C51
            { "Почки спина справа", new SensorSignal("Почки спина справа",Position.Right) }, //C52
            { "Почки шея слева", new SensorSignal("Почки шея слева",Position.Left) },
            { "Почки шея справа", new SensorSignal("Почки шея справа",Position.Right) },

            { "Прямая кишка губа справа", new SensorSignal("Прямая кишка губа справа",Position.Right) },
            { "Скула слева", new SensorSignal("Скула слева",Position.Left) },
            { "Скула справа", new SensorSignal("Скула справа",Position.Right) },
            { "Солнечное сплетение центр", new SensorSignal("Солнечное сплетение центр") },
            { "Спина слева", new SensorSignal("Спина слева",Position.Left) },
            { "Спина справа", new SensorSignal("Спина справа",Position.Right) },
            { "Стопа левая", new SensorSignal("Стопа левая",Position.Left) },
            { "Стопа правая", new SensorSignal("Стопа правая",Position.Right) },
            { "Толстый киш тело центр", new SensorSignal("Толстый киш тело центр") },
            { "Толстый кишеч лоб справа", new SensorSignal("Толстый кишеч лоб справа",Position.Right) },

            //{ "Толстый кишечник лоб слева", new SensorSignal("Толстый кишечник лоб слева",Position.Left) },
            { "Тонкий киш тело центр", new SensorSignal("Тонкий киш тело центр") },
            //{ "Тонкий кишечник лоб центр", new SensorSignal("Тонкий кишечник лоб центр") },
            { "Точка иммунитета центр", new SensorSignal("Точка иммунитета центр") },
            { "Шея сзади слева", new SensorSignal("Шея сзади слева",Position.Left) },
            { "Шея сзади справа", new SensorSignal("Шея сзади справа",Position.Right) },
            { "Щека слева", new SensorSignal("Щека слева",Position.Left) },
            { "Щека справа", new SensorSignal("Щека справа",Position.Right) },
            { "Щитовидка центр мин %", new SensorSignal("Щитовидка центр мин %") },
            { "Щитовидка центр", new SensorSignal("Щитовидка центр") },

            { "Скат шеи легкие слева", new SensorSignal("Скат шеи легкие слева",Position.Left) }, //C75
            { "Скат шеи легкие, бронхи справа", new SensorSignal("Скат шеи легкие, бронхи справа",Position.Right) } //C76
        };
        public event Action? OnChanged;
        public IEnumerator<SensorSignal> GetEnumerator()
        {
            return ((IEnumerable<SensorSignal>)signals.Values).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return signals.Values.GetEnumerator();
        }
        public void UnselectAll()
        {
            bool unlockAll = true;
            foreach (SensorSignal s in signals.Values)
            {
                if (s.IsVisible)
                {
                    s.IsVisible = false;
                    unlockAll = false;
                    s.Value = 0;
                }
            }
            if (unlockAll)
            {
                foreach (SensorSignal s in signals.Values)
                {
                    s.IsVisible = true;
                }
            }
            OnChanged?.Invoke();
        }
        private static double CountRatio(double numerator, double denominator)
        {
            return numerator / denominator;
        }
        private double CountAverage()
        {
            double result = 0;
            int counter = 0;
            foreach (var signal in signals.Values)
            {
                if (signal.IsVisible)
                {
                    result += signal.Value;
                    counter++;
                }
            }
            if (counter > 0)
            {
                result /= counter;
            }
            return result;
        }

        private double CountAverageMax()
        {
            double result = 0;
            int counter = 0;
            AddIfVisible("Предплечье левое мах");
            AddIfVisible("Предплечье правое мах");
            AddIfVisible("Печень центр мах");
            AddIfVisible("Сердце мах");
            AddIfVisible("Тонкий кишечник лоб центр");
            AddIfVisible("Толстый кишеч лоб справа мах");
            if (counter > 0)
            {
                result /= counter;
            }
            return result;

            void AddIfVisible(string str)
            {
                if (signals[str].IsVisible)
                {
                    counter++;
                    result += signals[str].Value;
                }
            }
        }
        private double CountMax()
        {
            bool isFirstVisibleFound = false;
            double max = 0;
            foreach (var signal in signals.Values)
            {
                if (isFirstVisibleFound)
                {
                    if (signal.IsVisible && signal.Value > max)
                    {
                        max = signal.Value;
                    }
                }
                else
                {
                    if (signal.IsVisible)
                    {
                        isFirstVisibleFound = true;
                        max = signal.Value;
                    }
                }
            }
            return max;
        }
        private double CountMin()
        {
            bool isFirstVisibleFound = false;
            double min = 0;
            foreach (var signal in signals.Values)
            {
                if (isFirstVisibleFound)
                {
                    if (signal.IsVisible && signal.Value < min)
                    {
                        min = signal.Value;
                    }
                }
                else
                {
                    if (signal.IsVisible)
                    {
                        isFirstVisibleFound = true;
                        min = signal.Value;
                    }
                }
            }
            return min;
        }
        public List<string> GetDescription()
        {
            var list = new List<string>();

            double stressIndex = CountRatio(signals["Сердце мах"].Value, signals["Предплечье левое мах"].Value);
            double spasmIndex = CountRatio(signals["Печень центр мах"].Value, signals["Предплечье правое мах"].Value);
            
            list.Add("Показатель внутреннего стресса, ПС (сердце/левая рука): " + stressIndex.ToString("F2"));
            list.Add("Показатель спазмов ЖКТ (печень/правая рука): " + spasmIndex.ToString("F2"));
            list.Add("Слаженность работы сердце/печень: " + CountRatio(signals["Сердце мах"].Value, signals["Печень центр мах"].Value).ToString("F2"));
            list.Add("Системность напряжения ПС/ПЖКТ: " + CountRatio(stressIndex, spasmIndex).ToString("F2"));

            double min = CountMin();
            double max = CountMax();
            double maxMinRatio = CountRatio(max, min);
            list.Add("Ресурсность мах/мин в выборке для каждого: " + maxMinRatio.ToString("F2"));
            //list.Add("Висок л/пр: " + CountRatio(signals["Висок слева"].Value, signals["Висок справа"].Value).ToString());
            AddIfIsVisible("Висок л/пр: ", "Висок слева", "Висок справа");

            double liverSmallBowel = CountRatio(signals["Печень центр мах"].Value, signals["Тонкий кишечник лоб центр"].Value);
            list.Add("печень/тонкий: " + liverSmallBowel.ToString("F2"));
            list.Add("мах/мин//печ/тон: " + CountRatio(maxMinRatio, liverSmallBowel).ToString("F2"));

            //list.Add("печень /подреб пр: " + CountRatio(signals["Печень центр мах"].Value, signals["Подреберье правое"].Value).ToString());
            AddIfIsVisible("печень /подреб пр: ", "Печень центр мах", "Подреберье правое");
            //list.Add("почка лев/пр глаза: " + CountRatio(signals["Почка слева /глаз"].Value, signals["Почка справа / глаз"].Value).ToString());
            AddIfIsVisible("почка лев/пр глаза: ", "Почка слева /глаз", "Почка справа / глаз");
            //list.Add("почка лев/пр тело: " + CountRatio(signals["Почки спина слева"].Value, signals["Почки спина справа"].Value).ToString());
            AddIfIsVisible("почка лев/пр тело: ", "Почки спина слева", "Почки спина справа");
            //list.Add("Ней-Гуань левая/правая: " + CountRatio(signals["Ней-Гуань на левой руке"].Value, signals["Ней-Гуань на правой руке"].Value).ToString());
            AddIfIsVisible("Ней-Гуань левая/правая: ", "Ней-Гуань на левой руке", "Ней-Гуань на правой руке");

            double averageMax = CountAverageMax();
            double average = CountAverage();
            double center = (max - min) / 2;
            double shift = (1 - center / average) * 100;
            list.Add("среднее по всем точкам мах: " + averageMax.ToString("F2"));
            list.Add("% от центра (куда смещено): " + shift.ToString("F2"));

            //list.Add("Репродукция Гормоны Сердце/ОМТ: " + CountRatio(signals["Сердце мах"].Value, signals["ОМТ центр"].Value).ToString());
            AddIfIsVisible("Репродукция Гормоны Сердце/ОМТ: ", "Сердце мах", "ОМТ центр");
            //list.Add("Репродукция органы ОМТ/матка, папа: " + CountRatio(signals["ОМТ центр"].Value, signals["Матка/ папа лоб центр"].Value).ToString());
            AddIfIsVisible("Репродукция органы ОМТ/матка, папа: ", "ОМТ центр", "Матка/ папа лоб центр");
            //list.Add("Тип нервной системы сосуды: " + CountRatio(signals["Предплечье левое первое"].Value, signals["Предплечье левое мах"].Value).ToString());
            AddIfIsVisible("Тип нервной системы сосуды: ", "Предплечье левое первое", "Предплечье левое мах");
            //list.Add("Тип нервной системы ЖКТ: " + CountRatio(signals["Предплечье правое первое"].Value, signals["Предплечье правое мах"].Value).ToString());
            AddIfIsVisible("Тип нервной системы ЖКТ: ", "Предплечье правое первое", "Предплечье правое мах");
            //list.Add("Легкие/бронхи: " + CountRatio(signals["Скат шеи легкие слева"].Value, signals["Скат шеи легкие, бронхи справа"].Value).ToString());
            AddIfIsVisible("Легкие/бронхи: ", "Скат шеи легкие слева", "Скат шеи легкие, бронхи справа");
            //list.Add("Запястье л/предплечье левое: " + CountRatio(signals["Запястье левое"].Value, signals["Предплечье левое мах"].Value).ToString());
            AddIfIsVisible("Запястье л/предплечье левое: ", "Запястье левое", "Предплечье левое мах");
            //list.Add("Запястье пр/предплечье правое: " + CountRatio(signals["Запястье правое"].Value, signals["Предплечье правое мах"].Value).ToString());
            AddIfIsVisible("Запястье пр/предплечье правое: ", "Запястье правое", "Предплечье правое мах");

            //double averageLeft = CountAverage(Position.Left);
            //double averageRight = CountAverage(Position.Right);
            //double averageCenter = CountAverage(Position.Center);
            //list.Add("Среднее, точки справа: " + averageLeft.ToString());
            //list.Add("Среднее, точки слева: " + averageRight.ToString());
            //list.Add("Среднее, точки центр: " + averageCenter.ToString());
            //list.Add("Ассимметрия (среднее слева/среднее справа): " + CountRatio(averageLeft, averageRight).ToString());
            AddAssymetry();

            return list;

            void AddIfIsVisible(string name, string numerator, string denominator)
            {
                if (signals[numerator].IsVisible && signals[denominator].IsVisible)
                {
                    list.Add(name + (signals[numerator].Value / signals[denominator].Value).ToString("F2"));
                }
            }
            void AddAssymetry()
            {
                int[] counter = [0, 0, 0];
                double[] result = [0, 0, 0];
                foreach (var signal in signals.Values)
                {
                    if (signal.IsVisible)
                    {
                        counter[(int)signal.Position]++;
                        result[(int)signal.Position] += signal.Value;
                    }
                }
                if (counter[(int)Position.Right] > 2 && counter[(int)Position.Left] > 2 && counter[(int)Position.Center] > 2)
                {
                    result[(int)Position.Right] /= counter[(int)Position.Right];
                    result[(int)Position.Left] /= counter[(int)Position.Left];
                    result[(int)Position.Center] /= counter[(int)Position.Center];
                    list.Add("Среднее, точки справа: " + result[(int)Position.Right].ToString("F2"));
                    list.Add("Среднее, точки слева: " + result[(int)Position.Left].ToString("F2"));
                    list.Add("Среднее, точки центр: " + result[(int)Position.Center].ToString("F2"));
                    list.Add("Ассимметрия (среднее слева/среднее справа): " + (result[(int)Position.Left] / result[(int)Position.Right]).ToString("F2"));
                }
            }
        }
    }
}
