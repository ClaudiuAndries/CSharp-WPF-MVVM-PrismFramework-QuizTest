using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AutolocatorWPF.Models;
using System.Windows.Data;
using System.Globalization;
using Prism.Mvvm;
using Prism.Regions;

namespace AutolocatorWPF.ViewModels
{
        class ViewAViewModel : INotifyPropertyChanged
        {

                Random randomNumber = new Random();

                private int [] index = new int[5];
                private static int curentIndex = 0;
                private static int PuncteObtinute = 0;
                //
                List<string> GetQuestionContent = new List<string>();
                List<string> HiddenIndex = new List<string>();

                List<Elements>[] items = new List<Elements>[5];
                List<string> answersIndex = new List<string>();

                //
                public ViewAViewModel()
                {
                        BackButton = new DelegateCommand(ExecuteBack);
                        NextButton = new DelegateCommand(ExecuteNext);
                        if (MainPageViewModel._GetIndexLevel == 0)
                        {
                                CalculateRandomQuestions();
                        }
                        else if (MainPageViewModel._GetIndexLevel == 1)
                        {
                                CalculateRandomQuestions2();
                        }
                        else
                        {
                                CalculateRandomQuestions3();
                        }
                        var obj = new AllModels();
                        var getItem = AllModels.questions;

                        GetQuestionContent.Add(getItem[index[0]].Question);
                        GetQuestionContent.Add(getItem[index[1]].Question);
                        GetQuestionContent.Add(getItem[index[2]].Question);
                        GetQuestionContent.Add(getItem[index[3]].Question);
                        GetQuestionContent.Add(getItem[index[4]].Question);

                        HiddenIndex.Add(getItem[index[0]].TypeAnswers);
                        HiddenIndex.Add(getItem[index[1]].TypeAnswers);
                        HiddenIndex.Add(getItem[index[2]].TypeAnswers);
                        HiddenIndex.Add(getItem[index[3]].TypeAnswers);
                        HiddenIndex.Add(getItem[index[4]].TypeAnswers);

                        items[0] = new List<Elements>();
                        items[1] = new List<Elements>();
                        items[2] = new List<Elements>();
                        items[3] = new List<Elements>();
                        items[4] = new List<Elements>();

                        MessageBox.Show($"{index[0]}, {index[1]}, {index[2]}, {index[3]}, {index[4]}");
                        int idx = 1;
                        {//first block
                                string[] splitText = getItem[index[0]].Answers.Split(',');
                                answersIndex.Add(getItem[index[0]].RightAnswersIndex);
                                if (HiddenIndex[0] == "Visible")
                                {
                                       
                                        foreach (var word in splitText)
                                        {
                                                items[0].Add(new Elements() { LoadRadioContent = word, CurentIndex = idx});
                                                idx++;
                                        }
                                }
                                else
                                {
                                        foreach (var word in splitText)
                                        {
                                                items[0].Add(new Elements() { LoadRadioContent = word, groupQuest = "first question",  CurentIndex = idx });
                                                idx++;
                                        }
                                }
                                        
                               
                        }
                        idx = 1;
                        {//second block
                                answersIndex.Add(getItem[index[1]].RightAnswersIndex);
                                if (HiddenIndex[1] == "Visible")
                                {
                                        string[] splitText = getItem[index[1]].Answers.Split(',');
                                        
                                        foreach (var word in splitText)
                                        {
                                                items[1].Add(new Elements() { LoadRadioContent = word, CurentIndex = idx });
                                                idx++;
                                        }
                                }
                                else
                                {
                                        string[] splitText = getItem[index[1]].Answers.Split(',');
                                        foreach (var word in splitText)
                                        {
                                                items[1].Add(new Elements() { LoadRadioContent = word, groupQuest = "second question", CurentIndex = idx });
                                                idx++;
                                        }
                                }
                                
                        }
                        idx = 1;
                        {//third block
                                answersIndex.Add(getItem[index[2]].RightAnswersIndex);
                                if (HiddenIndex[2] == "Visible")
                                {
                                        string[] splitText = getItem[index[2]].Answers.Split(',');
                                        foreach (var word in splitText)
                                        {
                                                items[2].Add(new Elements() { LoadRadioContent = word, CurentIndex = idx });
                                                idx++;
                                        }
                                }
                                else
                                {
                                        string[] splitText = getItem[index[2]].Answers.Split(',');
                                        foreach (var word in splitText)
                                        {
                                                items[2].Add(new Elements() { LoadRadioContent = word, groupQuest = "third question", CurentIndex = idx });
                                                idx++;
                                        }
                                }
                                        
                        }
                        idx = 1;
                        {//fourth block
                                answersIndex.Add(getItem[index[3]].RightAnswersIndex);
                                if (HiddenIndex[3] == "Visible")
                                {
                                        string[] splitText = getItem[index[3]].Answers.Split(',');
                                        foreach (var word in splitText)
                                        {
                                                items[3].Add(new Elements() { LoadRadioContent = word, CurentIndex = idx });
                                                idx++;
                                        }
                                }
                                else
                                {
                                        string[] splitText = getItem[index[3]].Answers.Split(',');
                                        foreach (var word in splitText)
                                        {
                                                items[3].Add(new Elements() { LoadRadioContent = word, groupQuest = "fourth question", CurentIndex = idx });
                                                idx++;
                                        }

                                }
                                        
                        }
                        idx = 1;
                        {//fifth block
                                answersIndex.Add(getItem[index[4]].RightAnswersIndex);
                                if (HiddenIndex[4] == "Visible")
                                {
                                        string[] splitText = getItem[index[4]].Answers.Split(',');
                                        foreach (var word in splitText)
                                        {
                                                items[4].Add(new Elements() { LoadRadioContent = word, CurentIndex = idx });
                                                idx++;
                                        }
                                }
                                else
                                {
                                        string[] splitText = getItem[index[4]].Answers.Split(',');
                                        foreach (var word in splitText)
                                        {
                                                items[4].Add(new Elements() { LoadRadioContent = word, groupQuest = "fifth question", CurentIndex = idx });
                                                idx++;
                                        }
                                }
                                        
                        }
                        idx = 1;

                        ItemsControlGet = new List<Elements>();
                        ItemsControlGet = items[curentIndex];
                        OnPropertyRaised("ItemsControlGet");

                        _MultipleQuestion = HiddenIndex[curentIndex];
                        OnPropertyRaised("MultipleQuestion");

                        _QuestionName = GetQuestionContent[curentIndex];
                        OnPropertyRaised("QuestionName");
                }

