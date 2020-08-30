using Prism.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using WpfApp2.Models;
using Prism.Mvvm;
using Prism.Regions;
using System.Xml.Linq;
using System;
using System.Linq;

namespace WpfApp2.ViewModels
{
        class ViewAViewModel : INotifyPropertyChanged
        {
                Random randomNumber = new Random();
                private int[] index;
                private static int curentIndex = 0;
                private static int PuncteObtinute = 0;
                private static int NumberQuestioms;
                List<string> GetQuestionContent = new List<string>();
                List<bool> HiddenIndex = new List<bool>();
                List<Elements>[] items;
                List<string> answersIndex = new List<string>();
                public ViewAViewModel()
                {
                        var getItem = AllModels.questions;
                        BackButton = new DelegateCommand(ExecuteBack);
                        NextButton = new DelegateCommand(ExecuteNext);
                        LoadData();
                        index = new int[NumberQuestioms];
                        items = new List<Elements>[NumberQuestioms];
                        CalculateRandomQuestions();
                        int f = 1;
                        for (int i = 0; i < NumberQuestioms; ++i)
                        {
                                f = 1;
                                GetQuestionContent.Add(getItem[index[i]].Question);
                                HiddenIndex.Add(new bool());
                                items[i] = new List<Elements>();
                                string[] splitText = getItem[index[i]].Answers.Split(',');
                                answersIndex.Add(getItem[index[i]].RightAnswersIndex);
                                if(getItem[index[i]].RightAnswersIndex.Length == 1)
                                {
                                        HiddenIndex[i] = false;
                                }
                                else
                                {
                                        HiddenIndex[i] = true;
                                }

                                if (HiddenIndex[i] == true)
                                {
                                        foreach (var word in splitText)
                                        {
                                                items[i].Add(new Elements() { LoadRadioContent = word, CurentIndex = f });
                                                ++f;
                                        }
                                }
                                else
                                {
                                        foreach (var word in splitText)
                                        {
                                                items[i].Add(new Elements() { LoadRadioContent = word, groupQuest = "this question", CurentIndex = f });
                                                ++f;
                                        }
                                }
                        }
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
                        int interval1 = AllModels.questions.Count;
                        for (int i = 0; i < NumberQuestioms; ++i)
                        {
                                index[i] = randomNumber.Next(1, interval1);
                                for (int j = 0; j < i; ++j)
                                {
                                        while (index[i] == index[j])
                                        {
                                                index[i] = randomNumber.Next(1, interval1);
                                        }
                                }
                        }
                }
                public void LoadData()
                {
                        var xml = XDocument.Load("Questions.xml");
                        if (MainPageViewModel._GetIndexLevel == 0)
                        {
                                var query = from index in xml.Descendants("question")
                                            where (string)index.Element("TypeQuestion") == "eazy"
                                            select index;
                                int i = 1;
                                foreach (var x in query)
                                {
                                        AllModels.questions.Add(i, new QuestionParameter() { Question = x.Element("name").Value.ToString(), Answers = x.Element("answers").Value.ToString(), RightAnswersIndex = x.Element("rightIndex").Value.ToString(), TypeAnswers = x.Element("TypeQuestion").Value.ToString() });
                                        ++i;
                                }
                        }
                        else if (MainPageViewModel._GetIndexLevel == 1)
                        {
                                var query = from index in xml.Descendants("question")
                                            where (string)index.Element("TypeQuestion") == "medium"
                                            select index;
                                int i = 1;
                                foreach (var x in query)
                                {
                                        AllModels.questions.Add(i, new QuestionParameter() { Question = x.Element("name").Value.ToString(), Answers = x.Element("answers").Value.ToString(), RightAnswersIndex = x.Element("rightIndex").Value.ToString(), TypeAnswers = x.Element("TypeQuestion").Value.ToString() });
                                        ++i;
                                }
                        }
                        else
                        {
                                var query = from index in xml.Descendants("question")
                                            where (string)index.Element("TypeQuestion") == "hard"
                                            select index;
                                int i = 1;
                                foreach (var x in query)
                                {
                                        AllModels.questions.Add(i, new QuestionParameter() { Question = x.Element("name").Value.ToString(), Answers = x.Element("answers").Value.ToString(), RightAnswersIndex = x.Element("rightIndex").Value.ToString(), TypeAnswers = x.Element("TypeQuestion").Value.ToString() });
                                        ++i;
                                }
                        }
                        var query2 = from index in xml.Descendants("Content")
                                     select (int)index.Element("NumberQuestions");
                        foreach (var x in query2)
                        {
                                NumberQuestioms = x;
                        }
                        if (NumberQuestioms > AllModels.questions.Count)
                                NumberQuestioms = AllModels.questions.Count;
                }
                private string _QuestionName;
                public string QuestionName
                {
                        get
                        {
                                return _QuestionName;
                        }
                }
                public DelegateCommand BackButton { get; private set; }
                public DelegateCommand NextButton { get; private set; }
                public bool _MultipleQuestion = false;
                public bool MultipleQuestion
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
                        if (curentIndex == 0)  return;
                        if (curentIndex == NumberQuestioms-1)
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
                        int i = 0;
                        for(int z = 0; z < NumberQuestioms; ++z)
                        {
                                string[] checking = answersIndex[z].Split(',');
                                int[] t = new int[checking.Length];
                                foreach (var check in checking)
                                {
                                        t[i] = Int32.Parse(check);//egalez t[i] cu raspunsul meu
                                        ++i;
                                }
                                for (var test = 0; test < items[z].Count(); ++test)//trec prin fiecare raspuns
                                {
                                        if (items[z][test]._CheckItem == true)//verific daca e bifat si raspunsul nu se potriveste cu nici una din variante
                                        {
                                                int crtidx = 0;
                                                for (int x = 0; x < t.Length; x++)
                                                {
                                                        if (items[z][test].CurentIndex == t[x] && crtidx < t.Length)
                                                        {
                                                                break;
                                                        }
                                                        else if (items[z][test].CurentIndex != t[x] && crtidx == t.Length - 1)
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
                                                        if (items[z][test].CurentIndex == t[x])
                                                        {
                                                                flag = true;
                                                                break;
                                                        }
                                                }
                                        }
                                        if (flag == true) break;
                                }
                                if (flag == true) { }
                                else
                                        PuncteObtinute++;
                                flag = false;
                                i = 0;
                        }
                }
                public string _ButtonNameSet = "Next";
                public string ButtonNameSet
                {
                        get
                        {
                                return _ButtonNameSet;
                        }
                }
                public void ExecuteNext()
                {
                        //
                        if (curentIndex == NumberQuestioms-2)
                        {
                                _ButtonNameSet = "Finish";
                                OnPropertyRaised("ButtonNameSet");
                        }
                        if (curentIndex == NumberQuestioms-1)
                        {
                                CheckAnswerRight();
                                MessageBox.Show($"Felicitari {MainPageViewModel._NameInsertion}, ai terminat testul! Ai reusit sa obtii {PuncteObtinute}/{NumberQuestioms} puncte");
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
                private void OnPropertyRaised(string propertyname)
                {
                        if (PropertyChanged != null)
                        {
                                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                        }
                }
        }
}