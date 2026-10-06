using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;
using static System.Net.WebRequestMethods;

namespace FacePrototype.Components.Pages
{
    internal class PointList : IEnumerable<ProjectionPoint>
    {
        public readonly Dictionary<BackgroungImage, ProjectionPoint[]> imagePoints = [];
        public readonly Dictionary<BackgroungImage, Point2D[]> pointCoordinates = [];
        public readonly ProjectionPoint[] points =
        {
            new ProjectionPoint("Предплечье правое",Color.Black,10,85,true),
            new ProjectionPoint("Предплечье левое",Color.Black,85,85,true),
            new ProjectionPoint("Печень",Color.Brown,47,27,true),
            new ProjectionPoint("Сердце",Color.Red,53,40,true),
            new ProjectionPoint("Нос сердце",Color.Red,47,35),
            new ProjectionPoint("Висок слева (поджелудочная)",Color.Brown,60,27),
            new ProjectionPoint("Висок справа (желчный)",Color.Brown,34,27),
            new ProjectionPoint("Тонкий кишечник лоб",Color.Brown,47,21),
            new ProjectionPoint("Толстый кишечник лоб справа",Color.Brown,39,18),
            new ProjectionPoint("Толстый кишечник лоб слева",Color.Brown,55,18),

            new ProjectionPoint("Прямая кишка",Color.Brown,41,40),
            new ProjectionPoint("Щека справа желудок",Color.Brown,36,37),
            new ProjectionPoint("Щека слева желудок",Color.Brown,58,37),
            new ProjectionPoint("Матка (мама)/ папа лоб",Color.Green,47,15),
            new ProjectionPoint("ОТМ (органы малого таза)",Color.Green,47,51),
            new ProjectionPoint("Щитовидка",Color.Burgundy,47,75),
            new ProjectionPoint("Над ключицей справа",Color.Brown,36,75),
            new ProjectionPoint("Над ключицей слева",Color.Brown,58,75),
            new ProjectionPoint("Мочевой шея",Color.Yellow,47,58),
            new ProjectionPoint("Почка справа / глаз",Color.Yellow,35,32),

            new ProjectionPoint("Почка слева / глаз",Color.Yellow,59,32),
            new ProjectionPoint("Надпочечники бровь правая",Color.Burgundy,42,24),
            new ProjectionPoint("Надпочечники бровь левая",Color.Burgundy,52,24),
            new ProjectionPoint("Надпочечники шея правая",Color.Burgundy,37,66),
            new ProjectionPoint("Надпочечники шея левая",Color.Burgundy,57,66),
            new ProjectionPoint("Легкие справа",Color.Blue,37,47),
            new ProjectionPoint("Легкие слева",Color.Blue,57,47),
            new ProjectionPoint("Почки шея справа",Color.Yellow,41,61),
            new ProjectionPoint("Почки шея слева",Color.Yellow,53,61),
            new ProjectionPoint("Легкие, бронхи",Color.Blue,31,71),

            new ProjectionPoint("Бронхи",Color.Blue,63,71),
            new ProjectionPoint("Грудина слева",Color.Red,60,85),
            new ProjectionPoint("Грудина справа",Color.Red,34,85),
            new ProjectionPoint("Позвоночник шея центр",Color.Black,75,55),
            new ProjectionPoint("Шея сзади слева",Color.Black,80,57),
            new ProjectionPoint("Шея сзади справа",Color.Black,70,57),
            new ProjectionPoint("Ней-Гуань на правой руке",Color.Burgundy,10,93),
            new ProjectionPoint("Ней-Гуань на левой руке",Color.Red,85,93)
        };
        public readonly string[] spoints =
        {
            "Предплечье правое",
     "Предплечье левое",
     "Печень",
     "Сердце",
     "Нос сердце",
     "Висок слева поджелудочная",
     "Висок справа желчный",
     "Тонкий кишечник лоб",
     "Толстый кишечник лоб справа",
     "Толстый кишечник лоб слева",

     "Прямая кишка",
     "Щека справа желудок",
     "Щека слева желудок",
     "Матка мама/ папа лоб",
     "ОТМ органы малого таза",
     "Щитовидка",
     "Над ключицей справа",
     "Над ключицей слева",
     "Мочевой шея",
     "Почка справа / глаз",

     "Почка слева / глаз",
     "Надпочечники бровь правая",
     "Надпочечники бровь левая",
     "Надпочечники шея правая",
     "Надпочечники шея левая",
     "Легкие справа",
     "Легкие слева",
     "Почки шея справа",
     "Почки шея слева",
     "Легкие, бронхи",

     "Бронхи",
     "Грудина слева",
     "Грудина справа",
     "Позвоночник шея центр",
     "Шея сзади слева",
     "Шея сзади справа",
     "Ней-Гуань на правой руке",
     "Ней-Гуань на левой руке",
        };