                public void CalculateRandomQuestions()
                {
                        index[0] = randomNumber.Next(1, 10);
                        index[1] = randomNumber.Next(1, 10);
                        while(index[1] == index[0])
                        {
                                index[1] = randomNumber.Next(1, 10);
                        }
                        index[2] = randomNumber.Next(1, 10);
                        while (index[2]  == index[0] || index[2] == index[1])//zero colision
                        {
                                index[2] = randomNumber.Next(1, 10);
                        }
                        index[3] = randomNumber.Next(1, 10);
                        while (index[3] == index[0] || index[3] == index[1] || index[3] == index[2])//zero colision
                        {
                                index[3] = randomNumber.Next(1, 10);
                        }
                        index[4] = randomNumber.Next(1, 10);
                        while (index[4] == index[0] || index[4] == index[1] || index[4] == index[2] || index[4] == index[3])//zero colision
                        {
                                index[4] = randomNumber.Next(1, 10);
                        }
                }
                public void CalculateRandomQuestions2()
                {
                        index[0] = randomNumber.Next(10, 20);
                        index[1] = randomNumber.Next(10, 20);
                        while (index[1] == index[0])
                        {
                                index[1] = randomNumber.Next(1, 20);
                        }
                        index[2] = randomNumber.Next(10, 20);
                        while (index[2] == index[0] || index[2] == index[1])//zero colision
                        {
                                index[2] = randomNumber.Next(10, 20);
                        }
                        index[3] = randomNumber.Next(10, 20);
                        while (index[3] == index[0] || index[3] == index[1] || index[3] == index[2])//zero colision
                        {
                                index[3] = randomNumber.Next(10, 20);
                        }
                        index[4] = randomNumber.Next(10, 20);
                        while (index[4] == index[0] || index[4] == index[1] || index[4] == index[2] || index[4] == index[3])//zero colision
                        {
                                index[4] = randomNumber.Next(10, 20);
                        }
                }
                public void CalculateRandomQuestions3()
                {
                        index[0] = randomNumber.Next(20, 30);
                        index[1] = randomNumber.Next(20, 30);
                        while (index[1] == index[0])
                        {
                                index[1] = randomNumber.Next(20, 30);
                        }
                        index[2] = randomNumber.Next(20, 30);
                        while (index[2] == index[0] || index[2] == index[1])//zero colision
                        {
                                index[2] = randomNumber.Next(20, 30);
                        }
                        index[3] = randomNumber.Next(20, 30);
                        while (index[3] == index[0] || index[3] == index[1] || index[3] == index[2])//zero colision
                        {
                                index[3] = randomNumber.Next(20, 30);
                        }
                        index[4] = randomNumber.Next(20, 30);
                        while (index[4] == index[0] || index[4] == index[1] || index[4] == index[2] || index[4] == index[3])//zero colision
                        {
                                index[4] = randomNumber.Next(20, 30);
                        }
                }

