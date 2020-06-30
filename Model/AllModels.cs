using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfApp2.Models
{
        class AllModels
        {
                public static Dictionary<int, QuestionParameter> questions = new Dictionary<int, QuestionParameter>();
                public static List<QuestionParameter> Data = new List<QuestionParameter>();
        }
        public class QuestionParameter
        {
                public string Question;
                public string Answers;
                public string RightAnswersIndex;
                public string TypeAnswers;
        }
        public class Elements
        {
                public bool _CheckItem;
                public int CurentIndex;
                public string QuestionNameT { get; set; }
                public string LoadRadioContent { get; set; }
                public string groupQuest { get; set; }
                public string RightValue { get; set; }
                public string[] Ansers;
                public bool CheckItem
                {
                        get
                        {
                                return _CheckItem;
                        }
                        set
                        {
                                this._CheckItem = value;
                        }
                }
        }
        class BooleanToVisibilityConverter : IValueConverter
        {
                public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                        if (value is Boolean && (bool)value)
                        {
                                return Visibility.Visible;
                        }
                        return Visibility.Collapsed;
                }

                public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                        if (value is Visibility && (Visibility)value == Visibility.Visible)
                        {
                                return true;
                        }
                        return false;
                }
        }
}