        public BackgroungImage PhotoUrl
        {
            get;
            private set;
        }
        public PointList()
        {
            PhotoUrl = BackgroungImage.Female;
            ReadFromJson();
            void ReadFromJson()
            {
                foreach (var name in Enum.GetValues<BackgroungImage>())
                {
                    imagePoints[name] = ReadPointsFromEmbeddedResource(name);
                }
            }
            ProjectionPoint[] ReadPointsFromEmbeddedResource(BackgroungImage image)
            {
                var assembly = Assembly.GetExecutingAssembly();
                string resourceName = $"FacePrototype.Data.{image}.json";

                using Stream stream = assembly.GetManifestResourceStream(resourceName)
                    ?? throw new FileNotFoundException($"Resource {resourceName} not found.");
                using StreamReader reader = new StreamReader(stream);
                string json = reader.ReadToEnd();

                return JsonSerializer.Deserialize<ProjectionPoint[]>(json) ?? Array.Empty<ProjectionPoint>();
            }
        }
        private readonly int NUMBER_OF_IMAGES = Enum.GetValues<BackgroungImage>().Length;
        public void ChangeGender()
        {
            PhotoUrl = (BackgroungImage)(((int)PhotoUrl + 1) % NUMBER_OF_IMAGES);
            OnChanged?.Invoke();
        }

        public event Action? OnChanged;

        public double CountMedian()
        {
            List<double> results = [];
            foreach (var point in imagePoints[PhotoUrl])
            {
                if (point.IsVisible) results.Add(point.Result);
            }
            results.Sort();
            if (results.Count > 0)
            {
                if (results.Count % 2 == 1) return results[results.Count / 2];
                if (results.Count % 2 == 0) return (results[results.Count / 2] + results[results.Count / 2 - 1]) / 2;
            }
            return 0;
        }
        public double CountStressMedian()
        {
            List<double> results = [];
            foreach (var point in imagePoints[PhotoUrl])
            {
                if (point.IsVisible) results.Add(point.StressResult1);
                if (point.IsVisible) results.Add(point.StressResult2);
            }
            results.Sort();
            if (results.Count > 0)
            {
                if (results.Count % 2 == 1) return results[results.Count / 2];
                if (results.Count % 2 == 0) return (results[results.Count / 2] + results[results.Count / 2 - 1]) / 2;
            }
            return 0;
        }