                private string _QuestionName;
                public string [] QuestionName2 { get; set; }
                public string QuestionName
                {
                        get
                        {
                                return _QuestionName;
                        }
                }

                public DelegateCommand BackButton { get; private set; }
                public DelegateCommand NextButton { get; private set; }
                public class Elements
                {
                        public bool _CheckItem;
                        public int CurentIndex;
                        public string QuestionNameT  { get; set; }
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
                public string _MultipleQuestion = "Hidden";
                public string MultipleQuestion
                {
                        get
                        {
                                return _MultipleQuestion;
                        }
                        set
                        {
                                _MultipleQuestion = value;
                        }
                }

                private List<Elements> _ItemsControlGet;
                public List<Elements> ItemsControlGet
                {
                        get
                        {
                                return _ItemsControlGet;
                        }
                        set
                        {
                                _ItemsControlGet = value;
                        }
                }

                public event PropertyChangedEventHandler PropertyChanged;


                public void ExecuteBack()
                {
                        
                        if (curentIndex == 0)
                        {
                                return;
                        }
                        if (curentIndex == 4)
                        {
                                _ButtonNameSet = "Next";
                                OnPropertyRaised("ButtonNameSet");
                        }
                        curentIndex--;
                        ItemsControlGet = items[curentIndex];
                        OnPropertyRaised("ItemsControlGet");

                        _QuestionName = GetQuestionContent[curentIndex];
                        OnPropertyRaised("QuestionName");

                        _MultipleQuestion = HiddenIndex[curentIndex];
                        OnPropertyRaised("MultipleQuestion");
                }
                public void CheckAnswerRight()
                {
                        PuncteObtinute = 0;
                        bool flag = false;
                        string [] checking = answersIndex[0].Split(',');//impart in array raspunsurile
                        int[] t = new int[checking.Length];//aloc memorie pt fiecare raspuns
                        int i = 0;
                        {//first calculate

                                foreach (var check in checking)
                                {
                                        t[i] = Int32.Parse(check);//egalez t[i] cu raspunsul meu

                                        ++i;
                                }
                                for (var test = 0; test < items[0].Count(); ++test)//trec prin fiecare raspuns
                                {
                                        if (items[0][test]._CheckItem == true)//verific daca e bifat si raspunsul nu se potriveste cu nici una din variante
                                        {

                                                int crtidx = 0;
                                                for (int x = 0; x < t.Length; x++)
                                                {
                                                        if (items[0][test].CurentIndex == t[x] && crtidx < t.Length)
                                                        {
                                                                break;
                                                        }
                                                        else if (items[0][test].CurentIndex != t[x] && crtidx == t.Length - 1)
                                                        {
                                                                flag = true;
                                                                break;
                                                        }
                                                        crtidx++;
                                                }

                                        }
                                        else//verific daca nu e bifat si raspusul este cel corect
                                        {
                                                for (int x = 0; x < t.Length; x++)
                                                {
                                                        if (items[0][test].CurentIndex == t[x])
                                                        {
                                                                flag = true;
                                                                break;
                                                        }
                                                }
                                        }

                                        if (flag == true)
                                                break;
                                }
                                if (flag == true)
                                {

                                }
                                else
                                {
                                        PuncteObtinute++;
                                }
                                flag = false;
                                i = 0;
                        }
                        {//second calculate
                                checking = answersIndex[1].Split(',');
                                t = new int[checking.Length];
                                foreach (var check in checking)
                                {
                                        t[i] = Int32.Parse(check);//egalez t[i] cu raspunsul meu

                                        ++i;
                                }
                                for (var test = 0; test < items[1].Count(); ++test)//trec prin fiecare raspuns
                                {
                                        if (items[1][test]._CheckItem == true)//verific daca e bifat si raspunsul nu se potriveste cu nici una din variante
                                        {
                                                
                                                int crtidx = 0;
                                                for (int x = 0; x < t.Length; x++)
                                                {
                                                        if (items[1][test].CurentIndex == t[x] && crtidx < t.Length)
                                                        {
                                                                break;
                                                        }
                                                        else if(items[1][test].CurentIndex != t[x] && crtidx == t.Length-1)
                                                        {
                                                                flag = true;
                                                                break;
                                                        }
                                                        crtidx++;
                                                }

                                        }
                                        else//verific daca nu e bifat si raspusul este cel corect
                                        {
                                                for (int x = 0; x < t.Length; x++)
                                                {
                                                        if(items[1][test].CurentIndex == t[x])
                                                        {
                                                                flag = true;
                                                                break;
                                                        }
                                                }
                                        }
                                        
                                        if (flag == true)
                                                break;
                                }
                                if (flag == true)
                                {

                                }
                                else
                                {
                                        PuncteObtinute++;
                                }
                                flag = false;
                                i = 0;
                        }
                        {//THIRD calculate
                                checking = answersIndex[2].Split(',');
                                t = new int[checking.Length];
                                foreach (var check in checking)
                                {
                                        t[i] = Int32.Parse(check);//egalez t[i] cu raspunsul meu

                                        ++i;
                                }
                                for (var test = 0; test < items[2].Count(); ++test)//trec prin fiecare raspuns
                                {
                                        if (items[2][test]._CheckItem == true)//verific daca e bifat si raspunsul nu se potriveste cu nici una din variante
                                        {

                                                int crtidx = 0;
                                                for (int x = 0; x < t.Length; x++)
                                                {
                                                        if (items[2][test].CurentIndex == t[x] && crtidx < t.Length)
                                                        {
                                                                break;
                                                        }
                                                        else if (items[2][test].CurentIndex != t[x] && crtidx == t.Length - 1)
                                                        {
                                                                flag = true;
                                                                break;
                                                        }
                                                        crtidx++;
                                                }

                                        }
                                        else//verific daca nu e bifat si raspusul este cel corect
                                        {
                                                for (int x = 0; x < t.Length; x++)
                                                {
                                                        if (items[2][test].CurentIndex == t[x])
                                                        {
                                                                flag = true;
                                                                break;
                                                        }
                                                }
                                        }

                                        if (flag == true)
                                                break;
                                }
                                if (flag == true)
                                {

                                }
                                else
                                {

                                        PuncteObtinute++;
                                }
                                flag = false;
                                i = 0;
                        }
                        {//fourth calculate
                                checking = answersIndex[3].Split(',');
                                t = new int[checking.Length];
                                foreach (var check in checking)
                                {
                                        t[i] = Int32.Parse(check);//egalez t[i] cu raspunsul meu

                                        ++i;
                                }
                                for (var test = 0; test < items[3].Count(); ++test)//trec prin fiecare raspuns
                                {
                                        if (items[3][test]._CheckItem == true)//verific daca e bifat si raspunsul nu se potriveste cu nici una din variante
                                        {

                                                int crtidx = 0;
                                                for (int x = 0; x < t.Length; x++)
                                                {
                                                        if (items[3][test].CurentIndex == t[x] && crtidx < t.Length)
                                                        {
                                                                break;
                                                        }
                                                        else if (items[3][test].CurentIndex != t[x] && crtidx == t.Length - 1)
                                                        {
                                                                flag = true;
                                                                break;
                                                        }
                                                        crtidx++;
                                                }

                                        }
                                        else//verific daca nu e bifat si raspusul este cel corect
                                        {
                                                for (int x = 0; x < t.Length; x++)
                                                {
                                                        if (items[3][test].CurentIndex == t[x])
                                                        {
                                                                flag = true;
                                                                break;
                                                        }
                                                }
                                        }

                                        if (flag == true)
                                                break;
                                }
                                if (flag == true)
                                {

                                }
                                else
                                {
                                        PuncteObtinute++;
                                }
                                flag = false;
                                i = 0;
                        }
                        {//fifth calculate
                                checking = answersIndex[4].Split(',');//answersIndex[0] -primul elem
                                t = new int[checking.Length];
                                foreach (var check in checking)
                                {
                                        t[i] = Int32.Parse(check);//egalez t[i] cu raspunsul meu

                                        ++i;
                                }
                                for (var test = 0; test < items[4].Count(); ++test)//trec prin fiecare raspuns
                                {
                                        if (items[4][test]._CheckItem == true)//verific daca e bifat si raspunsul nu se potriveste cu nici una din variante
                                        {

                                                int crtidx = 0;
                                                for (int x = 0; x < t.Length; x++)
                                                {
                                                        if (items[4][test].CurentIndex == t[x] && crtidx < t.Length)
                                                        {
                                                                break;
                                                        }
                                                        else if (items[4][test].CurentIndex != t[x] && crtidx == t.Length - 1)
                                                        {
                                                                flag = true;
                                                                break;
                                                        }
                                                        crtidx++;
                                                }

                                        }
                                        else//verific daca nu e bifat si raspusul este cel corect
                                        {
                                                for (int x = 0; x < t.Length; x++)
                                                {
                                                        if (items[4][test].CurentIndex == t[x])
                                                        {
                                                                flag = true;
                                                                break;
                                                        }
                                                }
                                        }

                                        if (flag == true)
                                                break;
                                }
                                if (flag == true)
                                {
                                }
                                else
                                {
                                        PuncteObtinute++;
                                }
                                flag = false;
                                i = 0;
                        }

                }

                public void ExecuteNext()
                {
                        if (curentIndex == 3)
                        {
                                _ButtonNameSet = "Finish";
                                OnPropertyRaised("ButtonNameSet");
                        }
                        if (curentIndex == 4)
                        {
                                CheckAnswerRight();
                                MessageBox.Show($"Felicitari {MainPageViewModel._NameInsertion}, ai terminat testul! Ai reusit sa obtii {PuncteObtinute}/5 puncte");
                                return;
                        }
                        curentIndex++;
                        ItemsControlGet = items[curentIndex];
                        OnPropertyRaised("ItemsControlGet");

                        _QuestionName = GetQuestionContent[curentIndex];
                        OnPropertyRaised("QuestionName");

                        _MultipleQuestion = HiddenIndex[curentIndex];
                        OnPropertyRaised("MultipleQuestion");

                }
                string _ButtonNameSet = "Next";
                public string ButtonNameSet
                {
                        get
                        {
                                return _ButtonNameSet;
                        }
                }

                private void OnPropertyRaised(string propertyname)
                {
                        if (PropertyChanged != null)
                        {
                                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                        }
                }

                //convert
                public class IndexBooleanConverter : IValueConverter
                {
                        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                        {
                                if (value == null || parameter == null)
                                        return false;
                                else
                                        return (int)value == System.Convert.ToInt32(parameter);
                        }

                        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                        {
                                if (value == null || parameter == null)
                                        return null;
                                else if ((bool)value)
                                        return System.Convert.ToInt32(parameter);
                                else
                                        return DependencyProperty.UnsetValue;
                        }
                }
        }
}