        public string GetDescription()
        {
            double median = CountMedian();
            string medianInfo = $"Медиана: {median}%. ";
            Color BackgroundColor = median switch
            {
                > 100 => Color.White,
                > 85 => Color.Green,
                > 78.8 => Color.Lime,
                >= 70 => Color.Yellow,
                > 65 => Color.Gold,
                > 60 => Color.Orange,
                > 55 => Color.Red,
                > 34 => Color.Burgundy,
                > 10 => Color.Purple,
                _ => Color.White
            };
            Color FontColor = BackgroundColor == Color.Burgundy ? Color.White : Color.Black;
            string backgroundColor = BackgroundColor.GetRGB();
            string fontColor = FontColor.GetRGB();
            string description = BackgroundColor switch
            {
                Color.Green => "Физическое и эмоциональное состояние в норме. В проекции органов: стабильная работа. Ближе к нижней границе значений - легкая усталость, не хватает воды. Результаты завышены при повышенной влажности кожи.",
                Color.Lime => "Физическое и эмоциональное состояние в норме. Лёгкая усталость; после стресса; недосыпание, легкий голод, не хватает воды. Легкая слабость.",
                Color.Yellow => "Усталость, слабость. Голод или расслабление после сна, еды. Состояние после болезни или перед ним. В проекции органов - слабость, спазмы. Посмотреть на точки с минимальными значениями.",
                Color.Gold => "Заметная усталость, требуется отдых. Голод, спазмы, рекомендуется приём пищи; после еды - норма. В проекции органов - подавление работы, возможно воспаление, стресс (сердце, печень, почки).",
                Color.Orange => "Сильная усталость, боль, спазмы, после стресса. При повторении активация вирусов, заболевания, обратить внимание. В проекции органов - подавление работы, развитие воспаления (спазмы, боль). Мониторить состояние, принять меры, развитие негативных процессов.",
                Color.Red => "Контроль стресса! Сильная слабость. Сильный голод. В  проекции органов - серьезное ослабление функций, воспаление. Повышен уровень гормонов, спазм. Нарушена функция вегетативной нервной системы. Проверить уровень гормонов, воспаления.",
                Color.Burgundy => "Высокий уровень гормонов, сильный стресс, возбуждение. Воспаление, критическая слабость. Открытые раны. Обратить особое внимание на точки проекций органов с низким индексом здоровья - очень опасно,  адреналин (печень, почки, сердце). Срочно требуется помощь, очень опасно! Снять боль и спазм. Проверить давление, сахар.",
                Color.Purple => "Срочно принять меры! Опасное состояние, требуется срочная помощь! Проверить давление, уровень сахара, температуру. Высокий уровень гормонов стресса, спазм сосудов. Активное воспаление. Опасное состояние! Критическое состояние организма. Для контроля необходимо измерить минимум в 6-ти точках!",
                _ => "Грубая ошибка измеренияй, проверить прибор по инструкции устранения неполадок и заменить сенсор!"
            };
            string css = $"background-color: {backgroundColor}; color: {fontColor};";
            double stressMedian = CountStressMedian();
            string stress = $" Уровень стресса: {stressMedian}%.";

            string html = $"<div style=\"{css}\">{medianInfo + description + stress}</div>";
            return html;
        }

        public IEnumerator<ProjectionPoint> GetEnumerator()
        {
            return ((IEnumerable<ProjectionPoint>)imagePoints[PhotoUrl]).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return imagePoints[PhotoUrl].GetEnumerator();
        }
        public void UnselectAll()
        {
            bool unlockAll = true;
            foreach (ProjectionPoint p in imagePoints[PhotoUrl])
            {
                if (p.IsVisible)
                {
                    p.IsVisible = false;
                    unlockAll = false;
                    p.Result = 0;
                }
            }
            if (unlockAll)
            {
                foreach (ProjectionPoint p in imagePoints[PhotoUrl])
                {
                    p.IsVisible = true;
                }
            }
            OnChanged?.Invoke();
        }
    }
    struct PointDesc
    {

    }

    enum BackgroungImage
    {
        Female = 0,
        Male = 1,
        Baby = 2,
        Girl = 3,
        Boy = 4,
        TeenagerGirl = 5,
        TeenagerBoy = 6
    }
    static class BackgroungImageEnumExtension
    {
        public static string GetPhotoUrl(this BackgroungImage image)
        {
            return image switch
            {
                BackgroungImage.Female => "background-image: url('/data/Female.jpg');",
                BackgroungImage.Male => "background-image: url('/data/Male.jpg');",
                BackgroungImage.Baby => "background-image: url('/data/Baby.jpg');",
                BackgroungImage.Girl => "background-image: url('/data/Girl.jpg');",
                BackgroungImage.Boy => "background-image: url('/data/Boy.jpg');",
                BackgroungImage.TeenagerGirl => "background-image: url('/data/TeenagerGirl.jpg');",
                BackgroungImage.TeenagerBoy => "background-image: url('/data/TeenagerBoy.jpg');",
                _ => "background-image: url('/data/Female.jpg');"
            };
        }
    }
}
